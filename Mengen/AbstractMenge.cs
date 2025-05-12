namespace Mengen
{
    public abstract class AbstractMenge<E> :
        AbstractMengeBase<E>,
        IEquatable<AbstractMenge<E>>,
        Interfaces.IEndlichkeit,
        Interfaces.IAbzaehlbarkeit,
        Interfaces.ILeereMenge<E>,
        Interfaces.IKardinalitaet,
        Interfaces.IHatElement<E>,
        Interfaces.IIstElementVon<AbstractMengeBase<E>>,
        Interfaces.IElementMitIndex<E>,
        Interfaces.IIstTeilmengeVon<AbstractMengeBase<E>>,
        Interfaces.IIstGleich<AbstractMengeBase<E>>,
        Interfaces.IDurchschnitt<AbstractMengeBase<E>>,
        Interfaces.IVereinigung<AbstractMengeBase<E>>,
        Interfaces.IDifferenzMenge<AbstractMengeBase<E>>,
        Interfaces.IToString,
        Interfaces.IPotenzMenge<AbstractMengeBase<E>>
        where E : IEquatable<E>
    {
        public AbstractMengeBase<AbstractMengeBase<E>>? Potenzmenge { get; set; }

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

        public void AddTeilmenge(AbstractMengeBase<E> teilmenge, E e, int kardinalitaet)
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

                teilmenge.Remove(e);
            }
        }

        public void PotenzmengenRekursion(AbstractMengeBase<E> teilmenge, int schleifen, int kardinalitaet)
        {
            if (schleifen > kardinalitaet)
            {
                return;
            }

            int index = 1;

            AbstractMengeBase<E> schleifenTeilmenge = LeereMenge();

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

        public bool Equals(AbstractMenge<E>? other)
        {
            if (other == null) return false;

            return IstGleich(other);
        }
    }
}