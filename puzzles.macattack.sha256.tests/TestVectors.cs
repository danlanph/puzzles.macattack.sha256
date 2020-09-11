using Shouldly;
using Xunit;

namespace puzzles.macattack.sha256.tests
{
    public class TestVectors
    {
        [Theory]
        [InlineData("", "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855")]
        [InlineData("abc", "ba7816bf8f01cfea414140de5dae2223b00361a396177a9cb410ff61f20015ad")]
        [InlineData("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ012345678", "a1175908618a33d8783da0186c7088878ba8edb95aee2ff6a3165d99e80e16a5")]
        [InlineData("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ01234567", "a5c1354c0ccb753a33ba6978bf250fd8d253056481efe74e9661980ae1766751")]
        [InlineData("def", "cb8379ac2098aa165029e3938a51da0bcecfc008fd6795f401178647f96c5b34")]
        public void TestVectors_KnownInputStringsMatchImplementationCheckHashStrings(string inputString, string expectedHashHexString)
        {
            var sha256 = new Sha256Provider();

            var hash = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(inputString));
            var actualHashHexString = hash.ToHexString();

            actualHashHexString.ShouldBe(expectedHashHexString);
        }
    }
}
