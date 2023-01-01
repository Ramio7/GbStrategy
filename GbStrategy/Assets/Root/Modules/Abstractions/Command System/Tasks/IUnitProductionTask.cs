namespace Abstractions
{
    public interface IUnitProductionTask : IIconContainer
    {
        public string UnitName { get; }
        public float TimeLeft { get; }
        public float ProductionTime { get; }
    }

}
