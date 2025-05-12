using Mengen;

namespace Tests.Mengen;

public class UnitTestMengen
{
    public AbstractMenge<int>? TestMenge { get; set; }

    public AbstractMenge<int>? TestTeilMenge0 { get; set; }

    public AbstractMenge<int>? TestTeilMenge1 { get; set; }

    public AbstractMenge<int>? TestTeilMenge2 { get; set; }

    public AbstractMenge<int>? TestTeilMenge3 { get; set; }

    public AbstractMengeDerMengen<int>? MengeDerTeilmengenCalculated { get; set; }

    [Fact]
    public void TestPotentMenge()
    {
        TestMenge = new TestMenge();

        TestMenge.Add(1);

        TestMenge.Add(2);

        TestTeilMenge0 = new TestMenge();

        TestTeilMenge1 = new TestMenge();

        TestTeilMenge1.Add(1);

        TestTeilMenge2 = new TestMenge();

        TestTeilMenge2.Add(1);

        TestTeilMenge3 = new TestMenge();

        TestTeilMenge3.Add(1);

        TestTeilMenge3.Add(2);

        //MengeDerTeilmengenCalculated = TestMenge.BerechnePotenzMenge();

        //Assert.True(MengeDerTeilmengenCalculated.GetElementMengeWithIndex(0)?.IstGleich(TestTeilMenge0));

        //Assert.True(MengeDerTeilmengenCalculated.GetElementMengeWithIndex(1)?.IstGleich(TestTeilMenge1));

        //Assert.True(MengeDerTeilmengenCalculated.GetElementMengeWithIndex(2)?.IstGleich(TestTeilMenge2));

        //Assert.True(MengeDerTeilmengenCalculated.GetElementMengeWithIndex(3)?.IstGleich(TestTeilMenge3));
    }
}