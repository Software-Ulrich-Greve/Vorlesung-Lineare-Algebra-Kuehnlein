namespace Mengen.Interfaces
{
    public interface ILeereMenge<T> where T : IEquatable<T>
    {
        public AbstractMengeBase<T> LeereMenge();

        public AbstractMengeBase<AbstractMengeBase<T>> LeereMengeDerMengen();
    }
}
