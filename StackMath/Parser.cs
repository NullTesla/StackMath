using System;
using System.Collections.Generic;
using StackMath.Instructions;
using StackMath.Instructions.Math;
using StackMath.Interfaces;

namespace StackMath
{
    public class Parser : IParser
    {
        public List<Instruction> Parse(List<Instruction> tokens)
        {
            List<Instruction> temp = new List<Instruction>();
            Stack<Instruction> buffer = new Stack<Instruction>();

            for (int i = 0; i < tokens.Count; ++i)
                tokens[i] = PredictOperator(i - 1 < 0 ? null : tokens[i - 1], tokens[i], i + 1 >= tokens.Count ? null : tokens[i+1]);
            foreach(Instruction token in tokens)
                ParseIteration(token, buffer, temp);
            while (buffer.Count > 0)
                temp.Add(buffer.Pop());

            return temp;
        }

        //See the Shunting-yard algorithm for more information
        private void ParseIteration(Instruction inst, Stack<Instruction> stack, List<Instruction> instructions)
        {
            if (inst is Functions.Function)
                stack.Push(inst);
            else if (inst is Separator)
            {
                while (!(stack.Peek() is LeftBracket))
                    instructions.Add(stack.Pop());
            }
            else if (inst is RightBracket)
                ClosingBracket(instructions, stack);
            else if (inst is PushInstruction || inst is GetVariable || inst is Equal)
            {
                instructions.Add(inst);
            }
            else
            {
                while (stack.Count > 0 && !(inst is LeftBracket) && (stack.Peek().Priority > inst.Priority || (stack.Peek().Priority == inst.Priority && inst.LeftAssociative)))
                    instructions.Add(stack.Pop());
                stack.Push(inst);
            }
        }

        private void ClosingBracket(List<Instruction> instructions, Stack<Instruction> buffer)
        {
            bool IsBracketFound = false;
            while (!IsBracketFound)
            {
                if (buffer.Count == 0)
                    throw new ArgumentException("Invalid input string");
                if (!(buffer.Peek() is LeftBracket))
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

        private Instruction PredictOperator(Instruction previous, Instruction inst, Instruction next)
        {
            
            bool IsSub = inst is SubInstruction;
            bool IsNegative = previous == null || !(previous is PushInstruction || previous is GetVariable);
            if (IsSub && IsNegative)
                inst = new NegativeInstruction();
            if (next is Equal && inst is GetVariable)
                inst = new SetVariable(inst as GetVariable);

            return inst;
        }
    }
}
