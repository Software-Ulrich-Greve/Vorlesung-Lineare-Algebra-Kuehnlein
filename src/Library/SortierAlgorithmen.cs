namespace Library
{
    public class SortierAlgorithmen<T, Liste>
        where T
        : src.Library.Interfaces.IHashCode
        where Liste
        : List<T>
    {
        public List<T> Elemente { get; set; }

        public T[] SortierteElemente { get; set; }

        public SortierAlgorithmen(List<T> elemente)
        {
            Elemente = elemente;

            SortierteElemente = elemente.ToArray();

            QuickSort(0, SortierteElemente.Length - 1);
        }

        public void QuickSort(int links, int rechts)
        {
            if (links < rechts)
            {
                int teiler = teile(links, rechts);

                QuickSort(links, teiler - 1);

                QuickSort(teiler + 1, rechts);
            }
        }

        public int teile(int links, int rechts)
        {
            int i = links;

            int j = rechts - 1;

            int pivotElementHashCode = SortierteElemente[rechts].GetHashCode();

            while (i < j)
            {
                while (i < j &&
                        SortierteElemente[i].GetHashCode() <= pivotElementHashCode)
                {
                    i++;
                }

                while (j > i &&
                        SortierteElemente[j].GetHashCode() > pivotElementHashCode)
                {
                    j++;
                }

                if (SortierteElemente[i].GetHashCode() > SortierteElemente[j].GetHashCode())
                {
                    Swap(i, j);
                }
            }

            if (SortierteElemente[i].GetHashCode() > pivotElementHashCode)
            {
                Swap(i, rechts);
            }
            else
            {
                i = rechts;
            }

            return i;
        }

        public void Swap(int a, int b)
        {
            T element = SortierteElemente[a];

            SortierteElemente[a] = SortierteElemente[b];

            SortierteElemente[b] = element;
        }
    }
}
