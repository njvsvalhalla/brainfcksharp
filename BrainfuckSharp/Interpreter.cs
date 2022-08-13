using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainfuckSharp
{
    public class Interpreter
    {
		private int? _endOfLoop = null;
		private string _code;

		public Interpreter(string code)
        {
			_code = code;
        }

		public void Interpret(ref int[] cells, ref int currentCell, bool isLoop = false, int? loopStart = null, int? currentPosition = null)
		{
			for (var i = 0; i < _code.Length; i++)
			{
				if (_endOfLoop != null)
                {
					i = _endOfLoop.Value;
					_endOfLoop = null;
				}
				var character = _code[currentPosition ?? i];
				if (isLoop && character == ']')
					if (cells[currentCell] != 0)
					{
						currentPosition = loopStart;
						i = loopStart.Value;
						continue;
					}
					else
					{
						_endOfLoop = currentPosition+1;
						break;
					}

				Handle(character, ref cells, ref currentCell, i);
				if (loopStart.HasValue)
					currentPosition++;
			}
		}
		private void Handle(char character, ref int[] cells, ref int currentCell, int currentPosition, int? loopStart = null)
		{
			switch (character)
			{
				case '+':
					cells[currentCell] += 1;
					break;
				case '-':
					cells[currentCell] -= 1;
					break;
				case '>':
					currentCell += 1;
					break;
				case '<':
					currentCell -= 1;
					break;
				case '.':
					PrintAscii(cells[currentCell]);
					break;
				case ',':
					Console.WriteLine("Input required... ");
					var ascii = Console.ReadKey().KeyChar;
					Console.WriteLine();
					cells[currentCell] = (int)ascii;
					break;
				case '[':
					loopStart = loopStart ?? currentPosition + 1;
					Interpret(ref cells, ref currentCell, true, loopStart, currentPosition + 1);
					break;

				default:
					break;
			}
		}
		private static void PrintAscii(int asciiVal) => Console.Write(((char)asciiVal));

	}
}
