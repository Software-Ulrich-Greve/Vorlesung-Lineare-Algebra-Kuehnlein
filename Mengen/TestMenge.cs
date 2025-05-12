namespace Mengen
{
    public class TestMenge : AbstractMenge<int>, IEquatable<TestMenge>
    {
        public override bool IstEndlich { get { return true; } }

        public override bool IstAbzaehlbar { get { return true; } }

        public bool Equals(TestMenge? other)
        {
            return base.Equals(other);
        }

        public override AbstractMenge<int> LeereMenge()
        {
            return new TestMenge();
        }

        public override AbstractMengeDerMengen<int> LeereMengeDerTeilmengen()
        {
            return new MengeDerTestMengen();
        }
    }
}
