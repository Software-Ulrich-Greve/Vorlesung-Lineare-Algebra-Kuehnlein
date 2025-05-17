namespace src.Mengen
{
    public abstract class AbstractMenge<T> :
        IEquatable<Interfaces.IMenge<T>>,
        Interfaces.IEndlichkeit,
        Interfaces.IAbzaehlbarkeit,
        Interfaces.ILeereMenge<Interfaces.IMenge<T>>,
        Interfaces.IKardinalitaet,
        Interfaces.IHatElement<T>,
        Interfaces.IElementMitIndex<T>,
        Interfaces.IIstTeilmengeVon<Interfaces.IMenge<T>>,
        Interfaces.IIstGleich<Interfaces.IMenge<T>>,
        Interfaces.IDurchschnitt<Interfaces.IMenge<T>>,
        Interfaces.IVereinigung<Interfaces.IMenge<T>>,
        Interfaces.IDifferenzMenge<Interfaces.IMenge<T>>,
        Interfaces.IToString,
        Interfaces.ICopy<Interfaces.IMenge<T>>,
        Interfaces.IMenge<T>
        where T : 
        IEquatable<T>
    {
        public abstract bool IstEndlich { get; }

        public abstract bool IstAbzaehlbar { get; }

        public Interfaces.IMenge<T> LeereMenge { get; set; }

        public Elemente<T> Elemente { get; set; }

        public AbstractMenge()
        {
            Elemente = new Elemente<T>();

            LeereMenge = this;
        }

        public Interfaces.IMenge<T> Initialize(Elemente<T> elemente)
        {
            Interfaces.IMenge<T> copy = Copy();

            copy.Elemente = elemente;

            return copy;
        }

        public int? Kardinalitaet()
        {
            if (!IstEndlich)
            {
                return null;
            }

            return Elemente.Kardinalitaet();
        }

        public bool HatElement(T? element)
        {
            return Elemente.HatElement(element);
        }

        public T ElementMitIndex(int index)
        {
            return Elemente.ElementMitIndex(index);
        }

        public bool IstTeilmengeVon(Interfaces.IMenge<T>? menge)
        {
            return Elemente.IstTeilmengeVon(menge?.Elemente);
        }

        public bool IstGleich(Interfaces.IMenge<T>? menge)
        {
            return Elemente.IstGleich(menge?.Elemente);
        }

        public Interfaces.IMenge<T> Durchschnitt(Interfaces.IMenge<T>? menge)
        {
            return Initialize(Elemente.Durchschnitt(menge?.Elemente));
        }

        public Interfaces.IMenge<T> Vereinigung(Interfaces.IMenge<T>? menge)
        {
            return Initialize(Elemente.Vereinigung(menge?.Elemente));
        }

        public Interfaces.IMenge<T> DifferenzMenge(Interfaces.IMenge<T>? menge)
        {
            return Initialize(Elemente.DifferenzMenge(menge?.Elemente));
        }

        public override string ToString()
        {
            return Elemente.ToString();
        }

        public void Add(T t)
        {
            Elemente.Add(t);
        }

        public void Remove(T menge)
        {
            Elemente.Remove(menge);
        }

        public Interfaces.IMenge<T> Copy()
        {
            Interfaces.IMenge<T> copy = LeereMenge;

            foreach (T t in Elemente)
            {
                copy.Elemente.Add(t);
            }

            return copy;
        }

        public bool Equals(Interfaces.IMenge<T>? other)
        {
            if (other == null) return false;

            return Elemente.IstGleich(other.Elemente);
        }
    }
}
