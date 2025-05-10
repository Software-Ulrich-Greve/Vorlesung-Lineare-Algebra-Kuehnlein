namespace Mengen
{
    public struct Bruch :
        IEquatable<Bruch>
    {
        public int Zaehler { get; set; }

        public int Nenner { get; set; }

        public Bruch(int zaehler, int nenner)
        {
            Zaehler = zaehler;

            Nenner = nenner;
        }

        public bool Equals(Bruch other)
        {
            if (Normalform().Zaehler.Equals(other.Normalform().Zaehler) &&
                Normalform().Nenner.Equals(other.Normalform().Nenner))
            {
                return true;
            }
            else 
            { 
                return false; 
            }
        }

        public static int Min(int a, int b)
        {
            if (a > b)
            {
                return b;
            }
            else
            {
                return a;
            }
        }

        public Bruch Normalform()
        {
            int i = 2;

            while (i < Min(Zaehler, Nenner))
            {
                if (Zaehler % i == 0 && Nenner % i == 0)
                {
                    Zaehler /= i;

                    Nenner /= i;
                }
                else
                {
                    i++;
                }
            }

            if (Nenner < 0)
            {
                Zaehler *= -1;

                Nenner *= -1;
            }

            return new Bruch(Zaehler, Nenner);
        }
    }
}
