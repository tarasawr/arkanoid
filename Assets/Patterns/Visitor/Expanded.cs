public class Expanded : BuffApply
{
    protected override void Accept(IBuffVisitor buffVisitor)
    {
        buffVisitor?.Visit(this);
    }
}