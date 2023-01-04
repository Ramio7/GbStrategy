namespace Assets.Root.Modules.Abstractions
{
    public interface IVictim : IHealthContainer
    {
        void TakeDamage(int damage);
    }
}
