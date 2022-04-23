namespace Snatcher
{
    public abstract class ALimb
    {
        public abstract LimbType Type { get; }
        private string name { get; }
        private AUpgrade upgrade { get; set; }
        private float durability { get; set; }
        
        public ALimb()
        {
        }

    }
}
