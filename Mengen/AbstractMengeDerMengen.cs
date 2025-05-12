namespace Mengen
{
    public abstract class AbstractMengeDerMengen<E> :
        AbstractMengeBase<AbstractMengeBase<E>>,
        IEquatable<AbstractMengeDerMengen<E>>,
        Interfaces.IEndlichkeit,
        Interfaces.IAbzaehlbarkeit,
        Interfaces.ILeereMenge<AbstractMengeBase<E>>,
        Interfaces.IKardinalitaet,
        Interfaces.IHatElement<AbstractMengeBase<E>>,
        Interfaces.IIstElementVon<AbstractMengeBase<AbstractMengeBase<E>>>,
        Interfaces.IElementMitIndex<AbstractMengeBase<E>>,
        Interfaces.IIstTeilmengeVon<AbstractMengeBase<AbstractMengeBase<E>>>,
        Interfaces.IIstGleich<AbstractMengeBase<AbstractMengeBase<E>>>,
        Interfaces.IDurchschnitt<AbstractMengeBase<AbstractMengeBase<E>>>,
        Interfaces.IVereinigung<AbstractMengeBase<AbstractMengeBase<E>>>,
        Interfaces.IDifferenzMenge<AbstractMengeBase<AbstractMengeBase<E>>>,
        Interfaces.IToString
        where E : IEquatable<E>
    {
        public bool Equals(AbstractMengeDerMengen<E>? other)
        {
            throw new NotImplementedException();
        }
    }
}
