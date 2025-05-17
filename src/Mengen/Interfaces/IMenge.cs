namespace src.Mengen.Interfaces
{
    public interface IMenge<T> :
        IList<T>,
        IEquatable<IMenge<T>>,
        IEndlichkeit,
        IAbzaehlbarkeit,
        ILeereMenge<T>,
        ILeereMengeDerMengen<IMenge<T>>,
        IKardinalitaet,
        IHatElement<T>,
        IIstElementVon<IMenge<T>>,
        IElementMitIndex<T>,
        IIstTeilmengeVon<IMenge<T>>,
        IIstGleich<IMenge<T>>,
        IDurchschnitt<IMenge<T>>,
        IVereinigung<IMenge<T>>,
        IDifferenzMenge<IMenge<T>>,
        IToString,
        IPotenzMenge<IMenge<T>>,
        ICopy<IMenge<T>>
        where T : IEquatable<T>
    {
    }
}
