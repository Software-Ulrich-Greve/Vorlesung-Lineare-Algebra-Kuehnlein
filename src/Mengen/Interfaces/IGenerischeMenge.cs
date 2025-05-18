namespace src.Mengen.Interfaces
{
    public interface IGenerischeMenge<TElement> :
        IList<TElement>,
        ILeereMenge<GenerischeMenge<TElement>>,
        IKardinalitaet,
        IHatElement<TElement>,
        IElementMitIndex<TElement>,
        IIstTeilmengeVon<GenerischeMenge<TElement>>,
        IIstGleich<GenerischeMenge<TElement>>,
        IDurchschnitt<GenerischeMenge<TElement>>,
        IVereinigung<GenerischeMenge<TElement>>,
        IDifferenzMenge<GenerischeMenge<TElement>>,
        IToString,
        ICopy<GenerischeMenge<TElement>>,
        Library.Interfaces.IHashCode<GenerischeMenge<TElement>>,
        IEquatable<GenerischeMenge<TElement>>,
        IPotenzMenge<GenerischeMenge<TElement>>
        where TElement :
        IEquatable<TElement>
    {
    }
}
