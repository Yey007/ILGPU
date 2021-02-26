namespace ILGPU.Backends.SPIRV
{
    public struct SplitWord
    {
        public ushort HighEndValue { get; }
        public ushort LowEndValue { get; }

        public SplitWord(ushort high, ushort low)
        {
            HighEndValue = high;
            LowEndValue = low;
        }

        public SplitWord(ushort wordCount, SPIRVHeaders.Op op)
        {
            HighEndValue = wordCount;
            LowEndValue = (ushort) op;
        }
    }
}
