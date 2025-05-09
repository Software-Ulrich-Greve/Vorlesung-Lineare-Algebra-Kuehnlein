namespace Mengen
{
    public class Menge<E> : AbstractMenge<E> where E : struct
    {
        public static Menge<E> LeereMenge()
        {
            return new Menge<E>();
        }

        public override void CheckElement(E element)
        {
            throw new NotImplementedException();
        }
    }
}
