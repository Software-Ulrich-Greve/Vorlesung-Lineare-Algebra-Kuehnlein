namespace Mengen.Interfaces
{
    public interface ILeereMengeDerMengen<T> where T : IEquatable<T>
    {
        public AbstractMengeDerMengen<T> LeereMenge();
    }
}
