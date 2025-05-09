﻿namespace Mengen
{
    public abstract class AbstractMenge<E> :
        List<E>,
        Interfaces.IEndlichkeit,
        Interfaces.IAbzaehlbarkeit,
        Interfaces.ILeereMenge<E>,
        Interfaces.IKardinalitaet,
        Interfaces.IHatElement<E>,
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

        public new void Add(E element)
        {
            base.Add(element);
        }

        public new void Remove(E element)
        {
            base.Remove(element);
        }
    }
}
