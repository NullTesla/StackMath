namespace StackMath.Instructions.Math
{
    public class DivInstruction : MathInstruction
    {
        public override int Priority => 2;

        public override bool LeftAssociative => true;

        public DivInstruction() : base((x, y) => y / x) { }
    }
}
