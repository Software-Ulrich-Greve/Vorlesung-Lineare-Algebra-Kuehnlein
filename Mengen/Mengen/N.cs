namespace Mengen
{
    public class N : Menge<int>
    {
        public N(int n) : base(n) 
        {
            if (n <= 0) throw new ArgumentException("n must be > 0");
        }
    }
}
