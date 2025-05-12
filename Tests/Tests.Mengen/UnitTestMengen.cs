using Mengen;

namespace Tests.Mengen;

public class UnitTestMengen
{
    public AbstractMenge<int> ? TestMenge { get; set; }

    public AbstractMenge<int> ? TestTeilMenge0 { get; set; }

    public AbstractMenge<int> ? TestTeilMenge1 { get; set; }

    public AbstractMenge<int> ? TestTeilMenge2 { get; set; }

    public AbstractMenge<int> ? TestTeilMenge3 { get; set; }

    public AbstractMenge<int> ? TestTeilMenge4 { get; set; }

    public AbstractMenge<int> ? TestTeilMenge5 { get; set; }

    public AbstractMenge<int> ? TestTeilMenge6 { get; set; }

    public AbstractMenge<int> ? TestTeilMenge7 { get; set; }

    public AbstractMenge<AbstractMenge<int>>? MengeDerTeilmengenCalculated { get; set; }

    [Fact]
    public void TestPotenzMengeKardinalitaet3()
    {
        TestMenge = new TestMenge();

        TestMenge.Add(1);

        TestMenge.Add(2);

        TestMenge.Add(3);

        TestTeilMenge0 = new TestMenge();

        TestTeilMenge1 = new TestMenge();

        TestTeilMenge1.Add(1);

        TestTeilMenge2 = new TestMenge();

        TestTeilMenge2.Add(2);

        TestTeilMenge3 = new TestMenge();

        TestTeilMenge3.Add(3);

        TestTeilMenge4 = new TestMenge();

        TestTeilMenge4.Add(1);

        TestTeilMenge4.Add(2);

        TestTeilMenge5 = new TestMenge();

        TestTeilMenge5.Add(1);

        TestTeilMenge5.Add(3);

        TestTeilMenge6 = new TestMenge();

        TestTeilMenge6.Add(2);

        TestTeilMenge6.Add(3);

        TestTeilMenge7 = new TestMenge();

        TestTeilMenge7.Add(1);

        TestTeilMenge7.Add(2);

        TestTeilMenge7.Add(3);

        TestMenge.BerechnePotenzMenge();

        Assert.False(TestMenge.Potenzmenge == null);

        Assert.True(TestMenge.Potenzmenge.GetElementMitIndex(0).IstGleich(TestTeilMenge0));

        Assert.True(TestMenge.Potenzmenge.GetElementMitIndex(1).IstGleich(TestTeilMenge1));

        Assert.True(TestMenge.Potenzmenge.GetElementMitIndex(2).IstGleich(TestTeilMenge2));

        Assert.True(TestMenge.Potenzmenge.GetElementMitIndex(3).IstGleich(TestTeilMenge3));

        Assert.True(TestMenge.Potenzmenge.GetElementMitIndex(4).IstGleich(TestTeilMenge4));

        Assert.True(TestMenge.Potenzmenge.GetElementMitIndex(5).IstGleich(TestTeilMenge5));

        Assert.True(TestMenge.Potenzmenge.GetElementMitIndex(6).IstGleich(TestTeilMenge6));

        Assert.True(TestMenge.Potenzmenge.GetElementMitIndex(7).IstGleich(TestTeilMenge7));
    }
}