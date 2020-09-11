using System;
using puzzles.macattack.sha256.models;
using puzzles.macattack.sha256.Resources;

namespace puzzles.macattack.sha256
{
    public class Sha256BlockProcessor
    {
        public HashState hashState;

        public Sha256BlockProcessor()
        {
            hashState = Constants.InitialHashState;
        }

        public void ProcessBlock(uint[] messageChunk)
        {
            var messageSchedule = MessageScheduleCreator.CreateMessageSchedule(messageChunk);
            hashState = Transform.ComputeHash(hashState, messageSchedule);
        }

        public byte[] GetCurrentHash()
        {
            var hash = new byte[32];

            var hashStateBytes = new uint[] {
                hashState.H0, hashState.H1, hashState.H2, hashState.H3,
                hashState.H4, hashState.H5, hashState.H6, hashState.H7
            };

            for (var i = 0; i < hashStateBytes.Length; i++)
            {
                var byteArray = hashStateBytes[i].ToBigEndianByteArray();
                Array.Copy(byteArray, 0, hash, 4 * i, 4);
            }

            return hash;
        }
    }
}
