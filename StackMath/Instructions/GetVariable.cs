using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackMath.Instructions
{
    public class GetVariable : Instruction
    {
        public Context Context { get; private set; }
        public string Var { get; private set; }

        public override int Priority => 0;

        public override bool LeftAssociative => true;

        public GetVariable(Context context, string var)
        {
            Context = context;
            Var = var;
        }

        public override void Execute(Stack<double> stack)
        {
            stack.Push(Context.GetVariable(Var));
        }
    }
}
