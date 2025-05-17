namespace src.Mengen
{
    public class Elemente<T> :
        List<T>,
        IEquatable<Elemente<T>>,
        Interfaces.ILeereMenge<Elemente<T>>,
        Interfaces.IKardinalitaet,
        Interfaces.IHatElement<T>,
        Interfaces.IElementMitIndex<T>,
        Interfaces.IIstTeilmengeVon<Elemente<T>>,
        Interfaces.IIstGleich<Elemente<T>>,
        Interfaces.IDurchschnitt<Elemente<T>>,
        Interfaces.IVereinigung<Elemente<T>>,
        Interfaces.IDifferenzMenge<Elemente<T>>,
        //Interfaces.IIstElementVon<Elemente<Elemente<T>>>,
        Interfaces.IToString,
        Interfaces.ICopy<Elemente<T>>
        where T :
        IEquatable<T>

    {
        public Elemente<T> LeereMenge
        {
            get
            {
                return new Elemente<T>();
            }
        }

        public Elemente() : base()
        {
        }

        public int? Kardinalitaet()
        {
            return Count;
        }

        public bool HatElement(T? element)
        {
            if (element == null)
            {
                return false;
            }

            if (Contains(element))
            {
                return true;
            }

            return false;
        }

        public T ElementMitIndex(int index)
        {
            int i = 0;

            foreach (T element in this)
            {
                if (i.Equals(index))
                {
                    return element;
                }

                i++;
            }

            throw new KeyNotFoundException();
        }

        public bool IstTeilmengeVon(Elemente<T>? elemente)
        {
            if (elemente == null)
            {
                return false;
            }

            foreach (T element in this)
            {
                if (!elemente.Contains(element))
                {
                    return false;
                }
            }

            return true;
        }

        public bool IstGleich(Elemente<T>? elemente)
        {
            if (elemente == null)
            {
                return false;
            }

            if (IstTeilmengeVon(elemente) &&
                elemente.IstTeilmengeVon(this))
            {
                return true;
            }

            return false;
        }

        public Elemente<T> Durchschnitt(Elemente<T>? elemente)
        {
            Elemente<T> durchschnitt = new Elemente<T>();

            if (elemente == null)
            {
                return durchschnitt;
            }

            foreach (T element in elemente)
            {
                if (!elemente.HatElement(element))
                {
                    durchschnitt.Add(element);
                }
            }

            return durchschnitt;
        }

        public Elemente<T> Vereinigung(Elemente<T>? elemente)
        {
            Elemente<T> vereinigung = this;

            if (elemente == null)
            {
                return vereinigung;
            }

            foreach (T element in elemente)
            {
                if (!vereinigung.HatElement(element))
                {
                    vereinigung.Add(element);
                }
            }

            return vereinigung;
        }

        public Elemente<T> DifferenzMenge(Elemente<T>? elemente)
        {
            Elemente<T> differenzMenge = this;

            if (elemente == null)
            {
                return differenzMenge;
            }

            foreach (T element in elemente)
            {
                if (differenzMenge.HatElement(element))
                {
                    differenzMenge.Remove(element);
                }
            }

            return differenzMenge;
        }

        //public bool IstElementVon(Elemente<Elemente<T>>? elemente)
        //{
        //    if (elemente == null)
        //    {
        //        return false;
        //    }

        //    foreach (Elemente<T> e in elemente)
        //    {
        //        if (IstGleich(e))
        //        {
        //            return true;
        //        }
        //    }

        //    return false;
        //}

        public override string ToString()
        {
            string text = "{";

            for (int i = 0; i < Count; i++)
            {
                text += ElementMitIndex(i)?.ToString();

                if (i < Count - 1)
                {
                    text += ";";
                }
            }

            text += "}";

            return text;
        }

        public Elemente<T> Copy()
        {
            Elemente<T> copy = LeereMenge;

            foreach (T element in this)
            {
                copy.Add(element);
            }

            return copy;
        }

        public bool Equals(Elemente<T>? other)
        {
            return IstGleich(other);
        }
    }
}
