using System;
using System.Text;

namespace puzzles.macattack.sha256
{
    public static class ByteHelper
    {
        public static byte[] ToBigEndianByteArray(this uint value)
        {
            return new byte[] {
                (byte)(value >> 24),
                (byte)(value >> 16 & 0xff),
                (byte)(value >> 8 & 0xff),
                (byte)(value & 0xff)
            };
        }

        public static uint[] BigEndianByteArrayToUintArray(byte[] source, int sourceIndex, int numberOf32BitWords)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (sourceIndex < 0 || sourceIndex >= source.Length)
                throw new IndexOutOfRangeException();

            if (sourceIndex + numberOf32BitWords * 4 > source.Length)
                throw new ArgumentOutOfRangeException(nameof(numberOf32BitWords));

            var block = new uint[numberOf32BitWords];

            for (int i = 0; i < numberOf32BitWords; i++)
            {
                block[i] =   ((uint)source[sourceIndex + 4*i]) << 24
                           | ((uint)source[sourceIndex + 4*i + 1]) << 16
                           | ((uint)source[sourceIndex + 4*i + 2]) << 8
                           | ((uint)source[sourceIndex + 4*i + 3]);
            }

            return block;
        }

        public static string ToHexString(this byte[] byteArray)
        {
            var sb = new StringBuilder();

            foreach (var @byte in byteArray)
                sb.AppendFormat("{0:x2}", @byte);

            return sb.ToString();
        }
    }
}
