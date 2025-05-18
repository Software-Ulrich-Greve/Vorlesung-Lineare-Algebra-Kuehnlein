namespace src.Mengen.Interfaces
{
    public interface IMenge<T> :
            IEquatable<IMenge<T>>,
            IEndlichkeit,
            IAbzaehlbarkeit,
            ILeereMenge<IMenge<T>>,
            IKardinalitaet,
            IHatElement<T>,
            IElementMitIndex<T>,
            IIstTeilmengeVon<IMenge<T>>,
            IIstGleich<IMenge<T>>,
            IDurchschnitt<IMenge<T>>,
            IVereinigung<IMenge<T>>,
            IDifferenzMenge<IMenge<T>>,
            IToString,
            ICopy<IMenge<T>>
        where T : IEquatable<T>
    {
        public GenerischeMenge<T> Elemente { get; set; }

        public IMenge<T> Initialize(GenerischeMenge<T> elemente);

        public void Add(T t);

        public void Remove(T t);
    }
}
