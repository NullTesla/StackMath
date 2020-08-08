namespace StackMath.Instructions.Math
{
    public class AddInstruction : MathInstruction
    {
        public override int Priority => 1;

        public override bool LeftAssociative => true;

        public AddInstruction() : base((x, y) => x + y) { }
    }
}
