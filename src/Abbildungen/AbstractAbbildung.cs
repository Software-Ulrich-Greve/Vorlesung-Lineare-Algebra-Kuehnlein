namespace src.Abbildungen
{
    public abstract class AbstractAbbildung<Definitionsbereich, Wertebereich>
        where Definitionsbereich : Mengen.Interfaces.IMenge<Definitionsbereich>, IEquatable<Definitionsbereich>
        where Wertebereich : Mengen.Interfaces.IMenge<Wertebereich>, IEquatable<Wertebereich>
    {
        public abstract Wertebereich Abbildungsvorschrift(Definitionsbereich ElementAusDefinitionsbereich);
    }
}
