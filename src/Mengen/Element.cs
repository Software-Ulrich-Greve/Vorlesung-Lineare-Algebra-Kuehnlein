namespace src.Mengen
{
    public class Element<T> :
        //Library.Interfaces.IHashCode,
        Interfaces.IToString,
        Interfaces.IIstElementVon<Elemente<T>>,
        Interfaces.IIstGleich<Element<T>>,
        Interfaces.ICopy<Element<T>>,
        IEquatable<Element<Elemente<T>>>
        where T :
        IEquatable<T>

    {
        public T Inhalt { get; set; }

        public Func<T, int> TToHash { get; set; }

        public Func<T, string> TToString { get; set; }

        public Element(T inhalt, Func<T, int> tToHash, Func<T, string> tToString)
        {
            Inhalt = inhalt;

            TToHash = tToHash;

            TToString = tToString;
        }

        public int HashCode()
        {
            return TToHash(Inhalt);
        }

        public override string ToString()
        {
            return TToString(Inhalt);
        }

        public bool IstElementVon(Elemente<T>? elemente)
        {
            if (elemente == null)
            {
                return false;
            }

            if (elemente.HatElement(Inhalt))
            {
                return true;
            }

            return false;
        }

        public bool IstGleich(Element<T>? element)
        {
            if (element == null)
            {
                return false;
            }

            return Inhalt.Equals(element.Inhalt);
        }

        public Element<T> Copy()
        {
            return new Element<T>(Inhalt, TToHash, TToString);
        }

        public bool Equals(Element<T>? other)
        {
            return IstGleich(other);
        }

        public bool Equals(Element<Elemente<T>>? other)
        {
            if (other == null)
            {
                return false;
            }

            return other.Inhalt.Equals(Inhalt);
        }
    }
}
