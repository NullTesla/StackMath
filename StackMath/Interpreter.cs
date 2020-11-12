using StackMath.Instructions;
using StackMath.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackMath
{
    public class Interpreter
    {
        Context Context = new Context();
        IParser Parser { get; set; } = new Parser();
        ILexer Lexer { get; set; } = new Lexer();

        public Interpreter() { }

        public Interpreter(ILexer lexer, IParser parser)
        {
            Lexer = lexer;
            Parser = parser;
        }

        public double Interpret(string input)
        {
            Stack<double> stack = new Stack<double>();
            List<Instruction> instructions = Parser.Parse(Lexer.Analyze(input, Context));
            if (instructions.Any(x => x is LeftBracket || x is RightBracket))
                throw new ArgumentException("Invalid input string");
            instructions.ForEach(x => x.Execute(stack));
            return stack.Count > 1 ? throw new ArgumentException("Invalid input string") : (stack.Count > 0 ? stack.Pop() : double.NaN);
        }
    }
}
