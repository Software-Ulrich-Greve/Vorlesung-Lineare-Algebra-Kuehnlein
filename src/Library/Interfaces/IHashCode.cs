namespace src.Library.Interfaces
{
    public interface IHashCode<T>
    {
        public Func<T, int> HashCodeFunction { get; set; }

        public int HashCode();
    }
}
