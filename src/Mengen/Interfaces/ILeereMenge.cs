namespace src.Mengen.Interfaces
{
    public interface ILeereMenge<T> where T : IEquatable<T>
    {
        public IMenge<T> LeereMenge();
    }
}
