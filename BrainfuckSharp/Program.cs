// See https://aka.ms/new-console-template for more information
using BrainfuckSharp;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
			Console.WriteLine("BrainfuckSharp");
			var file = new FileInfo(args[0]);
			if (!file.Exists)
            {
				Console.WriteLine($"File {args[0]} not found.");
				return;
			}

			var bfCode = File.ReadAllText(args[0]);

			Console.WriteLine($"Interpreting file {Path.GetFileName(args[0])}");

			var cells = new int[3000];
			var currentCell = 0;

			new Interpreter(bfCode).Interpret(ref cells, ref currentCell);
		}
	}
}