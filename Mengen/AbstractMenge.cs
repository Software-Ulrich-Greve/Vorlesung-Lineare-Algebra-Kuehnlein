using Mengen.Interfaces;

namespace Mengen
{
    public abstract class AbstractMenge<E> :
        List<E>,
        IEquatable<AbstractMenge<E>>,
        Interfaces.IEndlichkeit,
        Interfaces.IAbzaehlbarkeit,
        Interfaces.ILeereMenge<E>,
        Interfaces.IKardinalitaet,
        Interfaces.IHatElement<E>,
        Interfaces.IIstElementMengeVon<E>,
        Interfaces.IIstTeilmengeVon<AbstractMenge<E>>,
        Interfaces.IIstGleich<AbstractMenge<E>>,
        Interfaces.IDurchschnitt<AbstractMenge<E>>,
        Interfaces.IVereinigung<AbstractMenge<E>>,
        Interfaces.IDifferenzMenge<AbstractMenge<E>>
        where E : IEquatable<E>
    {
        public abstract bool IstEndlich { get; }

        public abstract bool IstAbzaehlbar { get; }

        public abstract AbstractMenge<E> LeereMenge();

        public abstract AbstractMengeDerMengen<E> LeereMengeDerTeilmengen();

        public AbstractMengeDerMengen<E> Potenzmenge { get; set; }

        public int? Kardinalitaet()
        {
            if (!IstEndlich)
            {
                return null;
            }

            return base.Count;
        }

        public bool HatElement(E element)
        {
            foreach (E e in this)
            {
                if (e.Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IstElementMengeVon(AbstractMengeDerMengen<E> menge)
        {
            foreach (AbstractMenge<E> m in menge)
            {
                if (IstGleich(m))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IstTeilmengeVon(AbstractMenge<E> menge)
        {
            foreach (E e in this)
            {
                if (!menge.HatElement(e))
                {
                    return false;
                }
            }

            return true;
        }

        public bool IstGleich(AbstractMenge<E> menge)
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

        public AbstractMenge<E> Durchschnitt(AbstractMenge<E> menge)
        {
            AbstractMenge<E> durchschnitt = LeereMenge();

            foreach (E e in this)
            {
                if (!menge.HatElement(e))
                {
                    durchschnitt.Add(e);
                }
            }

            return durchschnitt;
        }

        public AbstractMenge<E> Vereinigung(AbstractMenge<E> menge)
        {
            AbstractMenge<E> vereinigung = menge;

            foreach (E e in this)
            {
                if (!vereinigung.HatElement(e))
                {
                    vereinigung.Add(e);
                }
            }

            return vereinigung;
        }

        public AbstractMenge<E> DifferenzMenge(AbstractMenge<E> menge)
        {
            AbstractMenge<E> differenzMenge = this;

            foreach (E e in menge)
            {
                if (differenzMenge.HatElement(e))
                {
                    differenzMenge.Remove(e);
                }
            }

            return differenzMenge;
        }

        public new string ToString()
        {
            string ausgabe = "{";

            for (int i = 0; i < Count; i++)
            {
                ausgabe += ToArray()[i].ToString();

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
            Potenzmenge = LeereMengeDerTeilmengen();

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

        public void AddTeilmenge(AbstractMenge<E> teilmenge, E e, int kardinalitaet)
        {
            if (teilmenge.Count.Equals(kardinalitaet))
            {
                if (!teilmenge.IstElementMengeVon(Potenzmenge))
                {
                    Potenzmenge.Add(teilmenge.Copy());

                    Console.WriteLine();

                    Console.Write("----------");

                    Console.Write(Potenzmenge.ToString());

                    Console.WriteLine("----------");
                }

                teilmenge.Remove(e);
            }
        }

        public void PotenzmengenRekursion(AbstractMenge<E> teilmenge, int schleifen, int kardinalitaet)
        {
            if (schleifen > kardinalitaet)
            {
                return;
            }

            int index = 1;

            AbstractMenge<E> schleifenTeilmenge = LeereMenge();

            foreach (E e in this)
            {
                if (!schleifenTeilmenge.HatElement(e) &&
                    index > schleifen)
                {
                    schleifenTeilmenge.Add(e);
                }

                if (!teilmenge.HatElement(e))
                {
                    teilmenge.Add(e);
                }

                Console.Write("i" + index + "s" + schleifen + teilmenge.ToString());

                Console.Write(".");

                AddTeilmenge(schleifenTeilmenge, e, kardinalitaet);

                AddTeilmenge(teilmenge, e, kardinalitaet);

                PotenzmengenRekursion(teilmenge.Copy(), schleifen + 1, kardinalitaet);

                Console.WriteLine();

                Console.WriteLine($"s({schleifen});i({index})");

                index++;
            }
        }

        public new void Add(E element)
        {
            base.Add(element);
        }

        public new void Remove(E element)
        {
            base.Remove(element);
        }

        public AbstractMenge<E> Copy()
        {
            AbstractMenge<E> copy = LeereMenge();

            foreach (E element in this)
            {
                copy.Add(element);
            }

            return copy;
        }

        public bool Equals(AbstractMenge<E>? other)
        {
            if (other == null) return false;

            return IstGleich(other);
        }
    }
}
