using System;
namespace puzzles.macattack.sha256
{
    public static class BitwiseCalculator
    {
        public static uint ShiftRight(this uint operand, ushort bits)
        {
            return operand >> bits;
        }

        public static uint RotateRight(this uint operand, ushort bits)
        {
            return (operand >> bits) | (operand << (32 - bits));
        }
    }
}
