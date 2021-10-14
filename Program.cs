using System;

namespace sigma_7_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Translator t = new Translator("data.txt");
            Console.WriteLine(t.Translate());
        }
    }
}
