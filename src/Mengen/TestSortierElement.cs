namespace Mengen
{
    public class TestSortierElement :
        src.Mengen.Element<src.Mengen.Elemente<int>>,
        IEquatable<TestSortierElement>
    {
        public TestSortierElement(
            src.Mengen.Elemente<int> inhalt,
            Func<src.Mengen.Elemente<int>, int> tToHash,
            Func<src.Mengen.Elemente<int>, string> tToString)
            : base(inhalt, tToHash, tToString)
        {
        }

        public bool Equals(TestSortierElement? other)
        {
            if (other == null)
            {
                return false;
            }

            return Equals(other);
        }
    }
}
