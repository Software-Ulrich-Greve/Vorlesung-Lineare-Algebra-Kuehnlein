namespace Mengen
{
    public class N0 : AbstractMenge<int>
    {
        public N0() : base()
        {
        }

        public override bool IstEndlich { get { return false; } }

        public override bool IstAbzaehlbar { get { return true; } }

        public override AbstractMenge<int> LeereMenge()
        {
            throw new NotImplementedException();
        }

        public override AbstractMengeDerMengen<int> LeereMengeDerTeilmengen()
        {
            throw new NotImplementedException();
        }

        public new bool HatElement(int element)
        {
            if (element > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IstTeilmengeVon<E>(AbstractMenge<E> menge) where E : IEquatable<E>
        {
            if (typeof(Z).Equals(menge.GetType()) ||
                new Z().IstTeilmengeVon(menge))
            {
                return true;
            }

            return false;
        }

        public bool IstGleich<E>(AbstractMenge<E> menge) where E : IEquatable<E>
        {
            if (typeof(Z).Equals(menge.GetType()))
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
