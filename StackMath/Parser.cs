using System;
using System.Collections.Generic;
using StackMath.Instructions;
using StackMath.Interfaces;

namespace StackMath
{
    public class Parser : IParser
    {
        public List<Instruction> Parse(List<Instruction> tokens)
        {
            List<Instruction> temp = new List<Instruction>();
            Stack<Instruction> buffer = new Stack<Instruction>();

            foreach(Instruction token in tokens)
                ParseIteration(token, buffer, temp);
            while (buffer.Count > 0)
                temp.Add(buffer.Pop());

            return temp;
        }

        private void ParseIteration(Instruction inst,Stack<Instruction> stack, List<Instruction> instructions)
        {
            if (inst is RightBracketInstruction)
                ClosingBracket(ref instructions, ref stack);
            else if (inst is PushInstruction)
            {
                instructions.Add(inst);
            }
            else
            {
                while (stack.Count > 0 && !(inst is LeftBracketInstruction) && (stack.Peek().Priority > inst.Priority || (stack.Peek().Priority == inst.Priority && inst.LeftAssociative)))
                    instructions.Add(stack.Pop());
                stack.Push(inst);
            }
        }

        private void ClosingBracket(ref List<Instruction> instructions, ref Stack<Instruction> buffer)
        {
            bool IsBracketFound = false;
            while (!IsBracketFound)
            {
                if (buffer.Count == 0)
                    throw new ArgumentException("Invalid input string");
                if (!(buffer.Peek() is LeftBracketInstruction))
                    instructions.Add(buffer.Pop());
                else
                {
                    IsBracketFound = true;
                    buffer.Pop();
                }
            }

            if (!IsBracketFound)
                throw new ArgumentException("Invalid input string");
        }
    }
}
