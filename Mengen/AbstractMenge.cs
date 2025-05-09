namespace Mengen
{
    public abstract class AbstractMenge<E> : List<E> where E : struct
    {
        public abstract void CheckElement(E element);

        public new void Add(E element)
        {
            CheckElement(element);

            base.Add(element);
        }
    }
}
