using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackMath.Instructions
{
    public class PushInstruction : Instruction
    {
        public override int Priority => int.MaxValue;

        public override bool LeftAssociative => throw new NotImplementedException();

        public readonly double value;

        public PushInstruction(double value)
        {
            this.value = value;
        }

        public override void Execute(Stack<double> stack)
        {
            stack.Push(value);
        }
    }
}
