using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackMath.Instructions
{
    public class SetVariable : Instruction
    {
        Context Context;
        string Var;

        public override int Priority => int.MinValue;

        public override bool LeftAssociative => true;

        public SetVariable(Context context, string var)
        {
            Context = context;
            Var = var;
        }

        public SetVariable(GetVariable variable)
        {
            Context = variable.Context;
            Var = variable.Var;
        }

        public override void Execute(Stack<double> stack)
        {
            Context.SetVariable(Var, stack.Pop());
        }
    }
}
