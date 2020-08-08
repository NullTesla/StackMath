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
        readonly ReadOnlyDictionary<char, Instruction> operators = new ReadOnlyDictionary<char, Instruction>(new Dictionary<char, Instruction>
        {
            {'+', new AddInstruction() },
            {'-', new SubInstruction() },
            {'*', new MulInstruction() },
            {'/', new DivInstruction() },
            {'^', new PowInstruction() },
            {'(', new LeftBracketInstruction() },
            {')', new RightBracketInstruction() }
        });

        public List<Instruction> Analyze(string input)
        {
            string[] tokens = Regex.Split(input, @"([*()\^\/]|(?<!E)[\+\-])").ToList().Where(x => x != " " && x != "").ToArray();
            List<Instruction> inst = tokens.Select(x => x.GetToken(operators)).ToList();
            for (int i = 0; i < inst.Count; i++)
                inst[i] = UnaryMinusCheck(inst[i], i == 0 ? null : inst[i - 1]);
            return inst;
        }

        private static Instruction UnaryMinusCheck(Instruction inst, Instruction previous)
        {
            bool IsSub = inst is SubInstruction;
            bool IsNegative = previous == null || !(previous is PushInstruction);
            if (IsSub && IsNegative)
                inst = new NegativeInstruction();
            return inst;
        }
    }
}
