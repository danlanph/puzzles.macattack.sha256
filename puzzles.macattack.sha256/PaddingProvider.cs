using System;
namespace puzzles.macattack.sha256
{
    public class PaddingProvider
    {
        public static readonly byte[] PaddingConstant = new byte[] {
            0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
        };

        public static byte[] PreparePadding(Span<byte> finalMessageChunk, int originalMessageSizeInBytes)
        {
            uint lengthInBits = (uint)originalMessageSizeInBytes * 8;
            var bytesOfPadding = 64 - ((originalMessageSizeInBytes + 4) % 64);

            if (bytesOfPadding == 0)
                bytesOfPadding = 64;

            var padding = new byte[bytesOfPadding + finalMessageChunk.Length + 4];

            Array.Copy(finalMessageChunk.ToArray(), 0, padding, 0, finalMessageChunk.Length);
            Array.Copy(PaddingConstant, 0, padding, finalMessageChunk.Length, bytesOfPadding);
            Array.Copy(lengthInBits.ToBigEndianByteArray(), 0, padding, bytesOfPadding + finalMessageChunk.Length, 4);

            return padding;
        }
    }
}
