namespace Mengen
{
    public abstract class AbstractMengeBase<T> :
        List<T>,
        IEquatable<AbstractMengeBase<T>>,
        Interfaces.IEndlichkeit,
        Interfaces.IAbzaehlbarkeit,
        Interfaces.ILeereMenge<T>,
        Interfaces.IKardinalitaet,
        Interfaces.IHatElement<T>,
        Interfaces.IIstElementVon<AbstractMengeBase<T>>,
        Interfaces.IElementMitIndex<T>,
        Interfaces.IIstTeilmengeVon<AbstractMengeBase<T>>,
        Interfaces.IIstGleich<AbstractMengeBase<T>>,
        Interfaces.IDurchschnitt<AbstractMengeBase<T>>,
        Interfaces.IVereinigung<AbstractMengeBase<T>>,
        Interfaces.IDifferenzMenge<AbstractMengeBase<T>>,
        Interfaces.IToString
        where T : IEquatable<T>
    {
        public abstract bool IstEndlich { get; }

        public abstract bool IstAbzaehlbar { get; }

        public abstract AbstractMengeBase<T> LeereMenge();

        public abstract AbstractMengeBase<AbstractMengeBase<T>> LeereMengeDerMengen();

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

        public bool IstElementVon(AbstractMengeBase<AbstractMengeBase<T>> menge)
        {
            foreach (AbstractMengeBase<T> m in menge)
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

        public bool IstTeilmengeVon(AbstractMengeBase<T> menge)
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

        public bool IstGleich(AbstractMengeBase<T> menge)
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

        public AbstractMengeBase<T> Durchschnitt(AbstractMengeBase<T> mengeDerMengen)
        {
            AbstractMengeBase<T> durchschnitt = LeereMenge();

            foreach (T t in this)
            {
                if (!mengeDerMengen.HatElement(t))
                {
                    durchschnitt.Add(t);
                }
            }

            return durchschnitt;
        }

        public AbstractMengeBase<T> Vereinigung(AbstractMengeBase<T> menge)
        {
            AbstractMengeBase<T> vereinigung = menge;

            foreach (T t in this)
            {
                if (!vereinigung.HatElement(t))
                {
                    vereinigung.Add(t);
                }
            }

            return vereinigung;
        }

        public AbstractMengeBase<T> DifferenzMenge(AbstractMengeBase<T> menge)
        {
            AbstractMengeBase<T> differenzMenge = this;

            foreach (T t in this)
            {
                if (differenzMenge.HatElement(t))
                {
                    differenzMenge.Remove(t);
                }
            }

            return differenzMenge;
        }

        public new string ToString()
        {
            string ausgabe = "{";

            for (int i = 0; i < Count; i++)
            {
                ausgabe += (ToArray()[i]).ToString();

                if (i < Count - 1)
                {
                    ausgabe += ";";
                }
            }

            ausgabe += "}";

            return ausgabe;
        }

        public new void Add(T t)
        {
            base.Add(t);
        }

        public new void Remove(T menge)
        {
            base.Remove(menge);
        }

        public AbstractMengeBase<T> Copy()
        {
            AbstractMengeBase<T> copy = LeereMenge();

            foreach (T t in this)
            {
                copy.Add(t);
            }

            return copy;
        }

        public bool Equals(AbstractMengeBase<T>? other)
        {
            if (other == null) return false;

            return IstGleich(other);

        }
    }
}
