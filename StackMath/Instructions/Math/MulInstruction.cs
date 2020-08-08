namespace StackMath.Instructions.Math
{
    public class MulInstruction : MathInstruction
    {
        public override int Priority => 2;

        public override bool LeftAssociative => true;

        public MulInstruction() : base((x, y) => x * y) { }
    }
}
