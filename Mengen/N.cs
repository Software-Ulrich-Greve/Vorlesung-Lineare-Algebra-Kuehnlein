namespace Mengen
{
    public class N : Menge<int>
    {
        public N() : base()
        {
        }

        public override void CheckElement(int element)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(element);
        }
    }
}
