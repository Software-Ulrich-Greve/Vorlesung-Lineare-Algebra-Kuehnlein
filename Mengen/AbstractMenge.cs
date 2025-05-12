namespace Mengen
{
    public abstract class AbstractMenge<T> :
        List<T>,
        IEquatable<AbstractMenge<T>>,
        Interfaces.IEndlichkeit,
        Interfaces.IAbzaehlbarkeit,
        Interfaces.ILeereMenge<T>,
        Interfaces.ILeereMengeDerMengen<AbstractMenge<T>>,
        Interfaces.IKardinalitaet,
        Interfaces.IHatElement<T>,
        Interfaces.IIstElementVon<AbstractMenge<T>>,
        Interfaces.IElementMitIndex<T>,
        Interfaces.IIstTeilmengeVon<AbstractMenge<T>>,
        Interfaces.IIstGleich<AbstractMenge<T>>,
        Interfaces.IDurchschnitt<AbstractMenge<T>>,
        Interfaces.IVereinigung<AbstractMenge<T>>,
        Interfaces.IDifferenzMenge<AbstractMenge<T>>,
        Interfaces.IToString,
        Interfaces.IPotenzMenge<AbstractMenge<T>>
        where T : IEquatable<T>
    {
        public abstract bool IstEndlich { get; }

        public abstract bool IstAbzaehlbar { get; }

        public abstract AbstractMenge<T> LeereMenge();

        public abstract AbstractMenge<AbstractMenge<T>> LeereMengeDerMengen();

        public AbstractMenge<AbstractMenge<T>>? Potenzmenge { get; set; }

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

        public bool IstElementVon(AbstractMenge<AbstractMenge<T>> menge)
        {
            foreach (AbstractMenge<T> m in menge)
            {
                if (IstGleich(m))
                {
                    return true;
                }
            }

            return false;
        }

        public T GetElementMitIndex(int index)
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

        public bool IstTeilmengeVon(AbstractMenge<T> menge)
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

        public bool IstGleich(AbstractMenge<T> menge)
        {
            if (menge == null)
            {
                return false;
            }

            if (IstTeilmengeVon(menge) &&
                menge.IstTeilmengeVon(this))
            {
                return true;
            }

            return false;
        }

        public AbstractMenge<T> Durchschnitt(AbstractMenge<T> mengeDerMengen)
        {
            AbstractMenge<T> durchschnitt = LeereMenge();

            foreach (T t in this)
            {
                if (!mengeDerMengen.HatElement(t))
                {
                    durchschnitt.Add(t);
                }
            }

            return durchschnitt;
        }

        public AbstractMenge<T> Vereinigung(AbstractMenge<T> menge)
        {
            AbstractMenge<T> vereinigung = menge;

            foreach (T t in this)
            {
                if (!vereinigung.HatElement(t))
                {
                    vereinigung.Add(t);
                }
            }

            return vereinigung;
        }

        public AbstractMenge<T> DifferenzMenge(AbstractMenge<T> menge)
        {
            AbstractMenge<T> differenzMenge = this;

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
                ausgabe += GetElementMitIndex(i).ToString();

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

        public void AddTeilmenge(AbstractMenge<T> teilmenge, T t, int kardinalitaet)
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

        public void PotenzmengenRekursion(AbstractMenge<T> teilmenge, int schleifen, int kardinalitaet)
        {
            if (schleifen > kardinalitaet)
            {
                return;
            }

            int index = 1;

            AbstractMenge<T> schleifenTeilmenge = LeereMenge();

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

        public AbstractMenge<T> Copy()
        {
            AbstractMenge<T> copy = LeereMenge();

            foreach (T t in this)
            {
                copy.Add(t);
            }

            return copy;
        }

        public bool Equals(AbstractMenge<T>? other)
        {
            if (other == null) return false;

            return IstGleich(other);

        }
    }
}
