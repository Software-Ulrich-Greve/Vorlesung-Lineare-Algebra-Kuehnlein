namespace src.Mengen
{
    public class MengeDerTestMengen :
        AbstractMenge<AbstractMenge<int>>,
        Interfaces.IMenge<AbstractMenge<int>>,
        IEquatable<MengeDerTestMengen>
    {
        public override bool IstEndlich { get { return true; } }

        public override bool IstAbzaehlbar { get { return true; } }

        public override Interfaces.IMenge<AbstractMenge<int>> LeereMenge()
        {
            return new MengeDerTestMengen();
        }

        public override Interfaces.IMenge<Interfaces.IMenge<AbstractMenge<int>>> LeereMengeDerMengen()
        {
            throw new NotImplementedException();
        }

        public bool Equals(MengeDerTestMengen? other)
        {
            return base.Equals(other);
        }
    }
}
