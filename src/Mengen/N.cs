namespace src.Mengen
{
    public class N : Interfaces.IMenge<int>
    {
        public N() : base()
        {
        }

        public override bool IstEndlich { get { return false; } }

        public override bool IstAbzaehlbar { get { return true; } }

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

        public bool IstTeilmengeVon<E>(Interfaces.IMenge<E> menge) where E : IEquatable<E>
        {
            if (typeof(N0).Equals(menge.GetType()) ||
                new N0().IstTeilmengeVon(menge))
            {
                return true;
            }

            return false;
        }

        public bool IstGleich<E>(Interfaces.IMenge<E> menge) where E : IEquatable<E>
        {
            if (typeof(N).Equals(menge.GetType()))
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
