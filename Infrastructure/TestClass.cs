using System;
using System.Diagnostics;
using FluentAssertions;

namespace Skills.Infrastructure
{
    class TestClass
    {
        protected void Test(Action action, string[] inputs, string[] outputs)
        {
            foreach (var input in inputs)
                Console.WriteLine(input);

            var sw = new Stopwatch();
            sw.Start();
            action();
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}");

            foreach (var expectedOutput in outputs)
            {
                var output = Console.ReadLine();
                output.Should().Be(expectedOutput);
            }
        }

        protected void Test(Action<string[]> action, string[] inputs, string[] outputs)
        {
            foreach (var input in inputs)
                Console.WriteLine(input);

            action(null);

            foreach (var expectedOutput in outputs)
            {
                var output = Console.ReadLine();
                output.Should().Be(expectedOutput);
            }
        }
    }
}
