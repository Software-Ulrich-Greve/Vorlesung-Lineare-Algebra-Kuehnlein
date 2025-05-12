namespace Mengen.Interfaces
{
    public interface ILeereMengeDerMengen<M> where M : IEquatable<M>
    {
        public AbstractMengeDerMengen<M> LeereMenge();
    }
}
