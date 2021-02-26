using System.Collections.Generic;

namespace ILGPU.Tools
{
    public interface ICommand
    {
        public void Run(string[] args);
    }
}
