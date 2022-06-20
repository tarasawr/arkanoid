public interface IBuffVisitor
{
    public void Visit(Expanded buff);
    public void Visit(DoubleDamage buff);
    public void Visit(OneShot buff);
    public void Visit(SlowSpeed buff);
}