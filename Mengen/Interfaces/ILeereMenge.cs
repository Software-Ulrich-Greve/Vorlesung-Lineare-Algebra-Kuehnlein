namespace Mengen.Interfaces
{
    public interface ILeereMenge<E> where E : IEquatable<E>
    {
        public AbstractMenge<E> LeereMenge();
    }
}
