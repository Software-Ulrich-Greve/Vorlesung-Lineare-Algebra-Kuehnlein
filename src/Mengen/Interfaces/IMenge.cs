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
            //IIstElementVon<IMenge<IMenge<T>>>,
            IToString,
            IPotenzMenge<Elemente<T>>,
            ICopy<IMenge<T>>
        where T : IEquatable<T>
    {
        public Elemente<T> Elemente { get; set; }

        public IMenge<T> Initialize(Elemente<T> elemente);

        public void Add(T t);

        public void Remove(T t);
    }
}
