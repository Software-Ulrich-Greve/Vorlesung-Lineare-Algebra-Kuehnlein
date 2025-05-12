namespace Mengen
{
    public class R : AbstractMenge<decimal>
    {
        public R() : base()
        {
        }

        public override bool IstEndlich { get { return false; } }

        public override bool IstAbzaehlbar { get { return true; } }

        public override AbstractMenge<decimal> LeereMenge()
        {
            throw new NotImplementedException();
        }

        public override AbstractMengeBase<AbstractMengeBase<decimal>> LeereMengeDerMengen()
        {
            throw new NotImplementedException();
        }

        public new bool HatElement(decimal element)
        {
            return true;
        }

        public bool IstTeilmengeVon<E>(AbstractMenge<E> menge) where E : IEquatable<E>
        {
            if (typeof(R).Equals(menge.GetType()))
            {
                return true;
            }

            return false;
        }

        public bool IstGleich<E>(AbstractMenge<E> menge) where E : IEquatable<E>
        {
            if (typeof(R).Equals(menge.GetType()))
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
