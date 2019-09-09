# Playground

Test harness to make it easy to implement  challenges from platforms like Hackerrank, TestDome and Codility.

## How to use it?

After implementing the challenge in Visual Studio or VSCode, using the structure shown bellow, copy the contents of the `Main` method to the platform and submit your code.

```C#
    [TestFixture]
    class MyChallengeClass : TestClass
    {
        public static void Main()
        {
            /* Main method calling the challenge implementation as requested by the challenge platform*/
        }

        private static void MyChallengeImplementation()
        {
            /* Challenge implementation */
        }

        [Test]
        [TestCase("00110101", "01000000", "11110101")] //53 - 64 = -11
        [TestCase("01001101", "00001101", "01000000")] //77 - 13 = 64
        [TestCase("00001111", "00000000", "00001111")] //15 - 0 = 15
        [TestCase("00000000", "00001111", "11110001")] //0 - 15 = -15
        public void TestMethodWithLotsOfTestCases(string i1, string i2, string o)
        {
            Test(Main, new[] { i1, i2 }, new[] { o });
        }
    }

```

The `Test` method will call your Main method, replacing the `System.Console` by a fake implementation passing the `Console` inputs to the test and assert the `Console` outputs.

See https://github.com/rafaelromao/TestHarness/blob/master/Playground/BinarySubtraction.cs for a working example.

*And remember not to submit your implementations to a public repository, specially if it is part of a coding interview.*
