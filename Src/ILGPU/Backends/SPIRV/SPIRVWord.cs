﻿using System;

namespace ILGPU.Backends.SPIRV
{
    public struct SPIRVWord
    {
        private uint data;
        private const int BytesPerWord = sizeof(uint);

        public SPIRVWord(uint value)
        {
            data = value;
        }

        public static SPIRVWord FromBytes(ReadOnlySpan<byte> bytes)
        {
            if (bytes.Length > BytesPerWord)
            {
                throw new ArgumentException(
                    "The provided span must be at most 4 bytes long.",
                    nameof(bytes));
            }

            return new SPIRVWord(BitConverter.ToUInt32(bytes));
        }

        public static SPIRVWord[] ManyFromBytes(ReadOnlySpan<byte> bytes)
        {
            var words = new SPIRVWord[(bytes.Length - 1) / BytesPerWord + 1];

            for (int i = 0; i < words.Length; i++)
            {
                words[i] = FromBytes(bytes.Slice(i * 4, 4));
            }

            return words;
        }

        public byte[] ToByteArray() => BitConverter.GetBytes(data);
    }
}
