using System;
using System.Linq;
using System.Collections.Generic;

namespace Skills.Infrastructure
{
    class Console
    {
        public static readonly Queue<string> Buffer = new Queue<string>();

        public static void WriteLine(object line = null)
        {
            Buffer.Enqueue(line?.ToString() ?? string.Empty);
        }

        public static string ReadLine()
        {
            return Buffer.Count > 0 ? Buffer.Dequeue() : string.Empty;
        }
    }
}
