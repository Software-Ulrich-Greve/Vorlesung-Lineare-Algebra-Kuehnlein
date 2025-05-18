using Library;

namespace tests.xUnit.Mengen;

public class UnitTestMengen
{
    public src.Mengen.GenerischeMenge<int>? TestMenge { get; set; }

    public src.Mengen.GenerischeMenge<int>? TestTeilMenge0 { get; set; }

    public src.Mengen.GenerischeMenge<int>? TestTeilMenge1 { get; set; }

    public src.Mengen.GenerischeMenge<int>? TestTeilMenge2 { get; set; }

    public src.Mengen.GenerischeMenge<int>? TestTeilMenge3 { get; set; }

    public src.Mengen.GenerischeMenge<int>? TestTeilMenge4 { get; set; }

    public src.Mengen.GenerischeMenge<int>? TestTeilMenge5 { get; set; }

    public src.Mengen.GenerischeMenge<int>? TestTeilMenge6 { get; set; }

    public src.Mengen.GenerischeMenge<int>? TestTeilMenge7 { get; set; }


    [Fact]
    public void TestPotenzMengeKardinalitaet3()
    {
        try
        {
            TestMenge = new src.Mengen.TestMenge();

            TestMenge.Add(1);

            TestMenge.Add(2);

            TestMenge.Add(3);

            TestTeilMenge0 = new src.Mengen.TestMenge();

            TestTeilMenge1 = new src.Mengen.TestMenge();

            TestTeilMenge1.Add(1);

            TestTeilMenge2 = new src.Mengen.TestMenge();

            TestTeilMenge2.Add(2);

            TestTeilMenge3 = new src.Mengen.TestMenge();

            TestTeilMenge3.Add(3);

            TestTeilMenge4 = new src.Mengen.TestMenge();

            TestTeilMenge4.Add(1);

            TestTeilMenge4.Add(2);

            TestTeilMenge5 = new src.Mengen.TestMenge();

            TestTeilMenge5.Add(1);

            TestTeilMenge5.Add(3);

            TestTeilMenge6 = new src.Mengen.TestMenge();

            TestTeilMenge6.Add(2);

            TestTeilMenge6.Add(3);

            TestTeilMenge7 = new src.Mengen.TestMenge();

            TestTeilMenge7.Add(1);

            TestTeilMenge7.Add(2);

            TestTeilMenge7.Add(3);

            src.Mengen.GenerischeMenge<src.Mengen.GenerischeMenge<int>>? potenzmenge = TestMenge.PotenzMenge();

            SortierAlgorithmen<src.Mengen.GenerischeMenge<int>> potenzMengenSortierungNachKardinalitaet =
                new SortierAlgorithmen<src.Mengen.GenerischeMenge<int>>(potenzmenge);

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

                SortierAlgorithmen<src.Mengen.GenerischeMenge<int>> potenzMengenSortierungNachGewicht =
                    new SortierAlgorithmen<src.Mengen.GenerischeMenge<int>>(value);

                foreach (src.Mengen.GenerischeMenge<int> element in potenzMengenSortierungNachGewicht.SortierteElemente)
                {
                    sortiertePotenzMenge.Add(element);
                }
            }

            Assert.False(sortiertePotenzMenge == null);

            Assert.True(sortiertePotenzMenge.ElementMitIndex(0).IstGleich(TestTeilMenge0));

            Assert.True(sortiertePotenzMenge.ElementMitIndex(1).IstGleich(TestTeilMenge1));

            Assert.True(sortiertePotenzMenge.ElementMitIndex(2).IstGleich(TestTeilMenge2));

            Assert.True(sortiertePotenzMenge.ElementMitIndex(3).IstGleich(TestTeilMenge3));

            Assert.True(sortiertePotenzMenge.ElementMitIndex(4).IstGleich(TestTeilMenge4));

            Assert.True(sortiertePotenzMenge.ElementMitIndex(5).IstGleich(TestTeilMenge5));

            Assert.True(sortiertePotenzMenge.ElementMitIndex(6).IstGleich(TestTeilMenge6));

            Assert.True(sortiertePotenzMenge.ElementMitIndex(7).IstGleich(TestTeilMenge7));
        }
        catch (Exception ex)
        {
            var x = 0;
        }
    }
}