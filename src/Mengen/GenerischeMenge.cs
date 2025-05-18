namespace src.Mengen
{
    public class GenerischeMenge<TElement> :
        List<TElement>,
        Interfaces.IGenerischeMenge<TElement>,
        Interfaces.ILeereMenge<GenerischeMenge<TElement>>,
        Interfaces.IKardinalitaet,
        Interfaces.IHatElement<TElement>,
        Interfaces.IElementMitIndex<TElement>,
        Interfaces.IIstTeilmengeVon<GenerischeMenge<TElement>>,
        Interfaces.IIstGleich<GenerischeMenge<TElement>>,
        Interfaces.IDurchschnitt<GenerischeMenge<TElement>>,
        Interfaces.IVereinigung<GenerischeMenge<TElement>>,
        Interfaces.IDifferenzMenge<GenerischeMenge<TElement>>,
        Interfaces.IToString,
        Interfaces.ICopy<GenerischeMenge<TElement>>,
        Library.Interfaces.IHashCode<GenerischeMenge<TElement>>,
        Interfaces.IPotenzMenge<GenerischeMenge<TElement>>,
        IEquatable<GenerischeMenge<TElement>>
        where TElement :
        IEquatable<TElement>

    {
        public GenerischeMenge<TElement> LeereMenge
        {
            get
            {
                return new GenerischeMenge<TElement>();
            }
        }

        public int Kardinalitaet
        {
            get
            {
                return Count;
            }
        }

        public int KardinalitaetPotenzmenge
        {
            get
            {
                int kardinalitaetPotenzmenge = 1;

                foreach (TElement element in this)
                {
                    kardinalitaetPotenzmenge *= 2;
                }

                return kardinalitaetPotenzmenge;
            }
        }

        public Func<GenerischeMenge<TElement>, int> HashCodeFunction { get; set; }

        public GenerischeMenge() : base()
        {
            HashCodeFunction = (h) => { return h.Kardinalitaet; };
        }

        public bool HatElement(TElement? element)
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

        public TElement ElementMitIndex(int index)
        {
            int i = 0;

            foreach (TElement element in this)
            {
                if (i.Equals(index))
                {
                    return element;
                }

                i++;
            }

            throw new KeyNotFoundException();
        }

        public bool IstTeilmengeVon(GenerischeMenge<TElement>? elemente)
        {
            if (elemente == null)
            {
                return false;
            }

            foreach (TElement element in this)
            {
                if (!elemente.Contains(element))
                {
                    return false;
                }
            }

            return true;
        }

        public bool IstGleich(GenerischeMenge<TElement>? elemente)
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

        public GenerischeMenge<TElement> Durchschnitt(GenerischeMenge<TElement>? elemente)
        {
            GenerischeMenge<TElement> durchschnitt = new GenerischeMenge<TElement>();

            if (elemente == null)
            {
                return durchschnitt;
            }

            foreach (TElement element in elemente)
            {
                if (HatElement(element))
                {
                    durchschnitt.Add(element);
                }
            }

            return durchschnitt;
        }

        public GenerischeMenge<TElement> Vereinigung(GenerischeMenge<TElement>? elemente)
        {
            GenerischeMenge<TElement> vereinigung = this;

            if (elemente == null)
            {
                return vereinigung;
            }

            foreach (TElement element in elemente)
            {
                if (!vereinigung.HatElement(element))
                {
                    vereinigung.Add(element);
                }
            }

            return vereinigung;
        }

        public GenerischeMenge<TElement> Differenzmenge(GenerischeMenge<TElement>? elemente)
        {
            GenerischeMenge<TElement> differenzMenge = this;

            if (elemente == null)
            {
                return differenzMenge;
            }

            foreach (TElement element in elemente)
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

        public GenerischeMenge<TElement> Copy()
        {
            GenerischeMenge<TElement> copy = LeereMenge;

            foreach (TElement element in this)
            {
                copy.Add(element);
            }

            return copy;
        }

        public int HashCode()
        {
            return HashCodeFunction(this);
        }

        public GenerischeMenge<GenerischeMenge<TElement>>? Potenzmenge()
        {
            GenerischeMenge<GenerischeMenge<TElement>> potenzmenge = new GenerischeMenge<GenerischeMenge<TElement>>();

            foreach (TElement element in this)
            {
                PotenzmengenRekursion(potenzmenge, new GenerischeMenge<TElement>(), element);
            }

            return potenzmenge;
        }

        public void PotenzmengenRekursion(GenerischeMenge<GenerischeMenge<TElement>> aktuellePotenzmenge, GenerischeMenge<TElement> aktuelleTeilmenge, TElement aktuellesElement)
        {
            try
            {
                if (aktuelleTeilmenge.Kardinalitaet <= Kardinalitaet)
                {
                    if (!aktuellePotenzmenge.HatElement(aktuelleTeilmenge))
                    {
                        aktuellePotenzmenge.Add(aktuelleTeilmenge.Copy());
                    }
                }

                if (aktuelleTeilmenge.Kardinalitaet < Kardinalitaet)
                {
                    if (!aktuelleTeilmenge.HatElement(aktuellesElement))
                    {
                        aktuelleTeilmenge.Add(aktuellesElement);
                    }

                    if (!aktuellePotenzmenge.HatElement(aktuelleTeilmenge))
                    {
                        aktuellePotenzmenge.Add(aktuelleTeilmenge.Copy());
                    }
                }

                if (aktuelleTeilmenge.Kardinalitaet < Kardinalitaet &&
                    aktuellePotenzmenge.Kardinalitaet < KardinalitaetPotenzmenge)
                {
                    foreach (TElement element in this)
                    {
                        if (aktuelleTeilmenge.HatElement(element))
                        {
                            continue;
                        }

                        PotenzmengenRekursion(aktuellePotenzmenge, aktuelleTeilmenge.Copy(), element);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public bool Equals(GenerischeMenge<TElement>? other)
        {
            return IstGleich(other);
        }
    }
}
