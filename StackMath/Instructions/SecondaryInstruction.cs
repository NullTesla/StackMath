using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackMath.Instructions
{
    public abstract class SecondaryInstruction : Instruction
    {
        public override int Priority => int.MinValue;
        public override bool LeftAssociative => throw new NotImplementedException();

        public override void Execute(Stack<double> stack)
        {
            //throw new ArgumentException();
        }
    }
}
