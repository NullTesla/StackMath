using StackMath.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackMath.Functions
{
    public abstract class Function : Instruction
    {
        public abstract int ArgsCount { get; }
        public override int Priority => int.MaxValue;
        public override bool LeftAssociative => true;

        public override void Execute(Stack<double> stack)
        {
            stack.Push(Calculate(GetArgs(stack)));
        }

        public abstract double Calculate(params double[] args);

        private double[] GetArgs(Stack<double> stack)
        {
            double[] temp = new double[ArgsCount];
            for (int i = ArgsCount-1; i >= 0; --i)
                temp[i] = stack.Pop();
            return temp;
        }
    }
}
