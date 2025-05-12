using System;

namespace Mengen
{
    public abstract class AbstractMengeDerMengen<E> :
        List<List<E>>,
        IEquatable<AbstractMengeDerMengen<E>>,
        Interfaces.IEndlichkeit,
        Interfaces.IAbzaehlbarkeit,
        Interfaces.ILeereMengeDerMengen<E>,
        Interfaces.IKardinalitaet,
        Interfaces.IHatElementMenge<AbstractMenge<E>>,
        Interfaces.IIstTeilmengeVon<AbstractMengeDerMengen<E>>,
        Interfaces.IIstGleich<AbstractMengeDerMengen<E>>,
        Interfaces.IDurchschnitt<AbstractMengeDerMengen<E>>,
        Interfaces.IVereinigung<AbstractMengeDerMengen<E>>,
        Interfaces.IDifferenzMenge<AbstractMengeDerMengen<E>>
        where E : IEquatable<E>
    {
        public abstract bool IstEndlich { get; }

        public abstract bool IstAbzaehlbar { get; }

        public abstract AbstractMengeDerMengen<E> LeereMenge();

        public int? Kardinalitaet()
        {
            if (!IstEndlich)
            {
                return null;
            }

            return base.Count;
        }

        public bool HatElementMenge(AbstractMenge<E> menge)
        {
            foreach (AbstractMenge<E> e in this)
            {
                if (e.Equals(menge))
                {
                    return true;
                }
            }

            return false;
        }

        public AbstractMenge<E>? GetElementMengeWithIndex(int index)
        {
            int i = 0;

            foreach (AbstractMenge<E> e in this)
            {
                if (i.Equals(index))
                {
                    return e;
                }
            }

            return null;
        }

        public bool IstTeilmengeVon(AbstractMengeDerMengen<E> mengeDerMengen)
        {
            foreach (AbstractMenge<E> m in this)
            {
                if (!mengeDerMengen.HatElementMenge(m))
                {
                    return false;
                }
            }

            return true;
        }

        public bool IstGleich(AbstractMengeDerMengen<E> mengeDerMengen)
        {
            if (mengeDerMengen == null)
            {
                return false;
            }

            if (IstTeilmengeVon(mengeDerMengen) &&
                mengeDerMengen.IstTeilmengeVon(this))
            {
                return true;
            }

            return false;
        }

        public AbstractMengeDerMengen<E> Durchschnitt(AbstractMengeDerMengen<E> mengeDerMengen)
        {
            AbstractMengeDerMengen<E> durchschnitt = LeereMenge();

            foreach (AbstractMenge<E> m in this)
            {
                if (!mengeDerMengen.HatElementMenge(m))
                {
                    durchschnitt.Add(m);
                }
            }

            return durchschnitt;
        }

        public AbstractMengeDerMengen<E> Vereinigung(AbstractMengeDerMengen<E> mengeDerMengen)
        {
            AbstractMengeDerMengen<E> vereinigung = mengeDerMengen;

            foreach (AbstractMenge<E> m in this)
            {
                if (!vereinigung.HatElementMenge(m))
                {
                    vereinigung.Add(m);
                }
            }

            return vereinigung;
        }

        public AbstractMengeDerMengen<E> DifferenzMenge(AbstractMengeDerMengen<E> mengeDerMengen)
        {
            AbstractMengeDerMengen<E> differenzMenge = this;

            foreach (AbstractMenge<E> m in this)
            {
                if (differenzMenge.HatElementMenge(m))
                {
                    differenzMenge.Remove(m);
                }
            }

            return differenzMenge;
        }

        public new string ToString()
        {
            string ausgabe = "{";

            for (int i = 0; i < Count; i++)
            {
                ausgabe += ((AbstractMenge<E>)(ToArray()[i])).ToString();

                if (i < Count - 1)
                {
                    ausgabe += ";";
                }
            }

            ausgabe += "}";

            return ausgabe;
        }

        public void Add(AbstractMenge<E> menge)
        {
            base.Add(menge);
        }

        public void Remove(AbstractMenge<E> menge)
        {
            base.Remove(menge);
        }

        public bool Equals(AbstractMengeDerMengen<E>? other)
        {
            if (other == null) return false;

            return IstGleich(other);
        }
    }
}
