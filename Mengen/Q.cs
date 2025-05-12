namespace Mengen
{
    public class Q : AbstractMenge<Bruch>
    {
        public Q() : base()
        {
        }

        public override bool IstEndlich { get { return false; } }

        public override bool IstAbzaehlbar { get { return true; } }

        public override AbstractMenge<Bruch> LeereMenge()
        {
            throw new NotImplementedException();
        }

        public override AbstractMenge<AbstractMenge<Bruch>> LeereMengeDerMengen()
        {
            throw new NotImplementedException();
        }

        public bool HatElement(int element)
        {
            return true;
        }

        public bool IstTeilmengeVon<E>(AbstractMenge<E> menge) where E : IEquatable<E>
        {
            if (typeof(R).Equals(menge.GetType()) ||
                new R().IstTeilmengeVon(menge))
            {
                return true;
            }

            return false;
        }

        public bool IstGleich<E>(AbstractMenge<E> menge) where E : IEquatable<E>
        {
            if (typeof(Q).Equals(menge.GetType()))
            {
                return true;
            }

            return false;
        }

        public AbstractMenge<E> Durchschnitt<E>(AbstractMenge<E> menge) where E : IEquatable<E>
        {
            throw new NotImplementedException();
        }

        public AbstractMenge<E> Vereinigung<E>(AbstractMenge<E> menge) where E : IEquatable<E>
        {
            throw new NotImplementedException();
        }

        public AbstractMenge<E> DifferenzMenge<E>(AbstractMenge<E> menge) where E : IEquatable<E>
        {
            throw new NotImplementedException();
        }
    }
}
