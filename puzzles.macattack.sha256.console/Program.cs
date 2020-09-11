using System;

namespace puzzles.macattack.sha256.console
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var exampleString = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ01234567";
            var sha256 = new Sha256Provider();
            var hash = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(exampleString));

            Console.WriteLine($"The SHA256 hash for '{exampleString}' is {hash.ToHexString()}");
        }
    }
}
