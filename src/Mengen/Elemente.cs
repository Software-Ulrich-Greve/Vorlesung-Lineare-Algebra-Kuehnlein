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
        IEquatable<Elemente<T>>,
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

        public Elemente<Elemente<T>>? PotenzMenge()
        {
            Elemente<Elemente<T>> potenzmenge = new Elemente<Elemente<T>>();

            if (Kardinalitaet == null)
            {
                return null;
            }

            for (int kardinalitaet = 0; kardinalitaet <= Count; kardinalitaet++)
            {
                Console.WriteLine();

                Console.WriteLine("Kardinalitaet: " + kardinalitaet);

                if (kardinalitaet == 0)
                {
                    potenzmenge.Add(new Elemente<T>());

                    Console.WriteLine();

                    Console.WriteLine(potenzmenge.ToString());

                    continue;
                }

                PotenzmengenRekursion(potenzmenge, new Elemente<T>(), 1, kardinalitaet);

                Console.WriteLine();

                Console.WriteLine(potenzmenge.ToString());
            }

            return potenzmenge;
        }

        public void PotenzmengenRekursion(Elemente<Elemente<T>> potenzmenge, Elemente<T> teilmenge, int schleifen, int kardinalitaet)
        {
            if (schleifen > kardinalitaet)
            {
                return;
            }

            int index = 1;

            Elemente<T> schleifenTeilmenge = new Elemente<T>();

            foreach (T t in this)
            {
                if (!schleifenTeilmenge.HatElement(t) &&
                    index > schleifen)
                {
                    schleifenTeilmenge.Add(t);
                }

                if (!teilmenge.HatElement(t))
                {
                    teilmenge.Add(t);
                }

                AddTeilmenge(potenzmenge, schleifenTeilmenge, t, kardinalitaet);

                AddTeilmenge(potenzmenge, teilmenge, t, kardinalitaet);

                PotenzmengenRekursion(potenzmenge, teilmenge.Copy(), schleifen + 1, kardinalitaet);

                Console.Write('.');

                index++;
            }
        }

        public void AddTeilmenge(Elemente<Elemente<T>> potenzmenge, Elemente<T> teilmenge, T t, int kardinalitaet)
        {
            if (teilmenge.Count.Equals(kardinalitaet))
            {
                if (!potenzmenge.HatElement(teilmenge))
                {
                    potenzmenge.Add(teilmenge.Copy());

                }

                teilmenge.Remove(t);
            }
        }
    }
}
