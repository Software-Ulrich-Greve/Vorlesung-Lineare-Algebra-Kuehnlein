namespace src.Mengen.Interfaces
{
    public interface ILeereMenge<T> where T : IEquatable<T>
    {
        public AbstractMenge<T> LeereMenge();
    }
}
