namespace src.Mengen
{
    public class TestMenge : AbstractMenge<int>, IEquatable<TestMenge>
    {
        public override bool IstEndlich { get { return true; } }

        public override bool IstAbzaehlbar { get { return true; } }

        public bool Equals(TestMenge? other)
        {
            return base.Equals(other);
        }

        public override Interfaces.IMenge<int> LeereMenge()
        {
            return new TestMenge();
        }

        public override Interfaces.IMenge<Interfaces.IMenge<int>> LeereMengeDerMengen()
        {
            return new MengeDerTestMengen().LeereMenge();
        }
    }
}
