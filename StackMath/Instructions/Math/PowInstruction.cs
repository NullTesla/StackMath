using System;

namespace StackMath.Instructions.Math
{
    public class PowInstruction : MathInstruction
    {
        public override int Priority => 4;

        public override bool LeftAssociative => false;

        public PowInstruction() : base((x, y) => System.Math.Pow(y, x)) { }
    }
}
