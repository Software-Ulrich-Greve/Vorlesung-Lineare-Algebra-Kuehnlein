namespace Mengen
{
    public class N0 : Menge<int>
    {
        public N0() : base()
        {
        }

        public override void CheckElement(int element)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(element);
        }
    }
}
