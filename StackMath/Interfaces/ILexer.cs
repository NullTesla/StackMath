using StackMath.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackMath.Interfaces
{
    public interface ILexer
    {
        List<Instruction> Analyze(string input);
    }
}
