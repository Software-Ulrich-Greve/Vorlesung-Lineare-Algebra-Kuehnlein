namespace Mengen
{
    public class MengeDerTestMengen : AbstractMengeDerMengen<int>
    {
        public override bool IstEndlich { get { return true; } }

        public override bool IstAbzaehlbar { get { return true; } }

        public override AbstractMengeDerMengen<int> LeereMenge()
        {
            return new MengeDerTestMengen();
        }
        public override AbstractMengeBase<AbstractMengeBase<AbstractMengeBase<int>>> LeereMengeDerMengen()
        {
            throw new NotImplementedException();
        }
    }
}
