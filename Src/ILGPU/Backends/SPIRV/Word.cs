namespace ILGPU.Backends.SPIRV
{
    public struct Word
    {
        public uint Value { get; }

        public Word(uint val)
        {
            Value = val;
        }

        public Word(SplitWord splitWord)
        {
            // Less bits provided for demonstration
            // In reality we would go from 16 to 32 bits not 4 to 8
            // 4 bit High:         0001
            // 4 bit Low:          0010
            // 8 bit High:    0000 0001
            // 8 bit Low:     0000 0010
            // Shifted High:  0001 0000
            // Bitwise Or:    0001 0010

            uint high = splitWord.HighEndValue;
            uint low = splitWord.LowEndValue;

            uint shiftedHigh = high << 16;
            Value = shiftedHigh | low;
        }
    }
}
