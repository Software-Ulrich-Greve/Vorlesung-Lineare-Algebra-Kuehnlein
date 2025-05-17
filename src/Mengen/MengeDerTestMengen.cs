namespace src.Mengen
{
    public class MengeDerTestMengen :
        AbstractMenge<Interfaces.IMenge<int>>,
        Interfaces.IMenge<Interfaces.IMenge<int>>
    {
        public override bool IstEndlich { get { return true; } }

        public override bool IstAbzaehlbar { get { return true; } }
    }
}
