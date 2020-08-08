using System.Collections.Generic;

namespace StackMath.Instructions
{
    public abstract class Instruction
    {
        public abstract int Priority { get; }
        public abstract bool LeftAssociative { get; } // A op B op C == ((A op B) op C)

        public abstract void Execute(Stack<double> stack);
        
    }
}
