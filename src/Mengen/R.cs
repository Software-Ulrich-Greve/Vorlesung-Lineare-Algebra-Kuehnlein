namespace src.Mengen
{
    public class R : AbstractMenge<decimal>
    {
        public R() : base()
        {
        }

        public override bool IstEndlich { get { return false; } }

        public override bool IstAbzaehlbar { get { return true; } }

        public new bool HatElement(decimal element)
        {
            return true;
        }

        public bool IstTeilmengeVon<E>(Interfaces.IMenge<E> menge) where E : IEquatable<E>
        {
            if (typeof(R).Equals(menge.GetType()))
            {
                return true;
            }

            return false;
        }

        public bool IstGleich<E>(Interfaces.IMenge<E> menge) where E : IEquatable<E>
        {
            if (typeof(R).Equals(menge.GetType()))
            {
                return true;
            }

            return false;
        }

        public Interfaces.IMenge<E> Durchschnitt<E>(Interfaces.IMenge<E> menge) where E : IEquatable<E>
        {
            throw new NotImplementedException();
        }

        public Interfaces.IMenge<E> Vereinigung<E>(Interfaces.IMenge<E> menge) where E : IEquatable<E>
        {
            throw new NotImplementedException();
        }

        public Interfaces.IMenge<E> DifferenzMenge<E>(Interfaces.IMenge<E> menge) where E : IEquatable<E>
        {
            throw new NotImplementedException();
        }
    }
}
