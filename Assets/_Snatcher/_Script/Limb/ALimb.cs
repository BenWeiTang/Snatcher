namespace Snatcher
{
    public abstract class ALimb
    {
        public abstract LimbType Type { get; }
        
        private string name;
        private AUpgrade[] upgrades;
        private float durability;
    }
}
