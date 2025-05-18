namespace Mengen
{
    public class ConsoleTestMengen
    {
        public src.Mengen.GenerischeMenge<int>? TestMenge { get; set; }

        public ConsoleTestMengen()
        {
            try
            {

                TestMenge = new src.Mengen.GenerischeMenge<int>();

                TestMenge.Add(1);
                TestMenge.Add(2);
                TestMenge.Add(3);
                TestMenge.Add(4);
                TestMenge.Add(5);

                src.Mengen.GenerischeMenge<src.Mengen.GenerischeMenge<int>>? potenzMenge = TestMenge.PotenzMenge();

                Console.WriteLine();

                Console.WriteLine("============================================================================");

                Console.WriteLine(potenzMenge?.ToString());

                if (potenzMenge == null)
                {
                    return;
                }

                src.Library.SortierAlgorithmen<src.Mengen.GenerischeMenge<int>> potenzMengenSortierungNachKardinalitaet =
                    new src.Library.SortierAlgorithmen<src.Mengen.GenerischeMenge<int>>(potenzMenge);

                src.Mengen.GenerischeMenge<src.Mengen.GenerischeMenge<int>> sortiertePotenzMenge = new src.Mengen.GenerischeMenge<src.Mengen.GenerischeMenge<int>>();

                foreach (List<src.Mengen.GenerischeMenge<int>> value in potenzMengenSortierungNachKardinalitaet.SortierteElementListen.Values)
                {
                    foreach (src.Mengen.GenerischeMenge<int> element in value)
                    {
                        element.HashCodeFunction = (h) =>
                        {
                            int summe = 0;

                            foreach (int wert in h)
                            {
                                summe += wert;
                            }

                            return summe;
                        };
                    }

                    src.Library.SortierAlgorithmen<src.Mengen.GenerischeMenge<int>> potenzMengenSortierungNachGewicht =
                        new src.Library.SortierAlgorithmen<src.Mengen.GenerischeMenge<int>>(value);

                    foreach (src.Mengen.GenerischeMenge<int> element in potenzMengenSortierungNachGewicht.SortierteElemente)
                    {
                        sortiertePotenzMenge.Add(element);
                    }
                }

                Console.WriteLine();

                Console.WriteLine("============================================================================");

                Console.WriteLine(sortiertePotenzMenge.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}