using System;
using System.Collections.Generic;

namespace StackMath.Instructions
{
    public class LeftBracketInstruction : Instruction
    {
        public override int Priority => int.MinValue;

        public override bool LeftAssociative => throw new NotImplementedException();

        public override void Execute(Stack<double> stack)
        {
            throw new ArgumentException();
        }
    }
}
