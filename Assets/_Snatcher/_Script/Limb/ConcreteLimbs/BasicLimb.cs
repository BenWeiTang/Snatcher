namespace Snatcher
{
    public class BasicLimb : ALimb
    {
        public override LimbType Type => LimbType.Basic;
        private string name = "basic";
        private float durability = float.PositiveInfinity;
        public BasicLimb() : base()
        {
        }
    }
}
