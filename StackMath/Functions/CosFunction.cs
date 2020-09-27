using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackMath.Functions
{
    public class CosFunction : Function
    {
        public override int ArgsCount => 1;

        public override double Calculate(params double[] args)
        {
            return Math.Cos(args[0]);
        }
    }
}
