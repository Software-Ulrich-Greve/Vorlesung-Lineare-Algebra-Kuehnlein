namespace Mengen.Interfaces
{
    public interface ILeereMengeDerMengen<T> where T : IEquatable<T>
    {
        public AbstractMenge<AbstractMenge<T>> LeereMengeDerMengen();
    }
}
