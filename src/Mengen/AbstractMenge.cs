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
        //Interfaces.IIstElementVon<Interfaces.IMenge<Interfaces.IMenge<T>>>,
        Interfaces.IToString,
        Interfaces.IPotenzMenge<Elemente<T>>,
        Interfaces.ICopy<Interfaces.IMenge<T>>,
        Interfaces.IMenge<T>
        where T : 
        IEquatable<T>
    {
        public abstract bool IstEndlich { get; }

        public abstract bool IstAbzaehlbar { get; }

        public Interfaces.IMenge<T> LeereMenge { get; set; }

        public Elemente<T> Elemente { get; set; }

        public Elemente<Elemente<T>> Potenzmenge { get; set; }

        public AbstractMenge() : base()
        {
            Elemente = new Elemente<T>();

            Potenzmenge = new Elemente<Elemente<T>>();

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

        //public bool IstElementVon(Interfaces.IMenge<Interfaces.IMenge<T>>? menge)
        //{
        //    if (menge == null)
        //    {
        //        return false;
        //    }

        //    foreach (Elemente<T> e in menge.Elemente)
        //    {
        //        if (Elemente.IstGleich(e))
        //        {
        //            return true;
        //        }
        //    }

        //    return false;
        //}

        public override string ToString()
        {
            return Elemente.ToString();
        }

        public void BerechnePotenzMenge()
        {
            try
            {
                if (Kardinalitaet == null ||
                    Potenzmenge == null)
                {
                    return;
                }

                for (int kardinalitaet = 0; kardinalitaet <= Elemente.Count; kardinalitaet++)
                {
                    Console.WriteLine();

                    Console.WriteLine("Kardinalitaet: " + kardinalitaet);

                    if (kardinalitaet == 0)
                    {
                        Potenzmenge.Add(new Elemente<T>());

                        Console.WriteLine();

                        Console.WriteLine(Potenzmenge.ToString());

                        continue;
                    }

                    PotenzmengenRekursion(new Elemente<T>(), 1, kardinalitaet);

                    Console.WriteLine();

                    Console.WriteLine(Potenzmenge.ToString());
                }
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.ToString()); 
            }
        }

        public void PotenzmengenRekursion(Elemente<T> teilmenge, int schleifen, int kardinalitaet)
        //public void PotenzmengenRekursion(Interfaces.IMenge<T> teilmenge, int schleifen, int kardinalitaet)
        {
            if (schleifen > kardinalitaet)
            {
                return;
            }

            int index = 1;

            Elemente<T> schleifenTeilmenge = new Elemente<T>();
            //Interfaces.IMenge<T> schleifenTeilmenge = LeereMenge;

            foreach (T t in Elemente)
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

                AddTeilmenge(schleifenTeilmenge, t, kardinalitaet);

                AddTeilmenge(teilmenge, t, kardinalitaet);

                PotenzmengenRekursion(teilmenge.Copy(), schleifen + 1, kardinalitaet);

                Console.Write('.');

                index++;
            }
        }

        public void AddTeilmenge(Elemente<T> teilmenge, T t, int kardinalitaet)
        //public void AddTeilmenge(Interfaces.IMenge<T> teilmenge, T t, int kardinalitaet)
        {
            if (Potenzmenge == null)
            {
                return;
            }

            if (teilmenge.Count.Equals(kardinalitaet))
            {
                if (!Potenzmenge.HatElement(teilmenge))
                {
                    Potenzmenge.Add(teilmenge.Copy());

                }

                teilmenge.Remove(t);
            }
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

        //public bool Equals(AbstractMenge<T>? other)
        //{
        //    if (other == null) return false;

        //    return IstGleich(other);
        //}
    }
}
