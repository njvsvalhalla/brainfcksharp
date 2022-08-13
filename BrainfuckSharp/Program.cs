// See https://aka.ms/new-console-template for more information
using BrainfuckSharp;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
			var bfCode = ">++++++++[<+++++++++>-]<.>++++[<+++++++>-]<+.+++++++..+++.>>++++++[<+++++++>-]<++.------------.> ++++++[< +++++++++> -] < +.<.++ +.------.--------.>>> ++++[< ++++++++> -] < +.";
			bfCode = string.Join("", bfCode.Where(w => IsValidBF(w)));

			Console.WriteLine($"Interpreting {bfCode}");
			var cells = new int[3000];
			var currentCell = 0;
			new Interpreter(bfCode).Interpret(ref cells, ref currentCell);
		}

		
		private static bool IsValidBF(char letter) => letter == '+' || letter == '-' || letter == '>' || letter == '<' || letter == '.' || letter == ',' || letter == '[' || letter == ']';
	}
}