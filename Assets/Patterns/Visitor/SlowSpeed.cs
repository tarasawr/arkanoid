public class SlowSpeed : BuffApply
{
    protected override void Accept(IBuffVisitor buffVisitor)
    {
        buffVisitor?.Visit(this);
    }
}