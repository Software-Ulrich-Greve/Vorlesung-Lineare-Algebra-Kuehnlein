namespace src.Library
{
    public class SortierAlgorithmen<T>
        where T : Interfaces.IHashCode<T>
    {
        public List<T> Elemente { get; set; }

        public T[] SortierteElemente { get; set; }

        public Dictionary<int, List<T>> SortierteElementListen { get; set; }

        public SortierAlgorithmen(List<T> elemente)
        {
            try
            {
                Elemente = elemente;

                SortierteElemente = elemente.ToArray();

                QuickSort(0, SortierteElemente.Length - 1);

                int hash = 0;

                SortierteElementListen = new Dictionary<int, List<T>>();

                for (int i = 0; i < SortierteElemente.Length; i++)
                {
                    if (i == 0 ||
                        SortierteElemente[i].HashCode() != hash)
                    {
                        hash = SortierteElemente[i].HashCode();

                        SortierteElementListen[hash] = new List<T>();
                    }

                    SortierteElementListen[hash].Add(SortierteElemente[i]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        public void QuickSort(int links, int rechts)
        {
            if (links < rechts)
            {
                int teiler = Teile(links, rechts);

                QuickSort(links, teiler - 1);

                QuickSort(teiler + 1, rechts);
            }
        }

        public int Teile(int links, int rechts)
        {
            int i = links;

            int j = rechts - 1;

            try
            {
                int pivotElementHashCode = SortierteElemente[rechts].HashCode();

                while (i < j)
                {
                    while (i < j &&
                            SortierteElemente[i].HashCode() <= pivotElementHashCode)
                    {
                        i++;
                    }

                    while (j > i &&
                            SortierteElemente[j].HashCode() > pivotElementHashCode)
                    {
                        j--;
                    }

                    if (SortierteElemente[i].HashCode() > SortierteElemente[j].HashCode())
                    {
                        Swap(i, j);
                    }
                }

                if (SortierteElemente[i].HashCode() > pivotElementHashCode)
                {
                    Swap(i, rechts);
                }
                else
                {
                    i = rechts;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("links:" + links + "rechts:" + rechts + "i:" + i + "j:" + j + " SortierteElemente.Length:" + SortierteElemente.Length);

                Console.WriteLine(ex.StackTrace);
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
