namespace Mengen
{
    public class Menge<E> where E : struct
    {
        public E? Element { get; set; }

        public Menge(E? e)
        {
            Element = e;
        }
    }
}
