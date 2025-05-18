namespace tests.xUnit.Mengen;

public class UnitTestMengen
{
    public src.Mengen.Elemente<int>? TestMenge { get; set; }

    public src.Mengen.Elemente<int>? TestTeilMenge0 { get; set; }

    public src.Mengen.Elemente<int>? TestTeilMenge1 { get; set; }

    public src.Mengen.Elemente<int>? TestTeilMenge2 { get; set; }

    public src.Mengen.Elemente<int>? TestTeilMenge3 { get; set; }

    public src.Mengen.Elemente<int>? TestTeilMenge4 { get; set; }

    public src.Mengen.Elemente<int>? TestTeilMenge5 { get; set; }

    public src.Mengen.Elemente<int>? TestTeilMenge6 { get; set; }

    public src.Mengen.Elemente<int>? TestTeilMenge7 { get; set; }


    [Fact]
    public void TestPotenzMengeKardinalitaet3()
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

        src.Mengen.Elemente<src.Mengen.Elemente<int>>? Potenzmenge = TestMenge.PotenzMenge();

        Assert.False(Potenzmenge == null);

        Assert.True(Potenzmenge.ElementMitIndex(0).IstGleich(TestTeilMenge0));

        Assert.True(Potenzmenge.ElementMitIndex(1).IstGleich(TestTeilMenge1));

        Assert.True(Potenzmenge.ElementMitIndex(2).IstGleich(TestTeilMenge2));

        Assert.True(Potenzmenge.ElementMitIndex(3).IstGleich(TestTeilMenge3));

        Assert.True(Potenzmenge.ElementMitIndex(4).IstGleich(TestTeilMenge4));

        Assert.True(Potenzmenge.ElementMitIndex(5).IstGleich(TestTeilMenge5));

        Assert.True(Potenzmenge.ElementMitIndex(6).IstGleich(TestTeilMenge6));

        Assert.True(Potenzmenge.ElementMitIndex(7).IstGleich(TestTeilMenge7));
    }
}