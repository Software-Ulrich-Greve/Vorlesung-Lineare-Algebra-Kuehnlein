namespace src.Abbildungen
{
    public abstract class AbstractWertetabelle<Definitionsbereich, Wertebereich> :
        Mengen.AbstractMenge<WertetabellenElement<Definitionsbereich, Wertebereich>>,
        Mengen.Interfaces.IMenge<WertetabellenElement<Definitionsbereich, Wertebereich>>,
        IList<WertetabellenElement<Definitionsbereich, Wertebereich>>
        where Definitionsbereich : IEquatable<Definitionsbereich>
        where Wertebereich : IEquatable<Wertebereich>

    {
        public abstract override bool IstEndlich { get; }

        public abstract override bool IstAbzaehlbar { get; }

        public new void Add(WertetabellenElement<Definitionsbereich, Wertebereich> element)
        {
            base.Add(element);
        }
    }
}
