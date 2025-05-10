namespace Mengen
{
    public class MengeDerTestMengen : AbstractMenge<AbstractMenge<int>>
    {
        public override bool IstEndlich { get { return true; } }

        public override bool IstAbzaehlbar { get { return true; } }

        public override AbstractMenge<AbstractMenge<int>> LeereMenge()
        {
            return new MengeDerTestMengen();
        }

        public override AbstractMenge<AbstractMenge<AbstractMenge<int>>> LeereMengeDerTeilmengen()
        {
            throw new NotImplementedException();
        }
    }
}
