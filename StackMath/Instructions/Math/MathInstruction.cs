using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackMath.Instructions.Math
{
    public abstract class MathInstruction : Instruction
    {
        private Func<double, double, double> Function;

        public MathInstruction(Func<double, double, double> function)
        {
            Function = function;
        }

        public override void Execute(Stack<double> stack)
        {
            stack.Push(Function(stack.Pop(), stack.Pop()));
        }
    }
}
