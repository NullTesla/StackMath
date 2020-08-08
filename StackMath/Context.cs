using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackMath
{
    public class Context
    {
        private Dictionary<string, double> Variables = new Dictionary<string, double>();

        public void SetVariable(string var, double value)
        {
            if (!Variables.ContainsKey(var))
                Variables.Add(var, value);
            else
                Variables[var] = value;
        }

        public double GetVariable(string var)
        {
            return Variables[var];
        }
    }
}
