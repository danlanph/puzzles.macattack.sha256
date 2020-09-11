using System;
namespace puzzles.macattack.sha256
{
    public class Sha256Provider
    {
        public byte[] ComputeHash(byte[] input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            var blockProcessor = new Sha256BlockProcessor();            
            var inputLengthInWhole64ByteBlocks = input.Length / 64;

            for (var block = 0; block < inputLengthInWhole64ByteBlocks; block++)            
            {
                var messageBlock = ByteHelper.BigEndianByteArrayToUintArray(input, block * 64, 16);
                blockProcessor.ProcessBlock(messageBlock);
            }

            var finalMessageChunk = input.AsSpan(inputLengthInWhole64ByteBlocks * 64);
            var finalBlocks = PaddingProvider.PreparePadding(finalMessageChunk, input.Length);

            for (var block = 0; block < finalBlocks.Length / 64; block++)
            {
                var messageBlock = ByteHelper.BigEndianByteArrayToUintArray(finalBlocks, block * 64, 16);
                blockProcessor.ProcessBlock(messageBlock);
            }

            return blockProcessor.GetCurrentHash();
        }        
    }
}
