// ---------------------------------------------------------------------------------------
//                                        ILGPU
//                           Copyright (c) 2022 ILGPU Project
//                                    www.ilgpu.net
//
// File: search.js
//
// This file is part of ILGPU and is distributed under the University of Illinois Open
// Source License. See LICENSE.txt for details.
// ---------------------------------------------------------------------------------------


/***** Lunr Index *****/
const searchDocuments = [
    
        
        {
            "title": "Setting Up ILGPU",
            "content": `What is ILGPU

ILGPU provides an interface for programming GPUs that uses a sane programming language, C#.
ILGPU takes your normal C# code (perhaps with a few small changes) and transforms it into either
OpenCL or PTX (think CUDA assembly). This combines all the power, flexibility, and performance of
CUDA / OpenCL with the ease of use of C#.

Setting up ILGPU.

This tutorial is a little different now because we are going to be looking at the ILGPU 1.0.0.

ILGPU should work on any 64-bit platform that .Net supports. I have even used it on the inexpensive nvidia jetson nano
with pretty decent cuda performance.

Technically ILGPU supports F# but I don’t use F# enough to really tutorialize it. I will be sticking to C# in these
tutorials.

High level setup steps.

If enough people care I can record a short video of this process, but I expect this will be enough for most programmers.


  Install the most recent .Net SDK for your chosen
platform.
  Create a new C# project.

  Add the ILGPU package

  ??????
  Profit


More Info

If you would like more info about GPGPU I would recommend the following resources.


  The Cuda docs / OpenCL docs
  An Introduction to CUDA Programming - 5min
  Introduction to GPU Architecture and Programming Models - 2h 14min


`,
            "url": "/docs/01-primers/01-setting-up-ilgpu/"
        }
        ,
        
    
        
        {
            "title": "A GPU Is Not A CPU",
            "content": `Primer 01: Code

This page will provide a quick rundown of the basics of how kernels (think GPU programs) run.
If you are already familiar with CUDA or OpenCL programs you can probably skip this.

To steal a quote from a very good talk that you should probably watch.


  You cannot program the GPU like its a CPU
You must pay attention to 3 things
  
    
      Memory Access
    
    
      Data Locality
    
    
      Threading
    
  


A GPU is not a CPU

If you will allow a little bit of massive oversimplification, this is pretty easy to understand.

How does a CPU work?

A traditional processor has a very simple cycle: fetch, decode, execute.

It grabs an instruction from memory (the fetch), figures out how to perform said instruction (the decode),
and does the instruction (the execute). This cycle then repeats for all the instructions in your algorithm.
Executing this linear stream of instructions is fine for most programs because CPUs are super fast, and most
algorithms are serial.

What happens when you have an algorithm that can be processed in parallel? A CPU has multiple cores, each
doing its own fetch, decode, execute. You can spread the algorithm across all the cores on the CPU, but
in the end each core will still be running a stream of instructions, likely the same stream of instructions,
but with different data.

GPUs and CPUs both try to exploit this fact, but use two very different methods.

CPU | SIMD: Single Instruction Multiple Data.

CPUs have a trick for parallel programs called SIMD. These are a set of instructions
that allow you to have one instuction do operations on multiple pieces of data at once.

Lets say a CPU has an add instruction:

  ADD RegA RegB


Which would perform

  RegA = RegB + RegA


The SIMD version would be:

  ADD RegABCD RegEFGH


Which would perform

  RegA = RegE + RegA

  RegB = RegF + RegB

  RegC = RegG + RegC

  RegD = RegH + RegD


All at once.

A clever programmer can take these instructions and get a 3x-8x performance improvement
in very math heavy scenarios.

GPU | SIMT: Single Instruction Multiple Threads.

GPUs have SIMT. SIMT is the same idea as SIMD but instead of just doing the math instructions
in parallel why not do all the instructions in parallel.

The GPU assumes all the instructions you are going to fetch and decode for 32 threads are
the same, it does 1 fetch and decode to setup 32 execute steps, then it does all 32 execute
steps at once. This allows you to get 32 way multithreading per single core, if and only
if all 32 threads want to do the same instruction.

Kernels

With this knowledge we can now talk about kernels. Kernels are just GPU programs, but because
a GPU program is not a single thread, but many, it works a little different.

When I was first learning about kernels I had an observation that made kernels kinda click
in my head.

Kernels and Parallel.For have the same usage pattern.

If you don’t know about Parallel.For it is a function that provides a really easy way to run
code on every core of the CPU. All you do is pass in the start index, an end index, and a function
that takes an index. Then the function is called from some thread with an index. There are no guarantees
about what core an index is run on, or what order the threads are run, but you get a very simple
interface for running parallel functions.

using System;
using System.Threading.Tasks;

public static class Program
{
    static void Main(string[] args)
    {
        //Load the data
        int[] data = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        int[] output = new int[10_000];
            
        //Load the action and execute
        Parallel.For(0, output.Length, 
        (int i) =&gt;
        {
            output[i] = data[i % data.Length];
        });
    }
}


Running the same program as a kernel is very similar:

using ILGPU;
using ILGPU.Runtime;
using ILGPU.Runtime.CPU;

public static class Program
{
    static void Main()
    {
        // Initialize ILGPU.
        Context context = Context.CreateDefault();
        Accelerator accelerator = context.CreateCPUAccelerator(0);

        // Load the data.
        var deviceData = accelerator.Allocate1D(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
        var deviceOutput = accelerator.Allocate1D&lt;int&gt;(10_000);

        // load / compile the kernel
        var loadedKernel = accelerator.LoadAutoGroupedStreamKernel(
        (Index1D i, ArrayView&lt;int&gt; data, ArrayView&lt;int&gt; output) =&gt;
        {
            output[i] = data[i % data.Length];
        });

        // tell the accelerator to start computing the kernel
        loadedKernel((int)deviceOutput.Length, deviceData.View, deviceOutput.View);

        // wait for the accelerator to be finished with whatever it's doing
        // in this case it just waits for the kernel to finish.
        accelerator.Synchronize();

        accelerator.Dispose();
        context.Dispose();
    }
}


You do not need to understand what is going on in the kernel example to see that the Parallel.For code uses the same
API. The major differences are due to how memory is handled.

Parallel.For and Kernels both have the same potential for race conditions, and for each you must take care to prevent
them.

`,
            "url": "/docs/01-primers/02-a-gpu-is-not-a-cpu/"
        }
        ,
        
    
        
        {
            "title": "Memory & Bandwidth Threads",
            "content": `Primer 02: Memory

The following is my understanding of the performance quirks with GPUs due to memory and cache and coalescent memory
access.
Just like with Primer 01, if you have a decent understanding of CUDA or OpenCL you can skip this.

Ok, buckle up.

Memory and bandwidth and threads. Oh my!

Computers need memory, and memory is slow0. (Like, really slow)

Back in the day (I assume, the first computer I remember using had DDR-200) computer memory
was FAST. Most of the time the limiting factor was the CPU, though correctly timing video output was also
a driving force. As an example, the C64 ran the memory at 2x the CPU frequency so the VIC-II
graphics chip could share the CPU memory by stealing half the cycles. In the almost 40 years since the C64, humanity
has gotten much better at making silicon and precious metals do our bidding. Feeding
data into the CPU from memory has become the slow part. Memory is slow.

Why is memory slow? To be honest, it seems to me that it’s caused by two things:


  Physics
Programmers like to think of computers as an abstract thing, a platonic ideal.
But here in the real world there are no spherical cows, no free lunch. Memory values are ACTUAL
ELECTRONS traveling through silicon and precious metals.


In general, the farther from the thing doing the math the ACTUAL ELECTRONS are the slower it is
to access.


  We need want a lot of memory.
We can make memory that is almost as fast as our processors, but it must literally be directly made into the
processor cores in silicon.
Not only is this is very expensive, the more memory in silicon the less room for processor stuff.


How do processors deal with slow memory?

This leads to an optimization problem. Modern processor designers use a complex system of tiered
memory consisting of several layers of small, fast, on-die memory and large, slow, distant, off-die memory.

A processor can also perform a few tricks to help us deal with the fact that memory is slow.
One example is prefetching. If a program uses memory at location X it probably will use the
memory at location X+1 therefore the processor prefetchs a whole chunk of memory and puts it in
the cache, closer to the processor. This way if you do need the memory at X+1 it is already in cache.

I am getting off topic. For a more detailed explanation, see this thing I found
on google.

What does this mean for ILGPU?

GPU’s have memory, and memory is slow.

GPUs on paper have TONS of memory bandwidth, my GPU has around 10x the memory bandwidth my CPU does. Right? Yeah…

Kinda

If we go back into spherical cow territory and ignore a ton of important details, we can illustrate an
important quirk in GPU design that directly impacts performance.

My CPU, a Ryzen 5 3600 with dual channel DDR4, gets around 34 GB/s of memory bandwidth. The GDDR6 in my GPU, a RTX 2060,
gets around 336 GB/s of memory bandwidth.

But lets compare bandwidth per thread.

CPU: Ryzen 5 3600 34 GB/s / 12 threads = 2.83 GB/s per thread

GPU: RTX 2060 336 GB/s / (30 SM’s * 512 threads1) = 0.0218 GB/s or just 22.4 MB/s per thread

So what?

In the end computers need memory because programs need memory. There are a few things I think about as I program that I
think help:


  If your code scans through memory linearly the GPU can optimize it by prefetching the data. This leads to the “struct
of arrays”
approach, more on that in the structs tutorial.
  GPUs take prefetching to the next level by having coalescent memory access, which I need a more in depth explanation
of, but
basically if threads are accessing memory in a linear way that the GPU can detect, it can send one memory access for
the whole chunk
of threads.


Again, this all boils down to the very simple notion that memory is slow, and it gets slower the farther it gets from
the processor.


  0
This is obviously a complex topic. In general, modern memory bandwidth has a speed, and a latency problem. They
are different, but in subtle ways. If you are interested in this I would do some more research, I am just
some random dude on the internet.



  1
I thought this would be simple, but after double checking, I found that the question “How many threads can a GPU run
at once?”
is a hard question and also the wrong question to answer. According to the cuda manual, at maximum an SM (Streaming
Multiprocessor) can
have 16 warps executing simultaneously and 32 threads per warp so it can issue at minimum 512 memory accesses per
cycle. You may have more warps scheduled due to memory / instruction latency but a minimum estimate will do. This
still provides a good
illustration for how little memory bandwidth you have per thread. We will get into more detail in a
grouping tutorial.


`,
            "url": "/docs/01-primers/03-memory-and-bandwidth-threads/"
        }
        ,
        
    
        
        {
            "title": "Context & Accelerators",
            "content": `Tutorial 01 Context, Device, and Accelerators

Welcome to the first ILGPU tutorial! In this tutorial we will cover the basics of the Context, Device, and Accelerator
objects.

Context

All ILGPU classes and functions rely on an instance of ILGPU.Context.
The context’s job is mainly to act as an interface for the ILGPU compiler.
I believe it also stores some global state.


  requires: using ILGPU;
  basic constructing: Context context = Context.CreateDefault();


A context object, as well as most instances of classes that
require a context, require dispose calls to prevent memory
leaks. In most simple cases you can use the using pattern as
such: using Context context = Context.CreateDefault();
to make it harder to mess up. You can also see this in the first sample below.

You can also use the Context Builder to change context settings, more on that in a later tutorial.

For now all we need is a default context.

Device

Before version 1.0.0 ILGPU had no way to query device information without creating a full accelerator instance.
ILGPU v1.0.0 added in the Device class to fix this issue.

In ILGPU the Device represents the hardware in your computer.


  requires: using ILGPU; and using ILGPU.Runtime;


List Devices Sample

Lists all devices that ILGPU can use.

using ILGPU;
using ILGPU.Runtime;
using System;

public static class Program
{
    static void Main()
    {
        Context context = Context.Create(builder =&gt; builder.AllAccelerators());

        foreach (Device device in context)
        {
            Console.WriteLine(device);
        }
    }
}


Accelerators

In ILGPU the accelerator represents a hardware or software GPU.
Every ILGPU program will require at least 1 Accelerator.
Currently there are 3 Accelerator types: CPU, Cuda, and OpenCL,
as well as an abstract Accelerator.

Device Info Example See Also Device Info Sample

using ILGPU;
using ILGPU.Runtime;
using ILGPU.Runtime.CPU;
using ILGPU.Runtime.Cuda;
using ILGPU.Runtime.OpenCL;
using System;
using System.IO;

public static class Program
{
    public static void Main()
    {
        // Builds a context that has all possible accelerators.
        using Context context = Context.CreateDefault();

        // Builds a context that only has CPU accelerators.
        //using Context context = Context.Create(builder =&gt; builder.CPU());

        // Builds a context that only has Cuda accelerators.
        //using Context context = Context.Create(builder =&gt; builder.Cuda());

        // Builds a context that only has OpenCL accelerators.
        //using Context context = Context.Create(builder =&gt; builder.OpenCL());

        // Builds a context with only OpenCL and Cuda acclerators.
        //using Context context = Context.Create(builder =&gt;
        //{
        //    builder
        //        .OpenCL()
        //        .Cuda();
        //});

        // Prints all accelerators.
        foreach (Device d in context)
        {
            using Accelerator accelerator = d.CreateAccelerator(context);
            Console.WriteLine(accelerator);
            Console.WriteLine(GetInfoString(accelerator));
        }

        // Prints all CPU accelerators.
        foreach (CPUDevice d in context.GetCPUDevices())
        {
            using CPUAccelerator accelerator = (CPUAccelerator)d.CreateAccelerator(context);
            Console.WriteLine(accelerator);
            Console.WriteLine(GetInfoString(accelerator));
        }

        // Prints all Cuda accelerators.
        foreach (Device d in context.GetCudaDevices())
        {
            using Accelerator accelerator = d.CreateAccelerator(context);
            Console.WriteLine(accelerator);
            Console.WriteLine(GetInfoString(accelerator));
        }

        // Prints all OpenCL accelerators.
        foreach (Device d in context.GetCLDevices())
        {
            using Accelerator accelerator = d.CreateAccelerator(context);
            Console.WriteLine(accelerator);
            Console.WriteLine(GetInfoString(accelerator));
        }
    }

    private static string GetInfoString(Accelerator a)
    {
        StringWriter infoString = new StringWriter();
        a.PrintInformation(infoString);
        return infoString.ToString();
    }
}


CPUAccelerator


  requires no special hardware… well no more than C# does.
  requires: using ILGPU.CPU; and using ILGPU.Runtime;
  basic constructing: Accelerator accelerator = context.CreateCPUAccelerator(0);


The parameter of CreateCPUAccelerator denotes which cpu will be used if the context is constructed with multiple debug
cpu acclerators.

In general the CPUAccelerator is best for debugging and as a fallback. While the
CPUAccelerator is slow it is the only way to use much of the debugging features built
into C#. It is a good idea to write your program in such a way that you are able to switch to a CPUAcclerator to aid
debugging.

CudaAccelerator


  requires a supported CUDA capable gpu
  imports: using ILGPU.Cuda; using ILGPU.Runtime;
  basic constructing: Accelerator accelerator = context.CreateCudaAccelerator(0);


The parameter of CreateCudaAccelerator denotes which gpu will be used in the case of a multi-gpu system.

If you have one or more Nvida GPUs that are supported, this is the accelerator for
you. What is supported is a complex question, but in general anything GTX 680 or
newer should work. Some features require newer cards. Feature support should0 match CUDA.

CLAccelerator


  requires an OpenCL 2.0+ capable gpu
  imports: using ILGPU.OpenCL, using ILGPU.Runtime;
  basic constructing: Accelerator accelerator = context.CreateCLAccelerator(0);


The parameter of CreateCLAccelerator denotes which gpu will be used in the case of a multi-gpu system.
NOTE: This is the 1st OpenCL device usable by ILGPU and not the 1st OpenCL device of your machine.

If you have one or more AMD or Intel GPUs that are supported this is
the accelerator for you. Technically Nvidia GPUs support OpenCL but
they are limited to OpenCL 1.2 which is essentially useless.
Because of this, these tutorials need a bit of a disclaimer: I do not
have an OpenCL 2.0 compatible GPU so most of the OpenCL stuff is untested.
Please let me know if there are any issues.

NOTE: OpenCL 3.0 makes this far more complex but still doesn’t fix the issue that Nvidia GPUs are unsupported.

Accelerator

Abstract class for storing and passing around more specific
accelerators.


  requires: using ILGPU.Runtime


Sample 01|03

There is no guaranteed way to find the most powerful accelerator. If you are programming for
known hardware you can, and should, just hardcode it. However, if you do need a method, ILGPU provides two.

For a single device: context.GetPreferredDevice(preferCPU);

For multiple devices: context.GetPreferredDevices(preferCPU, matchingDevicesOnly);

using System;
using ILGPU;
using ILGPU.Runtime;
public static class Program
{
    static void Main()
    {
        using Context context = Context.Create(builder =&gt; builder.AllAccelerators());
        Console.WriteLine("Context: " + context.ToString());

        Device d = context.GetPreferredDevice(preferCPU: false);
        Accelerator a = d.CreateAccelerator(context);

        a.PrintInformation();
        a.Dispose();

        foreach(Device device in context.GetPreferredDevices(preferCPU: false, matchingDevicesOnly: false))
        {
            Accelerator accelerator = device.CreateAccelerator(context);
            accelerator.PrintInformation();
            accelerator.Dispose();
        }
    }
}


Don’t forget to dispose the accelerator. We do not have to call dispose
on context because we used the using pattern. It is important to note
that you must dispose objects in the reverse order from when you obtain them.

As you can see in the above sample, the context is obtained first and then
the accelerator. We dispose the accelerator explicitly by calling accelerator.Dispose();
and then only afterwards dispose the context automatically via the using pattern.

The Device instances do not need to be disposed.

In more complex programs you may have a more complex tree of memory, kernels, streams, and accelerators
to dispose of correctly.

Lets assume this is the structure of some program:


  Context
    
      CPUAccelerator
        
          Some Memory
          Some Kernel
        
      
      CudaAccelerator
        
          Some Other Memory
          Some Other Kernel
        
      
    
  


Anything created by the CPU accelerator must be disposed before the CPU accelerator
can be disposed. And then the CPU accelerator must be disposed before the context can
be disposed. However before we can dispose the context we must dispose the Cuda accelerator
and everything that it owns.

Ok, this tutorial covers most of the boiler plate code needed.

The next tutorial covers memory.


  0 Should is the programmers favorite word

  - Me

  In all seriousness your best bet is to test the features you want to use against the gpu you would like to use, or
consult this part of the cuda
docs.


`,
            "url": "/docs/02-beginner/01-context-and-accelerators/"
        }
        ,
        
    
        
        {
            "title": "MemoryBuffers & ArrayViews",
            "content": `Tutorial 02 MemoryBuffers and ArrayViews

Welcome to the seccond ILGPU tutorial. In this tutorial we will cover the basics
of the Memory in ILGPU. In the best case, C# programmers will think of memory
in terms of stack and heap objects, ref / in / out parameters, and GC. Once you
introduce a coprocessor like a GPU, memory gets a little more complex.

Starting in this tutorial we need a bit of jargon:


  Device: the GPU or a GPU
  Host: the computer that contains the device


Each side can also have memory, to help keep it straight I will refer to it as:


  Device Memory: the GPU memory
  Host Memory: the CPU memory


In most computers, the host and device each have there own seperate memory. There are some ways
to pretend that they share memory in ILGPU, like ExchangeBuffers (more on that in a more Advanced
memory tutorial), but for now I will manage both sides manually.

NOTE: This “Device” is the actual hardware described by the Device class in ILGPU.

To use memory you need to be able to allocate it, copy data into it, and copy data out of it.
ILGPU provides an interface to do this.

NOTE: You will notice that all the memory is talked about in terms of arrays. If you want to pass
a single value into the GPU you can allocate an array of size 1 or pass it into the kernel as a
parameter, more on this in the Kernel tutorial and the Structs tutorial.

NOTE 2 (Return of the note): ILGPU v1.0 adds stride data to MemoryBuffer and ArrayView to fix
some issues. IMPORTANT: When in doubt use Stride1D.Dense, Stride2D.DenseY, or Stride2D.DenseZY.
I will go over this better in a striding tutorial, but these should be your defaults because they
match how C# strides 1D, 2D, and 3D arrays.

MemoryBuffer1D&lt;T&gt;

The MemoryBuffer is the host side copy of memory allocated on the device. It is essentially just a
pointer to the memory that was allocated on the Device.


  always obtained from an Accelerator
  requires: using ILGPU.Runtime;
  basic constructing: MemoryBuffer1D&lt;int, Stride1D.Dense&gt; OnDeviceInts = accelerator.Allocate1D&lt;int&gt;(1000);


CopyFromCPU

After allocating a MemoryBuffer you will probably want to load data into it. This can be done
using the CopyFromCPU method of a MemoryBuffer.

Basic usage, copying everything from IntArray to OnDeviceInts


  OnDeviceInts.CopyFromCPU(IntArray)


CopyToCPU

To copy memory out of a MemoyBuffer and into an array on host you use CopyToCPU.

Basic usage, copying everything from OnDeviceInts to IntArray


  OnDeviceInts.CopyToCPU(IntArray)


ArrayView&lt;T&gt;

The ArrayView is the device side copy of memory allocated on the device via the host. This is the side of the
MemoryBuffer
API that the kernels / GPU will interact with.


  always obtained from a MemoryBuffer
  requires: using ILGPU.Runtime;
  basic constructing: ArrayView1D&lt;int, Stride1D.Dense&gt; ints = OnDeviceInts.View;


Inside the kernel the ArrayView works exactly like you would expect a normal array to. Again, more on that in the
Kernel tutorial.

Memory Example See Also Simple Allocation Sample

All device side memory management happens in the host code through the MemoryBuffer.
The sample goes over the basics of managing memory via MemoryBuffers. There will be far more
in depth memory management in the later tutorials.

using System;

using ILGPU;
using ILGPU.Runtime;
using ILGPU.Runtime.CPU;

public static class Program
{
    public static readonly bool debug = false;
    static void Main()
    {
        // We still need the Context and Accelerator boiler plate.
        Context context = Context.CreateDefault();
        Accelerator accelerator = context.CreateCPUAccelerator(0);

        // Gets array of 1000 doubles on host.
        double[] doubles = new double[1000];

        // Gets MemoryBuffer on device with same size and contents as doubles.
        MemoryBuffer1D&lt;double, Stride1D.Dense&gt; doublesOnDevice = accelerator.Allocate1D(doubles);

        // What if we change the doubles on the host and need to update the device side memory?
        for (int i = 0; i &lt; doubles.Length; i++) { doubles[i] = i * Math.PI; }

        // We call MemoryBuffer.CopyFrom which copies any linear slice of doubles into the device side memory.
        doublesOnDevice.CopyFromCPU(doubles);

        // What if we change the doublesOnDevice and need to write that data into host memory?
        doublesOnDevice.CopyToCPU(doubles);

        // You can copy data to and from MemoryBuffers into any array / span / memorybuffer that allocates the same
        // type. for example:
        double[] doubles2 = new double[doublesOnDevice.Length];
        doublesOnDevice.CopyFromCPU(doubles2);

        // There are also helper functions, but be aware of what a function does.
        // As an example this function is shorthand for the above two lines.
        // This completely allocates a new double[] on the host. This is slow.
        double[] doubles3 = doublesOnDevice.GetAsArray1D();

        // Notice that you cannot access memory in a MemoryBuffer or an ArrayView from host code.
        // If you uncomment the following lines they should crash.
        // doublesOnDevice[1] = 0;
        // double d = doublesOnDevice[1];

        // There is not much we can show with ArrayViews currently, but in the 
        // Kernels Tutorial it will go over much more.
        ArrayView1D&lt;double, Stride1D.Dense&gt; doublesArrayView = doublesOnDevice.View;

        // do not forget to dispose of everything in the reverse order you constructed it.
        doublesOnDevice.Dispose();
        // note the doublesArrayView is now invalid, but does not need to be disposed.
        accelerator.Dispose();
        context.Dispose();
    }
}


`,
            "url": "/docs/02-beginner/02-memorybuffers-and-arrayviews/"
        }
        ,
        
    
        
        {
            "title": "Kernels & Simple Programs",
            "content": `Tutorial 03 Kernels and Simple Programs.

In this tutorial we actually do work on the GPU!

Lets start with an example.

I think the easiest way to explain this is taking the simplest example I can think of and decomposing it.

This is a modified version of the sample from Primer 01.

using ILGPU;
using ILGPU.Runtime;
using System;

public static class Program
{
    static void Kernel(Index1D i, ArrayView&lt;int&gt; data, ArrayView&lt;int&gt; output)
    {
        output[i] = data[i % data.Length];
    }

    static void Main()
    {
        // Initialize ILGPU.
        Context context = Context.CreateDefault();
        Accelerator accelerator = context.GetPreferredDevice(preferCPU: false)
                                  .CreateAccelerator(context);

        // Load the data.
        MemoryBuffer1D&lt;int, Stride1D.Dense&gt; deviceData = accelerator.Allocate1D(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
        MemoryBuffer1D&lt;int, Stride1D.Dense&gt; deviceOutput = accelerator.Allocate1D&lt;int&gt;(10_000);

        // load / precompile the kernel
        Action&lt;Index1D, ArrayView&lt;int&gt;, ArrayView&lt;int&gt;&gt; loadedKernel = 
            accelerator.LoadAutoGroupedStreamKernel&lt;Index1D, ArrayView&lt;int&gt;, ArrayView&lt;int&gt;&gt;(Kernel);

        // finish compiling and tell the accelerator to start computing the kernel
        loadedKernel((int)deviceOutput.Length, deviceData.View, deviceOutput.View);

        // wait for the accelerator to be finished with whatever it's doing
        // in this case it just waits for the kernel to finish.
        accelerator.Synchronize();

        // moved output data from the GPU to the CPU for output to console
        int[] hostOutput = deviceOutput.GetAsArray1D();

        for(int i = 0; i &lt; 50; i++)
        {
            Console.Write(hostOutput[i]);
            Console.Write(" ");
        }

        accelerator.Dispose();
        context.Dispose();
    }
}


The following parts already have detailed explainations in other tutorials:

Context and an accelerator.

Context context = Context.CreateDefault();
Accelerator accelerator = context.GetPreferredDevice(preferCPU: false)
                            .CreateAccelerator(context);


Creates an Accelerator using GetPreferredDevice to hopefully get the “best” device.

Some kind of data and output device memory

MemoryBuffer1D&lt;int, Stride1D.Dense&gt; deviceData = accelerator.Allocate1D(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
MemoryBuffer1D&lt;int, Stride1D.Dense&gt; deviceOutput = accelerator.Allocate1D&lt;int&gt;(10_000);


Loads some example data into the device memory, using dense striding.

int[] hostOutput = deviceOutput.GetAsArray1D();


After we run the kernel we need to get the data as host memory to use it in CPU code.

This leaves just few parts that need further explaination.

Ok now we get to the juicy bits.

The kernel function definition.

static void Kernel(Index1D i, ArrayView&lt;int&gt; data, ArrayView&lt;int&gt; output)
{
    output[i] = data[i % data.Length];
}


Kernels have a few limitations, but basically anything simple works like you would expect.
Primitives and math operations all work with no issues and as shown above ArrayViews
take the place of arrays.

The main limitation comes down to memory. You can only allocate and pass non-nullable value
types that have a set size. Structs that have arrays can cause issues but more on this in
the future struct tutorial. In general I have had little issue working around this. Most
of the change is in how data is stored. As for my classes it was not to hard to change
over to using structs. Anyways, I am digressing there could be a whole series of tutorials
to cover this in detail.

In general:


  no classes (This may change in an upcoming version of ILGPU)
  no references
  no structs with dynamic sizes


The first parameter in a kernel must be its index. A kernel always iterates over some extent, which
is some 1, 2 or 3 dimensional length. Most of the time this is the length of the output MemoryBuffer0.
When you call the kernel this is what you will use, but inside the kernel function the index is the
threadIndex for the kernel.

The other parameters can be structs or ArrayViews. You can have I think 19 parmeters in total. If you
are approching this limit consider packing things into structs. Honestly before 19 parmeters you should pack things
into structs just to keep it organized.

The function is whatever your algorithm needs. Be very careful of race conditions, and remember that the kernel is the *
inside* of a for loop,
not the for loop itself.

Your code structure will greatly affect performance. This is another complex topic but in general
try to avoid branches1 and code that would change in different kernel indices. The thing you are trying
to avoid is threads that are running different instructions, this is called divergence.

The loaded instance of a kernel.

Action&lt;Index1D, ArrayView&lt;int&gt;, ArrayView&lt;int&gt;&gt; loadedKernel = 
    accelerator.LoadAutoGroupedStreamKernel&lt;Index1D, ArrayView&lt;int&gt;, ArrayView&lt;int&gt;&gt;(Kernel);


This is where you precompile the code. It returns an action with the same parameters as the kernel.

When you compile your C# project you compile all the code into IL. This is a version of your code
that is optimized to be run by the dotnet runtime. ILGPU takes this IL and compiles it to a version
that your accelerator can run. This step is done at runtime whenever you load a kernel or if you
explicitly compile it.

If you are having issues compiling code try testing with the CPUAccelerator.

The actual kernel call and device synchronize.

loadedKernel((int)deviceOutput.Length, deviceData.View, deviceOutput.View);
accelerator.Synchronize();


This is the step that does the actual work!

The first step is for ILGPU to finish compiling the kernel, this only happens the first time
the kernel is called, or any time a SpecializedValue&lt;&gt; parameter is changed.

Remember that the index parameter is actually the extent of the kernel when you call it,
but in the actual kernel function it is the index.

Kernel calls are asynchronous. When you call them they are added to a work queue that is controlled by the stream.
So if you call kernel A then kernel B you are guaranteed that A is done before B is started, provided you call them
from the same stream.

Then when you call accelerator.Synchronize(); or stream.Synchronize(); your current thread will wait until
the accelerator (all the streams), or the stream in the case of stream.Synchronize(); is finished executing your
kernels.

See Also:

Simple Kernel Sample

Simple Math Sample


  0
While it is easiest to group kernels based on the extent of the output buffer
it is likely faster to group them based on the hardware that is running the kernel.
For example there is this method of eaking out the most performance from the GPU called a
Grid Stride Loop,
it can help more efficently use the limited memory bandwidth, as well as more efficently use all the warps.



  1
This is general advice that everyone gives for programming now, and I take a bit of issue with it. Branches are NOT
slow.
For the CPU, branches that are unpredictable are slow, and for the GPU, branches that are divergent across the same
warp are slow.
Figuring out if that is the case is hard, which is why the general advice is avoid
branches. Matt Godbolt ran into this issue and describes it well in this talk


`,
            "url": "/docs/02-beginner/03-kernels-and-simple-programs/"
        }
        ,
        
    
        
        {
            "title": "Structs",
            "content": `Structs

As we saw in the memory tutorial programs need data.
However a problem arises when we use ILGPU because it restricts how you can store, move, allocate, and access data.
This is mostly due to the fact that ILGPU is turning C# code into lower level languages.

How do we deal with this?

Data is data is data.


  Note: this example is a console version of the N-body template of my ILGPUView project.
When this is more ready I will include a link, but ILGPUView will allow you to see the result in realtime.


N-Body Example

using ILGPU;
using ILGPU.Algorithms;
using ILGPU.Runtime;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

public static class Program
{
    public static void Main()
    {
        Context context = Context.Create(builder =&gt; builder.Default().EnableAlgorithms());
        Accelerator device = context.GetPreferredDevice(preferCPU: false)
                                  .CreateAccelerator(context);

        int width = 500;
        int height = 500;
        
        // my GPU can handle around 10,000 when using the struct of arrays
        int particleCount = 100; 

        byte[] h_bitmapData = new byte[width * height * 3];

        using MemoryBuffer2D&lt;Vec3, Stride2D.DenseY&gt; canvasData = device.Allocate2DDenseY&lt;Vec3&gt;(new Index2D(width, height));
        using MemoryBuffer1D&lt;byte, Stride1D.Dense&gt; d_bitmapData = device.Allocate1D&lt;byte&gt;(width * height * 3);

        CanvasData c = new CanvasData(canvasData, d_bitmapData, width, height);

        using HostParticleSystem h_particleSystem = new HostParticleSystem(device, particleCount, width, height);

        var frameBufferToBitmap = device.LoadAutoGroupedStreamKernel&lt;Index2D, CanvasData&gt;(CanvasData.CanvasToBitmap);
        var particleProcessingKernel = device.LoadAutoGroupedStreamKernel&lt;Index1D, CanvasData, ParticleSystem&gt;(ParticleSystem.particleKernel);

        //process 100 N-body ticks
        for (int i = 0; i &lt; 100; i++)
        {
            particleProcessingKernel(particleCount, c, h_particleSystem.deviceParticleSystem);
            device.Synchronize();
        }

        frameBufferToBitmap(canvasData.Extent.ToIntIndex(), c);
        device.Synchronize();

        d_bitmapData.CopyToCPU(h_bitmapData);

        //bitmap magic that ignores bitmap striding, be careful some sizes will mess up the striding
        using Bitmap b = new Bitmap(width, height, width * 3, PixelFormat.Format24bppRgb, Marshal.UnsafeAddrOfPinnedArrayElement(h_bitmapData, 0));
        b.Save("out.bmp");
        Console.WriteLine("Wrote 100 iterations of N-body simulation to out.bmp");
    }

    public struct CanvasData
    {
        public ArrayView2D&lt;Vec3, Stride2D.DenseY&gt; canvas;
        public ArrayView1D&lt;byte, Stride1D.Dense&gt; bitmapData;
        public int width;
        public int height;

        public CanvasData(ArrayView2D&lt;Vec3, Stride2D.DenseY&gt; canvas, ArrayView1D&lt;byte, Stride1D.Dense&gt; bitmapData, int width, int height)
        {
            this.canvas = canvas;
            this.bitmapData = bitmapData;
            this.width = width;
            this.height = height;
        }

        public void setColor(Index2D index, Vec3 c)
        {
            if ((index.X &gt;= 0) &amp;&amp; (index.X &lt; canvas.IntExtent.X) &amp;&amp; (index.Y &gt;= 0) &amp;&amp; (index.Y &lt; canvas.IntExtent.Y))
            {
                canvas[index] = c;
            }
        }

        public static void CanvasToBitmap(Index2D index, CanvasData c)
        {
            Vec3 color = c.canvas[index];

            int bitmapIndex = ((index.Y * c.width) + index.X) * 3;

            c.bitmapData[bitmapIndex] = (byte)(255.99f * color.x);
            c.bitmapData[bitmapIndex + 1] = (byte)(255.99f * color.y);
            c.bitmapData[bitmapIndex + 2] = (byte)(255.99f * color.z);

            c.canvas[index] = new Vec3(0, 0, 0);
        }
    }

    public class HostParticleSystem : IDisposable
    {
        public MemoryBuffer1D&lt;Particle, Stride1D.Dense&gt; particleData;
        public ParticleSystem deviceParticleSystem;

        public HostParticleSystem(Accelerator device, int particleCount, int width, int height)
        {
            Particle[] particles = new Particle[particleCount];
            Random rng = new Random();

            for (int i = 0; i &lt; particleCount; i++)
            {
                Vec3 pos = new Vec3((float)rng.NextDouble() * width, (float)rng.NextDouble() * height, 1);
                particles[i] = new Particle(pos);
            }

            particleData = device.Allocate1D(particles);
            deviceParticleSystem = new ParticleSystem(particleData, width, height);
        }

        public void Dispose()
        {
            particleData.Dispose();
        }
    }

    public struct ParticleSystem
    {
        public ArrayView1D&lt;Particle, Stride1D.Dense&gt; particles;
        public float gc;
        public Vec3 centerPos;
        public float centerMass;

        public ParticleSystem(ArrayView1D&lt;Particle, Stride1D.Dense&gt; particles, int width, int height)
        {
            this.particles = particles;

            gc = 0.001f;

            centerPos = new Vec3(0.5f * width, 0.5f * height, 0);
            centerMass = (float)particles.Length;
        }

        public Vec3 update(int ID)
        {
            particles[ID].update(this, ID);
            return particles[ID].position;
        }

        public static void particleKernel(Index1D index, CanvasData c, ParticleSystem p)
        {
            Vec3 pos = p.update(index);
            Index2D position = new Index2D((int)pos.x, (int)pos.y);
            c.setColor(position, new Vec3(1, 1, 1));
        }
    }

    public struct Particle
    {
        public Vec3 position;
        public Vec3 velocity;
        public Vec3 acceleration;

        public Particle(Vec3 position)
        {
            this.position = position;
            velocity = new Vec3();
            acceleration = new Vec3();
        }

        private void updateAcceleration(ParticleSystem d, int ID)
        {
            acceleration = new Vec3();

            for (int i = 0; i &lt; d.particles.Length; i++)
            {
                Vec3 otherPos;
                float mass;

                if (i == ID)
                {
                    //creates a mass at the center of the screen
                    otherPos = d.centerPos;
                    mass = d.centerMass;
                }
                else
                {
                    otherPos = d.particles[i].position;
                    mass = 1f;
                }

                float deltaPosLength = (position - otherPos).length();
                float temp = (d.gc * mass) / XMath.Pow(deltaPosLength, 3f);
                acceleration += (otherPos - position) * temp;
            }
        }

        private void updatePosition()
        {
            position = position + velocity + acceleration * 0.5f;
        }

        private void updateVelocity()
        {
            velocity = velocity + acceleration;
        }

        public void update(ParticleSystem particles, int ID)
        {
            updateAcceleration(particles, ID);
            updatePosition();
            updateVelocity();
        }
    }
}

public struct Vec3
{
    public float x;
    public float y;
    public float z;

    public Vec3(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public static Vec3 operator +(Vec3 v1, Vec3 v2)
    {
        return new Vec3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
    }

    public static Vec3 operator -(Vec3 v1, Vec3 v2)
    {
        return new Vec3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
    }

    public static Vec3 operator *(Vec3 v1, float v)
    {
        return new Vec3(v1.x * v, v1.y * v, v1.z * v);
    }

    public float length()
    {
        return XMath.Sqrt(x * x + y * y + z * z);
    }
}


Ok, this is a long one.

I am not going to explain every line like I did with the kernel example.

I will however explain each struct. Lets start with the easy ones.

Vec3 &amp;&amp; Particle

These are just simple data structures. C# is super nice lets you create member functions and
constructors for structs.

CanvasData

You can just create a struct that holds ArrayViews and pass them to kernels. The issue with this is it seperates the
MemoryBuffer and ArrayView into two different places.
There is nothing wrong with this but I think it leads to messy code. My attempt to fix this is the pattern that
HostParticleSystem uses.

ParticleSystem &amp;&amp; HostParticleSystem

You need to manage both sides of memory, Host and Device. IDisposable allows you to use the super convenient “using”
patterns but requires a class.
The solution is simple, have a host side class that creates a device side struct.

This sample code works… BUT

This code can be MUCH faster.

Array of Structs VS Struct of Arrays

The ParticleSystem struct follows a pattern called an array of structs, because its data is stored in an array of
structs.
In RAM the array of structs(Particles) looks like this:

p0:
    pos
    vel
    accel
p1:
    pos
    vel
    accel


Consider what happens when the GPU loads the pos value from memory. The GPU is loading multiple pieces of data at a
time.
If the loads are “coherent” or how I think of it “chunked together” they will be MUCH faster.

We can do this my simply having 3 arrays. This causes memory to look like this:

pos0
pos1

vel0
vel1

accel0
accel1



This pattern is called a struct of arrays.

As you can see from the example it is much more complex to deal with, but at a particle count of 50,000 it is 5 times
faster.

public class HostParticleSystemStructOfArrays : IDisposable
{
    public int particleCount;
    public MemoryBuffer1D&lt;Vec3, Stride1D.Dense&gt; positions;
    public MemoryBuffer1D&lt;Vec3, Stride1D.Dense&gt; velocities;
    public MemoryBuffer1D&lt;Vec3, Stride1D.Dense&gt; accelerations;
    public ParticleSystemStructOfArrays deviceParticleSystem;

    public HostParticleSystemStructOfArrays(Accelerator device, int particleCount, int width, int height)
    {
        this.particleCount = particleCount;
        Vec3[] poses = new Vec3[particleCount];
        Random rng = new Random();

        for (int i = 0; i &lt; particleCount; i++)
        {
            poses[i] = new Vec3((float)rng.NextDouble() * width, (float)rng.NextDouble() * height, 1);
        }

        positions = device.Allocate1D(poses);
        velocities = device.Allocate1D&lt;Vec3&gt;(particleCount);
        accelerations = device.Allocate1D&lt;Vec3&gt;(particleCount);

        velocities.MemSetToZero();
        accelerations.MemSetToZero();

        deviceParticleSystem = new ParticleSystemStructOfArrays(positions, velocities, accelerations, width, height);
    }

    public void Dispose()
    {
        positions.Dispose();
        velocities.Dispose();
        accelerations.Dispose();
    }
}

public struct ParticleSystemStructOfArrays
{
    public ArrayView1D&lt;Vec3, Stride1D.Dense&gt; positions;
    public ArrayView1D&lt;Vec3, Stride1D.Dense&gt; velocities;
    public ArrayView1D&lt;Vec3, Stride1D.Dense&gt; accelerations;
    public float gc;
    public Vec3 centerPos;
    public float centerMass;

    public ParticleSystemStructOfArrays(ArrayView1D&lt;Vec3, Stride1D.Dense&gt; positions, ArrayView1D&lt;Vec3, Stride1D.Dense&gt; velocities, ArrayView1D&lt;Vec3, Stride1D.Dense&gt; accelerations, int width, int height)
    {
        this.positions = positions;
        this.velocities = velocities;
        this.accelerations = accelerations;
        gc = 0.001f;
        centerPos = new Vec3(0.5f * width, 0.5f * height, 0);
        centerMass = (float)positions.Length;
    }

    private void updateAcceleration(int ID)
    {
        accelerations[ID] = new Vec3();

        for (int i = 0; i &lt; positions.Length; i++)
        {
            Vec3 otherPos;
            float mass;

            if (i == ID)
            {
                //creates a mass at the center of the screen
                otherPos = centerPos;
                mass = centerMass;
            }
            else
            {
                otherPos = positions[i];
                mass = 1f;
            }

            float deltaPosLength = (positions[ID] - otherPos).length();
            float temp = (gc * mass) / XMath.Pow(deltaPosLength, 3f);
            accelerations[ID] += (otherPos - positions[ID]) * temp;
        }
    }

    public static void particleKernel(Index1D index, CanvasData c, ParticleSystemStructOfArrays p)
    {
        Vec3 pos = p.update(index);
        Index2D position = new Index2D((int)pos.x, (int)pos.y);
        c.setColor(position, new Vec3(1, 1, 1));
    }

    private void updatePosition(int ID)
    {
        positions[ID] = positions[ID] + velocities[ID] + accelerations[ID] * 0.5f;
    }

    private void updateVelocity(int ID)
    {
        velocities[ID] = velocities[ID] + accelerations[ID];
    }

    public Vec3 update(int ID)
    {
        updateAcceleration(ID);
        updatePosition(ID);
        updateVelocity(ID);
        return positions[ID];
    }
}


`,
            "url": "/docs/02-beginner/04-structs/"
        }
        ,
        
    
        
        {
            "title": "Memory Buffers & Views",
            "content": `Memory Buffers

MemoryBuffer represent allocated memory regions (allocated arrays) of a given value type on specific accelerators.
Data can be copied to and from any accelerator using sync or async copy operations using Streams.
ILGPU supports linear, 2D and 3D buffers out of the box, whereas nD-buffers can also be allocated and managed using
custom index types.

Note that MemoryBuffers should be disposed manually and cannot be passed to kernels; only views to memory regions
can be passed to kernels.
Should be refers to the fact that all memory buffers will be automatically released by either the GC or disposing the
parent Accelerator instance in ILGPU. However, it is highly recommended to dispose buffer instances manually in
order to have explicit and immediate control over all memory allocations on a GPU device.

class ...
{
    public static void MyKernel(Index1D index, ...)
    {
        // ...
    }

    static void Main(string[] args)
    {
        using var context = Context.CreateDefault();
        using var accelerator = ...;

        // Allocate a memory buffer on the current accelerator device.
        using (var buffer = accelerator.Allocate1D&lt;int&gt;(1024))
        {
            ...
        } // Dispose the buffer after performing all operations
    }
}


Array Views

ArrayViews realize views to specific memory-buffer regions.
Views comprise pointers and length information.
They can be passed to kernels and simplify index computations.

Similar to memory buffers, there are specialized views for 1D, 2D and 3D scenarios.
However, it is also possible to use the generic structure ArrayView&lt;Type, IndexType&gt; to create views to nD-regions.

Accesses on ArrayViews are bounds-checked via Debug assertions.
Hence, these checks are not performed in Release mode, which benefits performance.
You can even enable bounds checks in Release builds by specifying the context flag ContextFlags.EnableAssertions.

class ...
{
    static void MyKernel(Index1D index, ArrayView&lt;int&gt; view1, ArrayView&lt;float&gt; view2)
    {
        ConvertToFloatSample(
            view1.GetSubView(0, view1.Length / 2),
            view2.GetSubView(0, view2.Length / 2));
    }

    static void ConvertToFloatSample(ArrayView&lt;int&gt; source, ArrayView&lt;float&gt; target)
    {
        for (Index i = 0, e = source.Extent; i &lt; e; ++i)
            target[i] = source[i];
    }

    static void Main(string[] args)
    {
        ...
        using (var buffer = accelerator.Allocate1D&amp;lt...&amp;gt(...))
        {
            var mainView = buffer.View;
            var subView = mainView.SubView(0, 1024);
        }
    }
}


Optimized 32-bit and 64-bit Memory Accesses

All addresses on a 64-bit GPU system will be represented using 64-bit addresses under the hood.
The only difference between the accesses is whether you use a 32-bit or a 64-bit offset.
ILGPU differentiates between both scenarios: it uses 32-bit integer math in the case of 32-bit offsets in your program
and 64-bit integer math to compute the offsets in the 64-bit world. However, the actual address computation uses 64-bit
integer math.

In the case of 32-bit offsets it uses ASM sequences like:

mul.wide.u32 %rd4, %r1, 4;
add.u64      %rd3, %rd1, %rd4;


where r1 is the 32-bit offset computed in your kernel program, 4 is the constant size in bytes of your access (an
integer in this case) and rd1 is the source buffer address in your GPU memory in a 64-bit register. However, if the
offset is a 64-bit integer, ILGPU uses an efficient multiply-add operation working on 64-bit integers like:

mad.lo.u64    %rd4, %rd3, 4, %rd1;


When accessing views using 32-bit indices, the resulting index operation will be performed on 32-bit offsets for
performance reasons.
As a result, this operation can overflow when using a 2D 32-bit based Index2D, for instance.
If you already know, that your offsets will not fit into a 32-bit integer, you have to use 64-bit offsets in your
kernel.

If you rely on 64-bit offsets, the emitted indexing operating will be slightly more expensive in terms of register usage
and computational overhead (at least conceptually). The actual runtime difference depends on your kernel program.

Variable Views

A VariableView is a specialized array view that points to exactly one element.
VariableViews are useful since default ‘C# ref’ variables cannot be stored in structures, for instance.

class ...
{
    struct DataView
    {
        public VariableView&lt;int&gt; Variable;
    }

    static void MyKernel(Index1D index, DataView view)
    {
        // ...
    }

    static void Main(string[] args)
    {
        // ...
        using (var buffer = accelerator.Allocate1D&lt;...&gt;(...))
        {
            var mainView = buffer.View;
            var firstElementView = mainView.VariableView(0);
        }
    }
}


`,
            "url": "/docs/03-advanced/01-memory-buffers-and-views/"
        }
        ,
        
    
        
        {
            "title": "Kernels",
            "content": `General Information

Kernels are static functions that can work on value types and can invoke other functions that work on value types.
class (reference) types are currently not supported in the scope of kernels.
Note that exception handling, boxing and recursive programs are also not supported and will be rejected by the ILGPU
compiler.

The type of the first parameter must always be a supported index type in the case of implicitly grouped kernels (see
below).
In the case of explicitly grouped kernels, the first parameter is manually defined by the programmer (see below)
All other parameters are always uniform constants that are passed from the CPU to the GPU via constant memory (in the
parameter address space).
All parameter types must be value types and must not be passed by reference (e.g. via out or ref keywords in C#).

Memory allocation is performed via so called memory buffers, which are classes that are allocated and disposed on the
CPU.
Since they cannot be passed directly to kernels, you can pass views (Span&lt;T&gt; like data structures) to these buffers
by value as kernel arguments.

Note that you must not pass pointers to non-accessible memory regions since these are also passed by value and cannot be
marshalled automatically by ILGPU when launching kernels.

Implicitly Grouped Kernels

Implicitly grouped kernels allow very convenient high-level kernel programming.
They can be launched with automatically configured group sizes (that are determined by ILGPU) or manually defined group
sizes.

Such kernels must not use shared memory, group or warp functionality since there is no guaranteed group size or
thread participation inside a warp/group.
The details of the kernel invocation are hidden from the programmer and managed by ILGPU.
There is no way to access or manipulate the low-level peculiarities from the user’s point of view.
Use explicitly grouped kernels for full control over GPU-kernel dispatching.

class ...
{
    static void ImplicitlyGrouped_Kernel(
        [Index1D|Index2D|Index3D] index,
        [Kernel Parameters]...)
    {
        // Kernel code

        // Use the index parameter to access the global index of i-th thread in the global thread grid
    }
}


Explicitly Grouped Kernels

Explicitly grouped kernels offer the full kernel-programming power and behave similarly to Cuda and OpenCL kernels.
These kernels do not receive an index type as first parameter.
Instead, you can use Grid and Group properties to resolve the indices you are interested in.
Moreover, these kernel offer access to shared memory, Group and other Warp-specific intrinsics.
However, the kernel-dispatch dimensions have to be managed manually.

class ...
{
    static void ExplicitlyGrouped_Kernel(
        [Kernel Parameters]...)
    {
        var globalIndex = Grid.GlobalIndex.X;
        // or
        var globalIndex = Group.IdxX + Grid.IdxX * Group.DimX;

        // Kernel code
    }
}


Loading and Launching Kernels

Kernels have to be loaded by an accelerator first before they can be executed.
See the ILGPU kernel sample for details.
There are two possibilities in general: using the high-level (described here) and
the low-level loading API.
We strongly recommend to use the high-level API that simplifies programming, is less error prone and features automatic
kernel caching and disposal.

An accelerator object offers different functions to load and configure kernels:


  LoadAutoGroupedStreamKernel
Loads an implicitly grouped kernel with an automatically determined group size (uses a the default accelerator stream)
  LoadAutoGroupedKernel
Loads an implicitly grouped kernel with an automatically determined group size (requires an accelerator stream)
  LoadImplicitlyGroupedStreamKernel
Loads an implicitly grouped kernel with a custom group size (uses the default accelerator stream)
  LoadImplicitlyGroupedKernel
Loads an implicitly grouped kernel with a custom group size (requires an accelerator stream)
  LoadStreamKernel
Loads explicitly and implicitly grouped kernels. However, implicitly grouped kernels will be launched with a group
size that is equal to the warp size (uses the default accelerator stream)
  LoadKernel
Loads explicitly and implicitly grouped kernels. However, implicitly grouped kernels will be launched with a group
size that is equal to the warp size (requires an accelerator stream)


Functions following the naming pattern LoadXXXStreamKernel use the default accelerator stream for all operations.
If you want to specify the associated accelerator stream, you will have to use the LoadXXXKernel functions.

Each function returns a typed delegate (a kernel launcher) that can be called in order to invoke the actual kernel
execution.
These launchers are specialized methods that are dynamically generated and specialized for every kernel.
They avoid boxing and realize high-performance kernel dispatching.
In contrast to older versions of ILGPU, all kernels loaded with these functions will be managed by their associated
accelerator instances.

class ...
{
    static void MyKernel(Index1D index, ArrayView&lt;int&gt; data, int c)
    {
        data[index] = index + c;
    }

    static void Main(string[] args)
    {
        ...
        var buffer = accelerator.Allocate1D&lt;int&gt;(1024);

         // Load a sample kernel MyKernel using one of the available overloads
        var kernelWithDefaultStream = accelerator.LoadAutoGroupedStreamKernel&lt;
                     Index1D, ArrayView&lt;int&gt;, int&gt;(MyKernel);
        kernelWithDefaultStream(buffer.Extent, buffer.View, 1);

         // Load a sample kernel MyKernel using one of the available overloads
        var kernelWithStream = accelerator.LoadAutoGroupedKernel&lt;
                     Index1D, ArrayView&lt;int&gt;, int&gt;(MyKernel);
        kernelWithStream(someStream, buffer.Extent, buffer.View, 1);

        ...
    }
}


Note that a kernel-loading operation will trigger a kernel compilation in the case of an uncached kernel.
The compilation step will happen in the background and is transparent for the user.
However, if you require custom control over the low-level kernel-compilation process refer
to Advanced Low-Level Functionality.

Immediate Launching of Kernels

Starting with version v0.10.0, ILGPU offers the ability to
immediately compile and launch kernels via the accelerator methods (similar to those provided by other frameworks).
ILGPU exposes direct Launch and LaunchAutoGrouped methods via the Accelerator class using a new strong-reference
based kernel cache.
This cache is used for the new launch methods only and can be disabled via the Caching(CachingMode.NoKernelCaching)
method of ContextBuilder.

class ...
{
    static void MyKernel(...)
    {

    }

    static void MyImplicitKernel(Index1D index, ...)
    {

    }

    static void Main(string[] args)
    {
        // ...

        // Launch explicitly grouped MyKernel using the default stream
        accl.Launch(MyKernel, &lt; MyKernelConfig &gt;, ...);

        // Launch explicitly grouped MyKernel using the given stream
        accl.Launch(stream, MyKernel, &lt; MyKernelConfig &gt;, ...);

        // Launch implicitly grouped MyKernel using the default stream
        accl.LaunchAutoGrouped(MyImplicitKernel, new Index1D(...), ...);

        // Launch implicitly grouped MyKernel using the given stream
        accl.LaunchAutoGrouped(stream, MyImplicitKernel, new Index1D(...), ...);
    }
}


Retrieving Information about Loaded Kernels

You can get the underlying CompiledKernel instance (see Inside ILGPU) of a kernel launcher
instance via:

var compiledKernel = launcher.GetCompiledKernel();


This allows users to access accelerator-specific properties of particular kernel.
For instance, you can access the PTX assembly code of a Cuda kernel by casting the CompiledKernel instance into
a PTXCompiledKernel and access its PTXAssembly property, as shown below.

var ptxKernel = launcher.GetCompiledKernel() as PTXCompiledKernel;
System.IO.File.WriteAllText("Kernel.ptx", ptxKernel.PTXAssembly);


You can use the DebugSymbols() method of Context.Builder to enable additional information about compiled kernels.
This includes local functions and consumed local and shared memory.
After enabling, you can get the information from a compiled kernel launcher delegate instance via:

// Get kernel information from a kernel launcher instance
var information = launcher.GetKernelInfo();

// Dump all information to the stdout stream
information.DumpToConsole();


`,
            "url": "/docs/03-advanced/02-kernels/"
        }
        ,
        
    
        
        {
            "title": "Shared Memory",
            "content": `ILGPU support both static and dynamic shared memory.
Static shared memory is limited to statically known allocations which have a known size at compile time of the kernel.
The latest ILGPU versions allow the use of dynamic shared memory, which can be specified for each kernel launch
individually.

class ...
{
    static void SharedMemKernel(ArrayView&lt;int&gt; data)
    {
        // Static memory allocation
        var staticMemory = SharedMemory.Allocate&lt;int&gt;&gt;(1024);

        // Use GetDynamic access dynamically specified shared memory
        var dynamicMemory = SharedMemory.GetDynamic&lt;int&gt;&gt;();

        ...

        // Use GetDynamic with a different element type to access
        // the same memory region in a different way
        var dynamicMemory2 = SharedMemory.GetDynamic&lt;double&gt;&gt;();

        ...
    }

    static void ...(...)
    {
        using var context = Context.CreateDefault();
        using var accl = context.CreateCudaAccelerator(0);

        // Create shared memory configuration using a custom element type.
        // Note that this does not need to be the same type that is used in the scope of the kernel.
        // Therefore, the following two configurations will allocate the same amount of shared memory:
        var config = SharedMemoryConfig.RequestDynamic&lt;byte&gt;(&lt;GroupSize&gt; * sizeof(int));
        var config2 = SharedMemoryConfig.RequestDynamic&lt;int&gt;(&lt;GroupSize&gt;);

        ...
        // Pass the shared memory configuration to the kernel configuration
        kernel((&lt;UserGridDim&gt;, &lt;UserGroupDim&gt;, config), buffer.View);
        ...
    }
}


Note that this feature available on CPU, Cuda and OpenCL accelerators.

`,
            "url": "/docs/03-advanced/03-shared-memory/"
        }
        ,
        
    
        
        {
            "title": "Math Functions",
            "content": `The default math functions in .Net are realized with static methods from the Math class.
However, many operations work on doubles by default (like Math.Sin) and there is often no float overload.
This causes many floating-point operations to be performed on 64-bit floats, even when this precision is not required.
.Net Core and .Net Standard compatible frameworks ship the MathF class to overcome this limitation.
ILGPU offers the IntrinsicMath class that supports basic math operations which are supported on all target platforms.
The algorithms library offers the XMath class that has support for all common 32-bit float and 64-bit float math
operations.
Using the 32-bit overloads ensure that the operations are performed on 32-bit floats on the GPU hardware.

Fast Math

Fast-math can be enabled using the Math(MathMode.Fast) method of Context.Builder and enables the use of fast (and
unprecise) math functions.
Unlike previous versions, the fast-math mode applies to all math instructions. Even to default math operations
like x / y.

Forced 32-bit Math

Your kernels might rely on third-party functions that are not under your control.
These functions typically depend on the default .Net Math class, and thus, work on 64-bit floating-point operations.
You can force the use of 32-bit floating-point operations in all cases using the Math(MathMode.Fast32BitOnly) method
of Context.Builder.
Caution: all doubles will be considered as floats to circumvent issues with third-party code.
However, this also affects the address computations of array-view elements.
Avoid the use of this flag unless you know exactly what you are doing.

`,
            "url": "/docs/03-advanced/04-math-functions/"
        }
        ,
        
    
        
        {
            "title": "Dynamically Specialized Kernels",
            "content": `Dynamic specialization allows the definition of kernels that will be specialized/optimized during runtime.
This allows you to define kernels with constant values that are not known at compile time of the kernel or
application.
Without knowing the exact values (or ranges of values) of certain parameters, the compiler’s optimization capabilities
are limited, e.g. with regard to constant propagation and loop unrolling.

Similar functionality can be achieved by using generic types in a clever way.
However, dynamic specialization is much more convenient and easier to use.
Moreover, it is more flexible without leveraging the .Net reflection API to create specialized instances.

Please note that dynamically specialized kernels are precompiled during loading.
The final compilation step occurs during the first call of a new (non-cached) specialized parameter combination.
If a parameter combination was used previously, the corresponding specialized kernel instance is called.

class ...
{
    static void GenericKernel(ArrayView&lt;int&gt; data, int c)
    {
        var globalIndex = Grid.GlobalIndex.X;
        // Generates code that loads c and adds the value 2 at runtime of the kernel
        data[globalIndex] = c + 2;
    }

    static void SpecializedKernel(ArrayView&lt;int&gt; data, SpecializedValue&lt;int&gt; c)
    {
        var globalIndex = Grid.GlobalIndex.X;
        // Generates code that has an inlined constant value
        data[globalIndex] = c + 2; // Will be specialized for every value c
    }

    static void ...(...)
    {
        using var context = Context.CreateDefault();
        using var accl = context.CreateCudaAccelerator(0);

        var genericKernel = accl.LoadStreamKernel&lt;ArrayView&lt;int&gt;, int&gt;(GenericKernel);
        ...
        genericKernel((&lt;UserGridDim&gt;, &lt;UserGroupDim&gt;), buffer.View, 40);

        var specializedKernel = accl.LoadStreamKernel&lt;ArrayView&lt;int&gt;, SpecializedValue&lt;int&gt;&gt;(GenericKernel);
        ...
        specializedKernel((&lt;UserGridDim&gt;, &lt;UserGroupDim&gt;), buffer.View, SpecializedValue.New(40));
        ...
    }
}


`,
            "url": "/docs/03-advanced/05-dynamically-specialized-kernels/"
        }
        ,
        
    
        
        {
            "title": "Debugging & Profiling",
            "content": `The best debugging experience can be achieved with the CPUAccelerator.
Debugging with the software emulation layer is very convenient due to the very good properties of the .Net debugging
environments.
Currently, detailed kernel debugging is only possible with the CPU accelerator.
However, we are currently extending the debugging capabilities to also emulate different GPUs in order to test your
algorithms with “virtual GPU devices” without needing to have direct access to the actual GPU devices (more information
about this feature can be found here.

Assertions on GPU hardware devices can be enabled using the Assertions() method of Context.Builder (disabled by
default when a Debugger is not attached to the application).
Note that enabling assertions using this flag will cause them to be enabled in Release builds as well.
Be sure to disable this flag if you want to get the best runtime performance.

Source-line based debugging information can be turned on via the DebugSymbols() method of Context.Builder (disabled
by default).
Note that only the new portable PBD format is supported.
Enabling debug information is essential to identify problems and catch break points on GPU hardware.
It is also very useful for kernel profiling as you can link the profiling insights to your source lines.
You may want to disable inlining via Inlining() to significantly increase the accuracy of your debugging information
at the expense cost of runtime performance.

Note that the inspection of variables, registers, and global memory on GPU hardware is currently not supported.

Named Kernels

PR #401 added support for using either the .Net function name or a custom
name as the entry point for each Cuda/OpenCL kernel. This simplifies profiling and debugging because multiple kernels
then have different names.

Note that custom kernel names have to consist of ASCII characters only. Other characters will be automatically mapped
to ‘_’ in the assembly code.

PrintF-Like Debugging

Cuda and OpenCL provide the ability to print/output basic values into the console output stream for debugging. This is
especially useful for device-specific concurrency problems that need to be analyzed without changing environment
settings. Starting with v0.10.0, ILGPU provides platform
independent support for Interop.Write and Interop.WriteLine that accept (very) basic .Net-like format specifiers of
the form Test output {0} and test output {1}.

This string can be formatted to Test output 1.0 and test output -45 using:

Interop.Write("Test output {0} and test output {1}", 1.0, -45);


Note that this functionality is enabled by default when a Debugger is attached to the application. For this to work
without the Debugger, or in Release mode, call the .IOOperations() method of Context.Builder. Be sure to remove this
flag if you want to get the best runtime performance.

`,
            "url": "/docs/03-advanced/06-debugging-and-profiling/"
        }
        ,
        
    
        
        {
            "title": "Inside ILGPU",
            "content": `Optimizations and Compile Time

ILGPU features a modern parallel processing, transformation and compilation model.
It allows parallel code generation and transformation phases to reduce compile time and improve overall performance.

The global optimization process can be controlled with the enumeration OptimizationLevel.
This level can be specified by passing the desired level to the Optimize method of Context.Builder.
If the optimization level is not explicitly specified, the level is automatically set to OptimizationLevel.O1.

The OptimizationLevel.O2 level uses additional transformations that increase compile time but yield potentially better
GPU code.
For best performance, it is recommended using this mode in Release builds only.

Internal Caches

ILGPU uses a set of internal caches to speed up the compilation process.
The KernelCache is based on WeakReferences and its own GC thread to avoid memory leaks.
As soon as a kernel is disposed by the .Net GC, the ILGPU GC thread can release the associated data structures.
Although each Accelerator instance is assigned a MemoryBufferCache instance, ILGPU does not use this cache anywhere.
It was added to help users write custom accelerator extensions that require temporary memory.
If you do not use the corresponding MemoryBufferCaches, you should not get into trouble regarding caching.

Use Context.ClearCache(ClearCacheMode.Everything) to clear all internal caches to recover allocated memory.
In addition, each accelerator has its own cache for type information and kernel arguments.
Use Accelerator.ClearCache(ClearCacheMode.Everything) to clear the cache on the desired accelerator.
Note that clearing the caches is not thread-safe in general; you have to ensure that there are no running
background threads trying to compile/load/allocate ILGPU related objects while clearing the caches.

Backends

A Backend represents target-specific code-generation functionality for a specific target device.
It can be used to manually compile kernels for a specific platform.

Note that you do not have to create custom backend instances on your own when using the ILGPU runtime.
Accelerators already carry associated and configured backends that are used for high-level kernel loading.

IRContext

An IRContext manages and caches intermediate-representation (IR) code, which can be reused during the compilation
process.
It can be created using a general ILGPU Context instance.
An IRContext is not tied to a specific Backend instance and can be reused across different hardware architectures.

Note that the main ILGPU Context already has an associated IRContext that is used for all high-level kernel-loading
functions.
Consequently, users are not required to manage their own contexts in general.

Compiling Kernels

Kernels can be compiled manually by requesting a code-generation operation from the backend yielding a CompiledKernel
object.
The resulting kernel object can be loaded by an Accelerator instance from the runtime system.
Alternatively, you can cast a CompiledKernel object to its appropriate backend-specific counterpart method in order to
access the generated and target-specific assembly code.

Note that the default MSIL backend does not provide additional insights, since the ILBackend does not require custom
assembly code.

We recommend that you use the high-level kernel-loading concepts of ILGPU instead of the low-level
interface.

Loading Compiled Kernels

Compiled kernels have to be loaded by an accelerator first before they can be executed.
See
the ILGPU low-level kernel sample
for details.
Note: manually loaded kernels should be disposed manually to have full control over the lifetime of the kernel
function in driver memory. You can also rely on the .Net GC to dispose kernels in the background.

An accelerator object offers different functions to load and configure kernels:


  LoadAutoGroupedKernel
Loads an implicitly grouped kernel with an automatically determined group size
  LoadImplicitlyGroupedKernel
Loads an implicitly grouped kernel with a custom group size
  LoadKernel
Loads explicitly and implicitly grouped kernels. However, implicitly grouped kernels will be launched with a group
size that is equal to the warp size


Direct Kernel Launching

A loaded kernel can be dispatched using the Launch method.
However, the dispatch method takes an object-array as an argument, all arguments are boxed upon invocation and there is
not type-safety at this point.
For performance reasons, we strongly recommend the use of typed kernel launchers that avoid boxing.

class ...
{
    static void MyKernel(Index1D index, ArrayView&lt;int&gt; data, int c)
    {
        data[index] = index + c;
    }

    static void Main(string[] args)
    {
        ...
        var buffer = accelerator.Allocate&lt;int&gt;(1024);

        // Load a sample kernel MyKernel
        var compiledKernel = backend.Compile(...);
        using (var k = accelerator.LoadAutoGroupedKernel(compiledKernel))
        {
            k.Launch(buffer.Extent, buffer.View, 1);

            ...

            accelerator.Synchronize();
        }

        ...
    }
}


Typed Kernel Launchers

Kernel launchers are delegates that provide an alternative to direct kernel invocations.
These launchers are specialized methods that are dynamically generated and specialized for every kernel.
They avoid boxing and
realize high-performance kernel dispatching
.
You can create a custom kernel launcher using the CreateLauncherDelegate method.
It Creates a specialized launcher for the associated kernel.
Besides all required kernel parameters, it also receives a parameter of type AcceleratorStream as an argument.

Note that high-level API kernel loading functionality that simply returns a launcher delegate instead of a kernel
object.
These loading methods work similarly to the these versions, e.g. LoadAutoGroupedStreamKernel loads a kernel with a
custom delegate type that is linked to the default accelerator stream.

class ...
{
    static void MyKernel(Index1D index, ArrayView&lt;int&gt; data, int c)
    {
        data[index] = index + c;
    }

    static void Main(string[] args)
    {
        ...
        var buffer = accelerator.Allocate&lt;int&gt;(1024);

        // Load a sample kernel MyKernel
        var compiledKernel = backend.Compile(...);
        using (var k = accelerator.LoadAutoGroupedKernel(compiledKernel))
        {
            var launcherWithCustomAcceleratorStream =
                k.CreateLauncherDelegate&lt;AcceleratorStream, Index1D, ArrayView&lt;int&gt;&gt;();
            launcherWithCustomAcceleratorStream(someStream, buffer.Extent, buffer.View, 1);

            ...
        }

        ...
    }
}


`,
            "url": "/docs/03-advanced/07-inside-ilgpu/"
        }
        ,
        
    
        
        {
            "title": "v0.8.X to v0.9.X",
            "content": `General

In order to support 64-bit memory buffers and array views, we have introduced the LongIndexX types that represent (
multidimensional) 64-bit index value.
We have changed the return types of all Length and LengthInBytes properties from int to long.
This might affect your code base, if you work with explicit length information from views and buffers.
Furthermore, if you are using custom index, view or memory buffer implementations, you have to adapt your code to comply
with the latest interface definitions or IArrayView, IGenericIndex and IMemoryBuffer.

It is possible to use 32-bit IndexX values and 64-bit LongIndexX values for accessing generic array views.
This allows programmers to decide whether they want to favor performance (fast 32-bit indexing) or large memory views (
slower 64-bit indexing that consumes more 64-bit registers).
Note that specialized array views working on 32-bit indexes will accept 32-bit IndexX instances only.

In order to provide backwards compatibility, it is possible to implicitly convert a System.Int64 value into
an Index1 value.
Each conversion operator performs bounds checks that will trigger an assertion in the case on an overflow.
This allows you to launch your kernels using accesses to Length and Extent properties working on 64-bit integer
values.

`,
            "url": "/docs/04-upgrade-guides/01-v0-8-x-to-v0-9-x/"
        }
        ,
        
    
        
        {
            "title": "v0.8.0 to v0.8.1",
            "content": `General Notes

All implicitly grouped kernel launchers have been updated with additional overloads.
These new methods output additional kernel statistics (e.g. the amount of local memory used in bytes).
Detailed information can be enabled with the context flag ContextFlags.EnableKernelStatistics.
This information is highly similar to the output of ptxas -v.

The new version features an IR verifier that ensures the integrity of the internal IR. It can be enabled via the context
flag ContextFlags.EnableVerifier.
This is normally not required. However, if you encounter any problems that might be related to a compiler issue, you can
enable the verifier.

Optimization Levels

A new optimization level O2 has been added. It is disabled by default, but can be enabled via OptimizationLevel.O2.

Earlier versions contained Debug and Release versions of the ILGPU compiler.
The new version contains only the Release build.
This significantly improves compile time and simplifies the integration with other third-party libraries.
If you want to enable intrinsic assertions you have to build the compiler from source.
Alternatively, you can use the IR verifier to ensure the validity of a particular IR program.

`,
            "url": "/docs/04-upgrade-guides/02-v0-8-0-to-v0-8-1/"
        }
        ,
        
    
        
        {
            "title": "v0.7.X to v0.8.X",
            "content": `General Notes

All explicitly grouped kernel launchers have been updated.
This simplifies programming and feels more natural for most kernel developers familiar with Cuda and OpenCL.
New static Group and Grid properties provide convenient access to grid and group indices.

Dynamic partial evaluation allows to create specialized kernels that are automagically compiled for you.
Use the structure type SpecializedValue&lt;T&gt; on kernel parameters to enable specialization of values at runtime.
Note that these values must support the IEquatable interface for them to be cached correctly.
As soon as a value is found (which could not be found in the cache), the kernel is recompiled in the background with the
new specialized value.

Note that the ILGPU.Index type is now considered obsolete because there is a name ambiguity between ILGPU.Index
and System.Index.
Please update your code to use the new type ILGPU.Index1 instead.
Note further that these index types might be removed in the future.

New Kernel Launchers

In previous versions, it was necessary to have a kernel parameter of type GroupedIndex for explicitly grouped kernels.
Accesses to the current group and grid indices were only possible by accessing this parameter.
Alternative methods to access group and grid indices were introduced in v0.7.X, in order to create helper methods that
can directly access those properties.
From a software-engineering point of view, this could have been considered the same functionality with two different
flavors.
This issue was corrected in v0.8.
It also simplifies programming for Cuda and OpenCL developers.

class ...
{
    static void OldKernel(GroupedIndex index, ArrayView&lt;int&gt; data)
    {
      var globalIndex = index.ComputeGlobalIndex();
      data[globalIndex] = 42;
    }

    static void NewKernel(ArrayView&lt;int&gt; data)
    {
      var globalIndex = Grid.GlobalIndex.X;
      // or
      var globalIndex = Group.IdxX + Grid.IdxX * Group.DimX;

      data[globalIndex] = 42;
    }

    static void ...(...)
    {
        using var context = new Context();
        using var accl = new CudaAccelerator(context);

        // Old way
        var oldKernel = accl.LoadStreamKernel&lt;GroupedIndex, ArrayView&lt;int&gt;&gt;(OldKernel);
        ...
        oldKernel(new GroupedIndex(&lt;GridDim&gt;, &lt;GroupDim&gt;), buffer.View);

        // New way
        var newKernel = accl.LoadStreamKernel&lt;ArrayView&lt;int&gt;&gt;(NewKernel);
        ...
        newKernel((&lt;GridDim&gt;, &lt;GroupDim&gt;), buffer.View);
        // Or
        newKernel(new KernelConfig(&lt;GridDim&gt;, &lt;GroupDim&gt;), buffer.View);

        // Or (using dynamic shared memory)
        var sharedMemConfig  = SharedMemoryConfig.RequestDynamic&lt;int&gt;(&lt;GroupDim&gt;);
        newKernel((&lt;GridDim&gt;, &lt;GroupDim&gt;, sharedMemConfig), buffer.View);

        ...
    }
}


Dynamic Shared Memory

Shared memory has long been supported by ILGPU.
However, it was limited to statically known allocations which have a known size at compile time of the kernel.
The new ILGPU version allows the use of dynamic shared memory, which can be specified for each kernel launch
individually.

Note that this feature is only available with CPU and Cuda accelerators.
OpenCL users can use the Dynamic Specialization features to emulate this feature.

class ...
{
    static void SharedMemKernel(ArrayView&lt;int&gt; data)
    {
        // Use GetDynamic access dynamically specified shared memory
        var dynamicMemory = SharedMemory.GetDynamic&lt;int&gt;&gt;();

        ...

        // Use GetDynamic with a different element type to access
        // the same memory region in a different way
        var dynamicMemory2 = SharedMemory.GetDynamic&lt;double&gt;&gt;();

        ...
    }

    static void ...(...)
    {
        using var context = new Context();
        using var accl = new CudaAccelerator(context);

        // Create shared memory configuration using a custom element type.
        // Note that this does not need to be the same type that is used in the scope of the kernel.
        // Therefore, the following two configurations will allocate the same amount of shared memory:
        var config = SharedMemoryConfig.RequestDynamic&lt;byte&gt;(&lt;GroupSize&gt; * sizeof(byte));
        var config2 = SharedMemoryConfig.RequestDynamic&lt;int&gt;(&lt;GroupSize&gt;);

        ...
        // Pass the shared memory configuration to the kernel configuration
        kernel((&lt;GridDim&gt;, &lt;GroupDim&gt;, config), buffer.View);
        ...
    }
}


Dynamic Specialization

Dynamic specialization allows the definition of kernels that will be specialized/optimized during runtime.
This allows you to define kernels with constant values that are not known at compile time of the kernel or
application.
Without knowing the exact values (or ranges of values) of certain parameters, the compiler’s optimization capabilities
are limited, e.g. with regard to constant propagation and loop unrolling.

Similar functionality can be achieved by using generic types in a clever way.
However, dynamic specialization is much more convenient and easier to use.
Moreover, it is more flexible without leveraging the .Net reflection API to create specialized instances.

Please note that dynamically specialized kernels are precompiled during loading.
The final compilation step occurs during the first call of a new (non-cached) specialized parameter combination.
If a parameter combination was used previously, the corresponding specialized kernel instance is called.

class ...
{
    static void GenericKernel(ArrayView&lt;int&gt; data, int c)
    {
        var globalIndex = Grid.GlobalIndex.X;
        // Generates code that loads &lt;i&gt;c&lt;/i&gt; and adds the value &lt;i&gt;2&lt;/i&gt; at runtime of the kernel
        data[globalIndex] = c + 2;
    }

    static void SpecializedKernel(ArrayView&lt;int&gt; data, SpecializedValue&lt;int&gt; c)
    {
        var globalIndex = Grid.GlobalIndex.X;
        // Generates code that has an inlined constant value
        data[globalIndex] = c + 2; // Will be specialized for every value &lt;i&gt;c&lt;/i&gt;
    }

    static void ...(...)
    {
        using var context = new Context();
        using var accl = new CudaAccelerator(context);

        var genericKernel = accl.LoadStreamKernel&lt;ArrayView&lt;int&gt;, int&gt;(GenericKernel);
        ...
        genericKernel((&lt;GridDim&gt;, &lt;GroupDim&gt;), buffer.View, 40);

        var specializedKernel = accl.LoadStreamKernel&lt;ArrayView&lt;int&gt;, SpecializedValue&lt;int&gt;&gt;(GenericKernel);
        ...
        specializedKernel((&lt;GridDim&gt;, &lt;GroupDim&gt;), buffer.View, SpecializedValue.New(40));
        ...
    }
}


New Grid &amp; Group Properties

The new version adds revised static Grid and Group properties.
The cumbersome Index(X|Y|Z) and Dimension(X|Y|Z) properties are now considered obsolete.
The new (much more convenient) properties Idx(X|Y|Z) and Dim(X|Y|Z) are available to replace the old ones.
Note that the Index and Dimension properties are still available to accessing all three dimensions of the
dispatched Grids and Groups.

Please update all uses in your programs, as the old properties will be removed in a future version.

class ...
{
    static void GenericKernel(ArrayView&lt;int&gt; data, int c)
    {
        var globalIndex = Grid.GlobalIndex.X;
        // Generates code that loads &lt;i&gt;c&lt;/i&gt; and adds the value &lt;i&gt;2&lt;/i&gt; at runtime of the kernel
        data[globalIndex] = c + 2;
    }

    static void SpecializedKernel(ArrayView&lt;int&gt; data, SpecializedValue&lt;int&gt; c)
    {
        var globalIndex = Grid.GlobalIndex.X;
        // Generates code that has an inlined constant value
        data[globalIndex] = c + 2; // Will be specialized for every value &lt;i&gt;c&lt;/i&gt;
    }

    static void ...(...)
    {
        using var context = new Context();
        using var accl = new CudaAccelerator(context);

        var genericKernel = accl.LoadStreamKernel&lt;ArrayView&lt;int&gt;, int&gt;(GenericKernel);
        ...
        genericKernel((&lt;GridDim&gt;, &lt;GroupDim&gt;), buffer.View, 40);

        var specializedKernel = accl.LoadStreamKernel&lt;ArrayView&lt;int&gt;, SpecializedValue&lt;int&gt;&gt;(GenericKernel);
        ...
        specializedKernel((&lt;GridDim&gt;, &lt;GroupDim&gt;), buffer.View, SpecializedValue.New(40));
        ...
    }
}


Unmanaged Type Constraints

The new version leverages the newly available umanaged structure type constraint in C# in favor of the struct
generic type constraint on buffers, view and functions.
This ensures that a certain structure has the same representation in managed and unmanaged memory. This in turn allows
ILGPU to generate faster code and simplifies the development process:
The compiler can immediately emit an error message at compile time when a type does not match this particular *
unmanaged* type constraint.

In approx. 90% of all cases you do not need to do anything. However, if you use (or instantiate) generic types that
should be considered unmanaged, you have to enable language version 8.0 of C#.
Please note that it is also safe to do for programs running on .Net 4.7 or .Net 4.8.

`,
            "url": "/docs/04-upgrade-guides/03-v0-7-x-to-v0-8-x/"
        }
        ,
        
    
        
        {
            "title": "v0.6.X to v0.7.X",
            "content": `General Notes

A new OpenCL backend has been added that supports OpenCL C 2.0 (or higher) compatible GPUs.
The OpenCL backend does not require an OpenCL SDK to be installed/configured.
There is the possibility to query all supported OpenCL accelerators via CLAccelerator.CLAccelerators.
Since NVIDIA GPUs typically does not support OpenCL C 2.0 (or higher), they are usually not contained in this list.
However, if you still want to access those devices via the OpenCL API you can query CLAccelerators.AllCLAccelerators.
Note that the global list of all accelerators Accelerator.Accelerators will contain supported accelerators only.
It is highly recommended to use the CudaAccelerator class for NVIDIA GPUs and the CLAccelerator class for Intel and
AMD GPUs.
Furthermore, it is not necessary to worry about native library dependencies regarding OpenCL (except, of course, for the
actual GPU drivers).

The XMath class has been removed as it contained many software implementations for different platforms that are not
related to the actual ILGPU compiler.
However, there are several math functions that are supported on all platforms which are still exposed via the
new IntrinsicMath class.
There is also a class IntrinsicMath.CPU which contains implementations for all math functions for the CPUAccelerator
.
Please note that these functions are not supported on other accelerators except the CPUAccelerator.
If you want to use the full range of math functions refer to the XMath class of the ILGPU.Algorithms library.

The new version of the ILGPU.Algorithms library offers support for a set of commonly used algorithms (like Scan or
Reduce).
Moreover, it offers GroupExtensions and WarpExtensions to support group/warp-wide reductions or prefix sums within
kernels.

New Algorithms Library

The new ILGPU.Algorithms library comes in a separate nuget package.
In order to use any of the exposed group/warp/math extensions you have to enable the library.
This setups all internal ILGPU hooks and custom code-generators to emit code that realizes the extensions in the right
places.
This is achieved by using the new extension and intrinsic API.

using ILGPU.Algorithms;
class ...
{
    static void ...(...)
    {
        using var context = new Context();

        // Enable all algorithms and extension methods
        context.EnableAlgorithms();

        ...
    }
}


Math Functions

As mentioned here, the XMath class has been removed from the actual GPU compiler framework.
Leverage the IntrinsicMath class to use math functions that are available on all supported accelerators.
If you want to access all math functions use the newly designed XMath class of the ILGPU.Algorithms library.

class ...
{
    static void ...(...)
    {
        // Old way (obsolete and no longer supported)
        float x = ILGPU.XMath.Sin(...);

        // New way
        // 1) Don't forget to enable algorithm support ;)
        context.EnableAlgorithms();
        
        // 2) Use the new XMath class
        float x = ILGPU.Algorithms.XMath.Sin(...);
    }
}


Warp &amp; Group Intrinsics

Previous versions of ILGPU had several warp-shuffle overloads to expose the native warp and group intrinsics to the
programmer.
However, these functions are typically available for int and float data types.
More complex or larger types required programming of custom IShuffleOperation interfaces that had to be passed to the
shuffle functions.
This inconvenient way of programming is no longer required.
The new warp and group intrinsics support generic data structures.
ILGPU will automatically generate the required code for every target platform and use case.

The intrinsics Group.Broadcast and Warp.Broadcast have been added.
In contrast to Warp.Shuffle, the Warp.Broadcast intrinsic requires that all participating threads read from the same
lane.
Warp.Shuffle supports different source lanes in every thread.
Group.Broadcast works like Warp.Broadcast, but for all threads in a group.

class ...
{
    static void ...(...)
    {
        ComplexDataType y = ...;
        ComplexDataType x = Warp.Shuffle(y, threadIdx);

        ...

        ComplexDataType y = ...;
        ComplexDataType x = Group.Broadcast(y, groupIdx);
    }
}


Grid &amp; Group Indices

It is no longer required to access grid and group indices via the GroupedIndex(|2|3) index parameter of a kernel.
Instead, you can access the static properties Grid.Index(X|Y|Z) and Group.Index(X|Y|Z) from every function in the
scope of a kernel.
This simplifies programming of helper methods significantly.
Furthermore, this also feels natural to experienced Cuda and OpenCL developers.

class ...
{
    static void ...(GroupedIndex index)
    {
        // Common ILGPU way (still supported)
        int gridIdx = index.GridIdx;
        int groupIdx = index.GroupIdx;

        // New ILGPU way
        int gridIdx = Grid.IndexX;
        int groupIdx = Group.IndexX;
    }
}


`,
            "url": "/docs/04-upgrade-guides/04-v0-6-x-to-v0-7-x/"
        }
        ,
        
    
        
        {
            "title": "v0.3.X to v0.5.X",
            "content": `ArrayViews and VariableViews

The ArrayView and VariableView structures have been adapted to the C# ‘ref’ features.
This renders explicit Load and Store methods obsolete.
In addition, all methods that accept VariableView&lt;X&gt; parameter types have been adapted to the parameter types ref X.
This applies, for example, to all methods of the class Atomic.

class ...
{
    static void ...(...)
    {
        // Old way (obsolete and no longer supported)
        ArrayView&lt;int&gt; someView = ...
        var variableView = someView.GetVariableView(X);
        Atomic.Add(variableView);
        ...
        variableView.Store(42);

        // New way
        ArrayView&lt;int&gt; someView = ...
        Atomic.Add(ref someView[X]);
        ...
        someView[X] = 42;

        // or
        ref var variable = ref someView[X];
        variable = 42;

        // or
        var variableView = someView.GetVariableView(X);
        variableView.Value = 42;
    }
}


Shared Memory

The general concept of shared memory has been redesigned.
The previous model required SharedMemoryAttribute attributes on specific parameters that should be allocated in shared
memory.
The new model uses the static class SharedMemory to allocate this kind of memory procedurally in the scope of kernels.
This simplifies programming, kernel-delegate creation and enables non-kernel methods to allocate their own pool of
shared memory.

Note that array lengths must be constants in this ILGPU version.
Hence, a dynamic allocation of shared memory is currently not supported.

The kernel loader methods LoadSharedMemoryKernelX and LoadSharedMemoryStreamKernelX have been removed.
They are no longer required, since a kernel does not have to declare its shared memory allocations in the form of
additional parameters.

class ...
{
    static void SharedMemoryKernel(GroupedIndex index, ...)
    {
        // Allocate an array of 32 integers
        ArrayView&lt;int&gt; sharedMemoryArray = SharedMemory.Allocate&lt;int&gt;(32);

        // Allocate a single variable of type long in shared memory
        ref long sharedMemoryVariable = ref SharedMemory.Allocate&lt;long&gt;();

        ...
    }
}


CPU Debugging

Starting a kernel in debug mode is a common task that developers go through many times a day.
Although ILGPU has been optimized for performance, you may not wait a few milliseconds every time you start your program
to debug a kernel on the CPU.
For this reason, the context flag ContextFlags.SkipCPUCodeGeneration has been added.
It suppresses IR code generation for CPU kernels and uses the .Net runtime directly.
Warning: This avoids general kernel analysis/verification checks. It should only be used by experienced users.

Internals

The old LLVM-based concept of CompileUnit objects is obsolete and has been replaced by a completely new IR.
The new IR leverages IRContext objects to manage IR objects that are derived from the class ILGPU.IR.Node.
Unlike previous versions, an IRContext is not tied to a specific Backend instance and can be reused accross
different hardware architectures.

The global optimization process can be controlled with the enumeration OptimizationLevel.
This level can be specified by passing the desired level to the ILGPU.Context constructor.
If the optimization level is not explicitly specified, the level is determined by the current build mode (either Debug
or Release).

`,
            "url": "/docs/04-upgrade-guides/05-v0-3-x-to-v0-5-x/"
        }
        ,
        
    
        
        {
            "title": "v0.1.X to v0.2.X",
            "content": `General Upgrade

If you rely on the LightningContext class (of ILGPU.Lightning v0.1.X) for high-level kernel loading or other
high-level operations, you will have to adapt your projects to the API changes.
The new API does not require a LightningContext instance.
Instead, all operations are extension methods to the ILGPU Accelerator class.
This simplifies programming and makes the general API more consistent.
Furthermore, kernel caching and convenient kernel loading are now included in the ILGPU runtime system and do not
require any ILGPU.Lightning operations.
Moreover, if you make use of the low-level kernel-loading functionality of the ILGPU runtime system (in order to avoid
additional library dependencies to ILGPU.Lightning), you will also benefit from the new API changes.

Note that all functions from v0.1.X will still work to ensure backwards compatibility.
However, they will be removed in future versions.

The Obsolete Lightning Context

The LightningContext class is obsolete and will be removed in future versions.
It encapsulated an ILGPU Accelerator instance and provided useful kernel caching and loading features.
Moreover, all extensions functions (like sorting, for example) were based on a LightningContext.

We recommend that you replace all occurrences of a LightningContext with an ILGPU Accelerator.
Furthermore, change the LightningContext creation code with an appropriate accelerator construction from ILGPU.
Note that kernel caching and loading are now natively provided by an Accelerator object.

class ...
{
    public static void Main(string[] args)
    {
        // Create the required ILGPU context
        using (var context = new Context())
        {
            // Deprecated code snippets for creating a LightningContext
            var ... = LightningContext.CreateCPUContext(context);
            var ... = LightningContext.CreateCudaContext(context);
            var ... = LightningContext.Create(context, acceleratorId);

            // New version: use default ILGPU accelerators and perform
            // all required operations on an accelerator instance.
            var ... = new CPUAccelerator(context);
            var ... = new CudaAccelerator(context);
            var ... = Accelerator.Create(context, acceleratorId);


            // Old sample for an Initialize command
            var lc = LightningContext.Create(context, ...);
            lc.Initialize(targetView);

            // New version
            var accl = Accelerator.Create(context, acceleratorId);
            accl.Initialize(targetView);
        }
    }
}


`,
            "url": "/docs/04-upgrade-guides/06-v0-1-x-to-v0-2-x/"
        }
        ,
        
    
        
    
];


const searchIndex = lunr(function () {
    this.ref('url')
    this.field('title');
    this.field('content');
    searchDocuments.forEach(function (doc) {
        this.add(doc);
    }, this);
})
/***** Lunr Index *****/


/***** TypeAhead *****/
function findDocumentByFieldValue(field, value) {
    const results = searchDocuments.find(obj => {
        return obj[field] === value
    });
    if (results.length === 0) {
        return undefined;
    }else if (results.length === 1) {
        return results[0];
    }else {
        return results;
    }
}


function findMatches(query, callback) {
    const matches = searchIndex.search(query).map(({ ref }) => {
        return findDocumentByFieldValue('url', ref);
    });
    callback(matches);
}

$('#search .typeahead').typeahead({
        minLength: 1,
        classNames: {
            menu: 'bg-white',
            cursor: 'text-primary',
        }
    },
    {
        name: 'documentation',
        source: findMatches,
        display: 'title',
        limit: 3,
        templates: {
            empty: `<div class="empty-message">
                No matches found
                </div>`,
            suggestion: (s) => (`<div role="button">${s.title}</div>`),
        }
    });


$('.typeahead').bind('typeahead:select', function(ev, suggestion) {
    if (suggestion?.url) {
        window.location.href = suggestion.url;
    }
});
/***** TypeAhead *****/

