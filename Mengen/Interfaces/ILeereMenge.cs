namespace Mengen.Interfaces
{
    public interface ILeereMenge<T> where T : IEquatable<T>
    {
        public AbstractMenge<T> LeereMenge();

        public AbstractMenge<AbstractMenge<T>> LeereMengeDerMengen();
    }
}
