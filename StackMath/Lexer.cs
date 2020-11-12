using StackMath.Functions;
using StackMath.Instructions;
using StackMath.Instructions.Math;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StackMath
{
    public class Lexer : Interfaces.ILexer
    {
        readonly Dictionary<string, Instruction> operators = new Dictionary<string, Instruction>()
        {
            {"+", new AddInstruction() },
            {"-", new SubInstruction() },
            {"*", new MulInstruction() },
            {"/", new DivInstruction() },
            {"^", new PowInstruction() },
            {"(", new LeftBracket() },
            {")", new RightBracket() },
            {",", new Separator() },
            {"=", new Equal() },
        };

        readonly Dictionary<string, Instruction> functions = new Dictionary<string, Instruction>()
        {
            {"sin", new SinFunction() },
            {"cos", new CosFunction() },
            {"tan", new TanFunction() },
            {"log", new LogFunction() }
        };

        readonly Dictionary<string, Instruction> constants = new Dictionary<string, Instruction>()
        {
            {"pi", new PushInstruction(Math.PI) },
            {"e", new PushInstruction(Math.E) },
        };

        Dictionary<string, Instruction> instructions => operators.Union(functions).Union(constants).ToDictionary(k => k.Key, v => v.Value);

        public List<Instruction> Analyze(string input, Context context)
        {
            string regex = @"([*()\^\/]|(?<!E)[\+\-\,\=])";
            string[] tokens = Regex.Split(input.Replace(" ", ""), regex).ToList().Where(x => x != " " && x != "").ToArray();
            List<Instruction> inst = tokens.Select(x => GetToken(x, instructions, context)).ToList();
            return inst;
        }

        private Instruction GetToken(string s, IDictionary<string, Instruction> operators, Context context)
        {
            double d;
            if (double.TryParse(s, out d))
                return new PushInstruction(d);
            else if (operators.ContainsKey(s))
            {
                return operators[s];
            }
            else
                return new GetVariable(context, s);
        }
    }
}
