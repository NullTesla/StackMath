using System.Collections.Generic;
using StackMath.Instructions;

namespace StackMath.Interfaces
{
    public interface IParser
    {
        List<Instruction> Parse(List<Instruction> tokens);
    }
}
