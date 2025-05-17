namespace src.Abbildungen
{
    public abstract class AbstractAbbildung<Definitionsbereich, Wertebereich>
        where Definitionsbereich : Mengen.AbstractMenge<Definitionsbereich>, IEquatable<Definitionsbereich>
        where Wertebereich : Mengen.AbstractMenge<Wertebereich>, IEquatable<Wertebereich>
    {
        public abstract Wertebereich Abbildungsvorschrift(Definitionsbereich ElementAusDefinitionsbereich);
    }
}
