public class OneShot : BuffApply
{
    protected override void Accept(IBuffVisitor buffVisitor)
    {
        buffVisitor?.Visit(this);
    }
}