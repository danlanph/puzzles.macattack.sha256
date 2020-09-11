using puzzles.macattack.sha256.models;
using puzzles.macattack.sha256.Resources;

namespace puzzles.macattack.sha256
{
    public class Transform
    {
        public static HashState ComputeHash(HashState currentState, uint[] messageScheduleArray)
        {
            uint a = currentState.H0,
                 b = currentState.H1,
                 c = currentState.H2,
                 d = currentState.H3,
                 e = currentState.H4,
                 f = currentState.H5,
                 g = currentState.H6,
                 h = currentState.H7;

            for (var i = 0; i < 64; i++)
            {
                uint sigmaOne = e.RotateRight(6) ^ e.RotateRight(11) ^ e.RotateRight(25);
                uint ch = (e & f) ^ (~e & g);
                uint temp1 = h + sigmaOne + ch + Constants.K[i] + messageScheduleArray[i];
                uint sigmaZero = a.RotateRight(2) ^ a.RotateRight(13) ^ a.RotateRight(22);
                uint maj = (a & b) ^ (a & c) ^ (b & c);
                uint temp2 = sigmaZero + maj;

                h = g;
                g = f;
                f = e;
                e = d + temp1;
                d = c;
                c = b;
                b = a;
                a = temp1 + temp2;
            }

            return new HashState {
                H0 = currentState.H0 + a,
                H1 = currentState.H1 + b,
                H2 = currentState.H2 + c,
                H3 = currentState.H3 + d,
                H4 = currentState.H4 + e,
                H5 = currentState.H5 + f,
                H6 = currentState.H6 + g,
                H7 = currentState.H7 + h,
            };
        }       
    }
}
