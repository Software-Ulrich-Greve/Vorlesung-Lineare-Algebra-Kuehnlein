namespace src.Mengen
{
    public abstract class AbstractMenge<T> :
        List<T>,
        IList<T>,
        IEquatable<Interfaces.IMenge<T>>,
        Interfaces.IEndlichkeit,
        Interfaces.IAbzaehlbarkeit,
        Interfaces.ILeereMenge<T>,
        Interfaces.ILeereMengeDerMengen<Interfaces.IMenge<T>>,
        Interfaces.IKardinalitaet,
        Interfaces.IHatElement<T>,
        Interfaces.IIstElementVon<Interfaces.IMenge<T>>,
        Interfaces.IElementMitIndex<T>,
        Interfaces.IIstTeilmengeVon<Interfaces.IMenge<T>>,
        Interfaces.IIstGleich<Interfaces.IMenge<T>>,
        Interfaces.IDurchschnitt<Interfaces.IMenge<T>>,
        Interfaces.IVereinigung<Interfaces.IMenge<T>>,
        Interfaces.IDifferenzMenge<Interfaces.IMenge<T>>,
        Interfaces.IToString,
        Interfaces.IPotenzMenge<Interfaces.IMenge<T>>
        where T : IEquatable<T>
    {
        public abstract bool IstEndlich { get; }

        public abstract bool IstAbzaehlbar { get; }

        public abstract Interfaces.IMenge<T> LeereMenge();

        public abstract Interfaces.IMenge<Interfaces.IMenge<T>> LeereMengeDerMengen();

        public Interfaces.IMenge<Interfaces.IMenge<T>>? Potenzmenge { get; set; }

        public int? Kardinalitaet()
        {
            if (!IstEndlich)
            {
                return null;
            }

            return base.Count;
        }

        public bool HatElement(T element)
        {
            foreach (T t in this)
            {
                if (t.Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IstElementVon(Interfaces.IMenge<Interfaces.IMenge<T>> menge)
        {
            foreach (Interfaces.IMenge<T> m in menge)
            {
                if (IstGleich(m))
                {
                    return true;
                }
            }

            return false;
        }

        public T ElementMitIndex(int index)
        {
            int i = 0;

            foreach (T t in this)
            {
                if (i.Equals(index))
                {
                    return t;
                }

                i++;
            }

            throw new KeyNotFoundException();
        }

        public bool IstTeilmengeVon(Interfaces.IMenge<T> menge)
        {
            foreach (T t in this)
            {
                if (!menge.HatElement(t))
                {
                    return false;
                }
            }

            return true;
        }

        public bool IstGleich(Interfaces.IMenge<T> menge)
        {
            if (menge == null)
            {
                return false;
            }

            if (IstTeilmengeVon(menge) &&
                menge.IstTeilmengeVon((Interfaces.IMenge<T>)this))
            {
                return true;
            }

            return false;
        }

        public Interfaces.IMenge<T> Durchschnitt(Interfaces.IMenge<T> mengeDerMengen)
        {
            Interfaces.IMenge<T> durchschnitt = LeereMenge();

            foreach (T t in this)
            {
                if (!mengeDerMengen.HatElement(t))
                {
                    durchschnitt.Add(t);
                }
            }

            return durchschnitt;
        }

        public Interfaces.IMenge<T> Vereinigung(Interfaces.IMenge<T> menge)
        {
            Interfaces.IMenge<T> vereinigung = menge;

            foreach (T t in this)
            {
                if (!vereinigung.HatElement(t))
                {
                    vereinigung.Add(t);
                }
            }

            return vereinigung;
        }

        public Interfaces.IMenge<T> DifferenzMenge(Interfaces.IMenge<T> menge)
        {
            Interfaces.IMenge<T> differenzMenge = (Interfaces.IMenge<T>)this;

            foreach (T t in this)
            {
                if (differenzMenge.HatElement(t))
                {
                    differenzMenge.Remove(t);
                }
            }

            return differenzMenge;
        }

        public override string ToString()
        {
            string ausgabe = "{";

            for (int i = 0; i < Count; i++)
            {
                ausgabe += ElementMitIndex(i).ToString();

                if (i < Count - 1)
                {
                    ausgabe += ";";
                }
            }

            ausgabe += "}";

            return ausgabe;
        }

        public void BerechnePotenzMenge()
        {
            Potenzmenge = LeereMengeDerMengen();

            if (Kardinalitaet == null)
            {
                return;
            }

            for (int kardinalitaet = 0; kardinalitaet <= Count; kardinalitaet++)
            {
                Console.WriteLine();

                Console.WriteLine("---------------------------------> Kardinalitaet: " + kardinalitaet);

                if (kardinalitaet == 0)
                {
                    Potenzmenge.Add(LeereMenge());

                    Console.WriteLine();

                    Console.Write("----------");

                    Console.Write(Potenzmenge.ToString());

                    Console.WriteLine("----------");

                    continue;
                }

                PotenzmengenRekursion(LeereMenge(), 1, kardinalitaet);
            }

            Console.WriteLine("=================================");

            Console.WriteLine();

            Console.Write("----------");

            Console.Write(Potenzmenge.ToString());

            Console.WriteLine("----------");
        }

        public void AddTeilmenge(Interfaces.IMenge<T> teilmenge, T t, int kardinalitaet)
        {
            if (Potenzmenge == null)
            {
                return;
            }

            if (teilmenge.Count.Equals(kardinalitaet))
            {
                if (!teilmenge.IstElementVon(Potenzmenge))
                {
                    Potenzmenge.Add(teilmenge.Copy());

                    Console.WriteLine();

                    Console.Write("----------");

                    Console.Write(Potenzmenge.ToString());

                    Console.WriteLine("----------");
                }

                teilmenge.Remove(t);
            }
        }

        public void PotenzmengenRekursion(Interfaces.IMenge<T> teilmenge, int schleifen, int kardinalitaet)
        {
            if (schleifen > kardinalitaet)
            {
                return;
            }

            int index = 1;

            Interfaces.IMenge<T> schleifenTeilmenge = LeereMenge();

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

                Console.Write("i" + index + "s" + schleifen + teilmenge.ToString());

                Console.Write(".");

                AddTeilmenge(schleifenTeilmenge, t, kardinalitaet);

                AddTeilmenge(teilmenge, t, kardinalitaet);

                PotenzmengenRekursion(teilmenge.Copy(), schleifen + 1, kardinalitaet);

                Console.WriteLine();

                Console.WriteLine($"s({schleifen});i({index})");

                index++;
            }
        }
        public new void Add(T t)
        {
            base.Add(t);
        }

        public new void Remove(T menge)
        {
            base.Remove(menge);
        }

        public Interfaces.IMenge<T> Copy()
        {
            Interfaces.IMenge<T> copy = LeereMenge();

            foreach (T t in this)
            {
                copy.Add(t);
            }

            return copy;
        }

        public bool Equals(Interfaces.IMenge<T>? other)
        {
            if (other == null) return false;

            return IstGleich(other);

        }
    }
}
