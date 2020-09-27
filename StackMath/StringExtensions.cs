using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackMath.Instructions;
using StackMath.Instructions.Math;

namespace StackMath
{
    public static class StringExtensions
    {
        public static Instruction GetToken(this string s, IDictionary<string, Instruction> operators)
        {
            double d;
            if (double.TryParse(s, out d))
                return new PushInstruction(d);
            else
            {
                return operators[s];
            }
        }
    }
}
