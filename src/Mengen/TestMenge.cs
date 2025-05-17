namespace src.Mengen
{
    public class TestMenge : 
        AbstractMenge<int>, 
        Interfaces.IMenge<int>,
        IEquatable<TestMenge>
    {
        public override bool IstEndlich { get { return true; } }

        public override bool IstAbzaehlbar { get { return true; } }

        public override Interfaces.IMenge<int> LeereMenge()
        {
            return new TestMenge();
        }

        public override Interfaces.IMenge<Interfaces.IMenge<int>> LeereMengeDerMengen()
        {
            return new MengeDerTestMengen().LeereMenge();
        }

        public bool Equals(TestMenge? other)
        {
            return base.Equals(other);
        }
    }
}
