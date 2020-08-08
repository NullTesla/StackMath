namespace StackMath.Instructions.Math
{
    public class SubInstruction : MathInstruction
    {
        public override int Priority => 1;

        public override bool LeftAssociative => true;

        public SubInstruction() : base((x,y) => y - x) { }
    }
}
