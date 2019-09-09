using NUnit.Framework;
using Skills.Infrastructure;
using Console = Skills.Infrastructure.Console;

// Problem: http://www.amazon.com/Really-Understand-Binary-Rex-Barzee-ebook/dp/B00ODTQKM6 - Example 8

namespace Skills.Playground
{
    using System.Linq;

    [TestFixture]
    class BinarySubtraction : TestClass
    {
        public static void Main()
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
            var i1 = Console.ReadLine().Select(c => c == '1').ToArray();
            var i2 = Console.ReadLine().Select(c => c == '1').ToArray();

            Negate(i2);                                                                        //01000000 -> 10111111

            Sumi1Toi2(new [] { false, false, false, false, false, false, false, true },  i2);  //10111111 -> 11000000

            Sumi1Toi2(i1, i2);                                                                 //11000000 -> 11110101

            Console.WriteLine(string.Join("", i2.Select(b => b ? "1" : "0")));
        }

        private static void Sumi1Toi2(bool[] i1, bool[] i2)
        {
            var carry = false;
            for (var i = 7; i >= 0; i--)
                Sum(ref i2[i], i1[i], ref carry);
        }

        private static void Sum(ref bool b1, bool b2, ref bool carry)
        {
            var i1 = b1 ? 1 : 0;
            var i2 = b2 ? 1 : 0;
            var ic = carry ? 1 : 0;

            var swap = (i1 + i2 + ic) % 2;
            ic = (i1 + i2 + ic) / 2;

            b1 = swap == 1;
            carry = ic == 1;
        }

        private static void Negate(bool[] i2)
        {
            for (var i = 0; i < i2.Length; i++)
                i2[i] = !i2[i];
        }

        [Test]
        [TestCase("00110101", "01000000", "11110101")] //53 - 64 = -11
        [TestCase("01001101", "00001101", "01000000")] //77 - 13 = 64
        [TestCase("00001111", "00000000", "00001111")] //15 - 0 = 15
        [TestCase("00000000", "00001111", "11110001")] //0 - 15 = -15
        public void TestStandardInput(string i1, string i2, string o)
        {
            Test(Main, new[] { i1, i2 }, new[] { o });
        }
    }
}
