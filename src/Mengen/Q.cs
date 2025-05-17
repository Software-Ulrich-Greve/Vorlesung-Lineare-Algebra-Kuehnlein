namespace src.Mengen
{
    public class Q : AbstractMenge<Bruch>
    {
        public Q() : base()
        {
        }

        public override bool IstEndlich { get { return false; } }

        public override bool IstAbzaehlbar { get { return true; } }

        public override Interfaces.IMenge<Bruch> LeereMenge()
        {
            throw new NotImplementedException();
        }

        public override Interfaces.IMenge<Interfaces.IMenge<Bruch>> LeereMengeDerMengen()
        {
            throw new NotImplementedException();
        }

        public bool HatElement(int element)
        {
            return true;
        }

        public bool IstTeilmengeVon<E>(Interfaces.IMenge<E> menge) where E : IEquatable<E>
        {
            if (typeof(R).Equals(menge.GetType()) ||
                new R().IstTeilmengeVon(menge))
            {
                return true;
            }

            return false;
        }

        public bool IstGleich<E>(Interfaces.IMenge<E> menge) where E : IEquatable<E>
        {
            if (typeof(Q).Equals(menge.GetType()))
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
