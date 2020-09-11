using System;
namespace puzzles.macattack.sha256
{
    public class MessageScheduleCreator
    {
        public static uint[] CreateMessageSchedule(uint[] messageChunk)
        {
            if (messageChunk == null)
                throw new ArgumentNullException(nameof(messageChunk));

            if (messageChunk.Length != 16)
                throw new ArgumentOutOfRangeException(nameof(messageChunk), $"{nameof(messageChunk)} must contain exactly 16 elements");

            uint[] messageSchedule = new uint[64];
            Array.Copy(messageChunk, 0, messageSchedule, 0, messageChunk.Length);

            for (var i = messageChunk.Length; i < messageSchedule.Length; i++)
            {
                uint sigmaZero = messageSchedule[i - 15].RotateRight(7) ^ messageSchedule[i - 15].RotateRight(18) ^ messageSchedule[i - 15].ShiftRight(3);
                uint sigmaOne = messageSchedule[i - 2].RotateRight(17) ^ messageSchedule[i - 2].RotateRight(19) ^ messageSchedule[i - 2].ShiftRight(10);

                messageSchedule[i] = messageSchedule[i - 16] + sigmaZero + messageSchedule[i - 7] + sigmaOne;
            }

            return messageSchedule;
        }
    }
}
