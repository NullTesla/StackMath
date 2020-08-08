using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackMath.Instructions.Math
{
    public class NegativeInstruction : Instruction
    {
        public override int Priority => 4;

        public override bool LeftAssociative => false;

        public override void Execute(Stack<double> stack)
        {
            stack.Push(-stack.Pop());
        }
    }
}
