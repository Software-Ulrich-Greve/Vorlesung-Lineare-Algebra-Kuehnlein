namespace src.Abbildungen
{
    public class WertetabellenElement<Definitionsbereich, Wertebereich> : IEquatable<WertetabellenElement<Definitionsbereich, Wertebereich>>
        where Definitionsbereich : IEquatable<Definitionsbereich>
        where Wertebereich : IEquatable<Wertebereich>

    {
        public Definitionsbereich X { get; set; }

        public Wertebereich Y { get; set; }

        public WertetabellenElement(Definitionsbereich x, Wertebereich y)
        {
            X = x;

            Y = y;
        }

        public bool Equals(WertetabellenElement<Definitionsbereich, Wertebereich>? other)
        {
            if (other == null)
            {
                return false;
            }

            return (X.Equals(other.X) &&
                    Y.Equals(other.Y));
        }
    }
}
