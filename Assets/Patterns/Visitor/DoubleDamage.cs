public class DoubleDamage : BuffApply
{
    protected override void Accept(IBuffVisitor buffVisitor)
    {
        buffVisitor?.Visit(this);
    }
}