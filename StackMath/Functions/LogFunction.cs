using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackMath.Functions
{
    public class LogFunction : Function
    {
        public override int ArgsCount => 2;

        public override double Calculate(params double[] args)
        {
            return Math.Log(args[0], args[1]);
        }
    }
}
