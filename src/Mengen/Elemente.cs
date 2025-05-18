namespace src.Mengen
{
    public class Elemente<T> :
        List<T>,
        Interfaces.ILeereMenge<Elemente<T>>,
        Interfaces.IKardinalitaet,
        Interfaces.IHatElement<T>,
        Interfaces.IElementMitIndex<T>,
        Interfaces.IIstTeilmengeVon<Elemente<T>>,
        Interfaces.IIstGleich<Elemente<T>>,
        Interfaces.IDurchschnitt<Elemente<T>>,
        Interfaces.IVereinigung<Elemente<T>>,
        Interfaces.IDifferenzMenge<Elemente<T>>,
        Interfaces.IToString,
        Interfaces.ICopy<Elemente<T>>,
        Library.Interfaces.IHashCode<Elemente<T>>,
        IEquatable<Elemente<T>>,
        //IEquatable<Element<Elemente<T>>>,
        Interfaces.IPotenzMenge<Elemente<T>>
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

        public Func<Elemente<T>, int> HashCodeFunction { get; set; }

        public Elemente() : base()
        {
            HashCodeFunction = (h) => { return h.Kardinalitaet(); };
        }

        public int Kardinalitaet()
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

        public int HashCode()
        {
            return HashCodeFunction(this);
        }

        public bool Equals(Elemente<T>? other)
        {
            return IstGleich(other);
        }

        public Elemente<Elemente<T>>? PotenzMenge()
        {
            Elemente<Elemente<T>> potenzmenge = new Elemente<Elemente<T>>();

            int potenzmengenKardinalität = 1;

            foreach (T element in this)
            {
                potenzmengenKardinalität *= 2;
            }

            foreach (T element in this)
            {
                PotenzmengenRekursion(potenzmenge, new Elemente<T>(), element, potenzmengenKardinalität);
            }

            return potenzmenge;
        }

        public void PotenzmengenRekursion(Elemente<Elemente<T>> potenzmenge, Elemente<T> teilmenge, T element, int potenzmengenKardinalität)
        {
            try
            {
                if (teilmenge.Kardinalitaet() <= Kardinalitaet())
                {
                    if (!potenzmenge.HatElement(teilmenge))
                    {
                        potenzmenge.Add(teilmenge.Copy());
                    }
                }

                if (teilmenge.Kardinalitaet() < Kardinalitaet())
                {
                    if (!teilmenge.HatElement(element))
                    {
                        teilmenge.Add(element);
                    }

                    if (!potenzmenge.HatElement(teilmenge))
                    {
                        potenzmenge.Add(teilmenge.Copy());
                    }
                }

                if (teilmenge.Kardinalitaet() < Kardinalitaet() &&
                    potenzmenge.Kardinalitaet() < potenzmengenKardinalität)
                {
                    foreach (T t in this)
                    {
                        if (teilmenge.HatElement(t))
                        {
                            continue;
                        }

                        PotenzmengenRekursion(potenzmenge, teilmenge.Copy(), t, potenzmengenKardinalität);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        //public bool Equals(Element<Elemente<T>>? other)
        //{
        //    if (other == null)
        //    {
        //        return false;
        //    }

        //    foreach (T element in this)
        //    {
        //        if (!other.Inhalt.Contains(element))
        //        {
        //            return false;
        //        }
        //    }

        //    foreach (T element in other.Inhalt)
        //    {
        //        if (!Contains(element))
        //        {
        //            return false;
        //        }
        //    }

        //    return true;
        //}
    }
}
