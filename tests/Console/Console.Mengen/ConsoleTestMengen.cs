using Library;

namespace Mengen
{
    public class ConsoleTestMengen
    {
        public src.Mengen.Elemente<int>? TestMenge { get; set; }

        public src.Mengen.Elemente<int>? TestTeilMenge0 { get; set; }

        public src.Mengen.Elemente<int>? TestTeilMenge1 { get; set; }

        public src.Mengen.Elemente<int>? TestTeilMenge2 { get; set; }

        public src.Mengen.Elemente<int>? TestTeilMenge3 { get; set; }

        public ConsoleTestMengen()
        {
            try
            {

                TestMenge = new src.Mengen.TestMenge();

                TestMenge.Add(1);
                TestMenge.Add(2);
                TestMenge.Add(3);
                TestMenge.Add(4);
                TestMenge.Add(5);

                //TestTeilMenge0 = new TestMenge();

                //TestTeilMenge1 = new TestMenge();

                //TestTeilMenge1.Add(1);

                //TestTeilMenge2 = new TestMenge();

                //TestTeilMenge2.Add(1);

                //TestTeilMenge3 = new TestMenge();

                //TestTeilMenge3.Add(1);

                //TestTeilMenge3.Add(2);

                src.Mengen.Elemente<src.Mengen.Elemente<int>>? potenzMenge = TestMenge.PotenzMenge();

                Console.WriteLine();

                Console.WriteLine("============================================================================");

                Console.WriteLine(potenzMenge?.ToString());

                if (potenzMenge == null)
                {
                    return;
                }

                SortierAlgorithmen<src.Mengen.Elemente<int>> potenzMengenSortierungNachKardinalitaet =
                    new SortierAlgorithmen<src.Mengen.Elemente<int>>(potenzMenge);

                src.Mengen.Elemente<src.Mengen.Elemente<int>> sortiertePotenzMenge = new src.Mengen.Elemente<src.Mengen.Elemente<int>>();

                foreach (List<src.Mengen.Elemente<int>> value in potenzMengenSortierungNachKardinalitaet.SortierteElementListen.Values)
                {
                    foreach (src.Mengen.Elemente<int> element in value)
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

                    SortierAlgorithmen<src.Mengen.Elemente<int>> potenzMengenSortierungNachGewicht =
                        new SortierAlgorithmen<src.Mengen.Elemente<int>>(value);

                    foreach (src.Mengen.Elemente<int> element in potenzMengenSortierungNachGewicht.SortierteElemente)
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