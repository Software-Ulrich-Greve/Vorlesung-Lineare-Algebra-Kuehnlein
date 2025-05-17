namespace src.Mengen
{
    public class TestMenge : AbstractMenge<int>
    {
        public override bool IstEndlich { get { return true; } }

        public override bool IstAbzaehlbar { get { return true; } }
    }
}
