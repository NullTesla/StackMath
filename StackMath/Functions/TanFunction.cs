using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackMath.Functions
{
    public class TanFunction : Function
    {
        public override int ArgsCount => 1;

        public override double Calculate(params double[] args)
        {
            return Math.Tan(args[0]);
        }
    }
}
