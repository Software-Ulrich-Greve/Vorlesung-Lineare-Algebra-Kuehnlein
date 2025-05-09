namespace Mengen
{
    public struct Bruch
    {
        public Z Zaehler {  get; set; }

        public N Nenner {  get; set; }

        public Bruch(Z zaehler, N nenner) 
        { 
            Zaehler = zaehler;

            Nenner = nenner;
        }
    }
}
