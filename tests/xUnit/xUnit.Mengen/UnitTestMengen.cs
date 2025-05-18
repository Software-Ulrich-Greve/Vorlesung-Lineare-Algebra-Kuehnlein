namespace tests.xUnit.Mengen;

public class UnitTestMengen
{
    public src.Mengen.GenerischeMenge<int>? TestMenge1 { get; set; }

    public src.Mengen.GenerischeMenge<int>? TestMenge2 { get; set; }

    public src.Mengen.GenerischeMenge<int>? TestMenge3 { get; set; }

    public src.Mengen.GenerischeMenge<int>? Durchschnitt { get; set; }

    public src.Mengen.GenerischeMenge<int>? Vereinigung { get; set; }

    public src.Mengen.GenerischeMenge<int>? Differenzmenge { get; set; }

    public src.Mengen.GenerischeMenge<int>? TestTeilmenge0 { get; set; }

    public src.Mengen.GenerischeMenge<int>? TestTeilmenge1 { get; set; }

    public src.Mengen.GenerischeMenge<int>? TestTeilmenge2 { get; set; }

    public src.Mengen.GenerischeMenge<int>? TestTeilmenge3 { get; set; }

    public src.Mengen.GenerischeMenge<int>? TestTeilmenge4 { get; set; }

    public src.Mengen.GenerischeMenge<int>? TestTeilmenge5 { get; set; }

    public src.Mengen.GenerischeMenge<int>? TestTeilmenge6 { get; set; }

    public src.Mengen.GenerischeMenge<int>? TestTeilmenge7 { get; set; }


    [Fact]
    public void TestLeereMengeIstGleich()
    {
        TestMenge1 = new src.Mengen.GenerischeMenge<int>();

        TestMenge2 = TestMenge1.LeereMenge;

        Assert.True(TestMenge1.IstGleich(TestMenge2));

        TestMenge3 = new src.Mengen.GenerischeMenge<int>();

        TestMenge3.Add(1);

        Assert.False(TestMenge1.IstGleich(TestMenge3));
    }

    [Fact]
    public void TestMengeHatElement()
    {
        TestMenge1 = new src.Mengen.GenerischeMenge<int>();

        TestMenge1.Add(1);

        TestMenge1.Add(2);

        TestMenge1.Add(3);

        Assert.True(TestMenge1.HatElement(2));

        Assert.False(TestMenge1.HatElement(4));
    }

    [Fact]
    public void TestMengeIstTeilmengeVon()
    {
        TestMenge1 = new src.Mengen.GenerischeMenge<int>();

        TestMenge1.Add(1);

        TestMenge1.Add(2);

        TestMenge1.Add(3);

        TestMenge2 = new src.Mengen.GenerischeMenge<int>();

        TestMenge2.Add(1);

        TestMenge2.Add(3);

        Assert.True(TestMenge2.IstTeilmengeVon(TestMenge1));

        Assert.False(TestMenge1.IstTeilmengeVon(TestMenge2));
    }

    [Fact]
    public void TestMengeDurchschnittVereinigungDifferenzmenge()
    {
        TestMenge1 = new src.Mengen.GenerischeMenge<int>();

        TestMenge1.Add(1);

        TestMenge1.Add(2);

        TestMenge1.Add(3);


        TestMenge2 = new src.Mengen.GenerischeMenge<int>();

        TestMenge2.Add(1);

        TestMenge2.Add(3);

        TestMenge2.Add(5);


        Durchschnitt = new src.Mengen.GenerischeMenge<int>();

        Durchschnitt.Add(1);

        Durchschnitt.Add(3);


        Vereinigung = new src.Mengen.GenerischeMenge<int>();

        Vereinigung.Add(1);

        Vereinigung.Add(2);

        Vereinigung.Add(3);

        Vereinigung.Add(5);


        Differenzmenge = new src.Mengen.GenerischeMenge<int>();

        Differenzmenge.Add(2);


        Assert.True(TestMenge1.Durchschnitt(TestMenge2).IstGleich(Durchschnitt));

        Assert.False(TestMenge1.Durchschnitt(TestMenge2).IstGleich(Vereinigung));

        Assert.True(TestMenge1.Vereinigung(TestMenge2).IstGleich(Vereinigung));

        Assert.False(TestMenge1.Vereinigung(TestMenge2).IstGleich(Durchschnitt));

        Assert.True(TestMenge1.Differenzmenge(TestMenge2).IstGleich(Differenzmenge));

        Assert.False(TestMenge2.Differenzmenge(TestMenge1).IstGleich(Differenzmenge));
    }

    [Fact]
    public void TestMengeToStringCopyIstGleich()
    {
        TestMenge1 = new src.Mengen.GenerischeMenge<int>();

        TestMenge1.Add(1);

        TestMenge1.Add(2);

        TestMenge1.Add(3);

        TestMenge2 = new src.Mengen.GenerischeMenge<int>();

        TestMenge2.Add(1);

        TestMenge2.Add(3);

        TestMenge3 = TestMenge1.Copy();

        Assert.True(TestMenge3.IstGleich(TestMenge1));

        Assert.Equal("{1;2;3}", TestMenge1.ToString());

        Assert.Equal("{1;3}", TestMenge2.ToString());

        Assert.Equal("{1;2;3}", TestMenge3.ToString());
    }

    [Fact]
    public void TestMengeHashCode()
    {
        TestMenge1 = new src.Mengen.GenerischeMenge<int>();

        TestMenge1.Add(1);

        TestMenge1.Add(2);

        TestMenge1.Add(3);

        Assert.Equal(3, TestMenge1.HashCode());

        TestMenge2 = new src.Mengen.GenerischeMenge<int>();

        TestMenge2.Add(1);

        TestMenge2.Add(3);

        Assert.Equal(2, TestMenge2.HashCode());
    }

    [Fact]
    public void TestPotenzmenge()
    {
        TestMenge1 = new src.Mengen.GenerischeMenge<int>();

        TestMenge1.Add(1);

        TestMenge1.Add(2);

        TestMenge1.Add(3);

        TestMenge2 = new src.Mengen.GenerischeMenge<int>();

        TestMenge2.Add(1);

        TestMenge2.Add(4);

        TestTeilmenge0 = new src.Mengen.GenerischeMenge<int>();

        TestTeilmenge1 = new src.Mengen.GenerischeMenge<int>();

        TestTeilmenge1.Add(1);

        TestTeilmenge2 = new src.Mengen.GenerischeMenge<int>();

        TestTeilmenge2.Add(2);

        TestTeilmenge3 = new src.Mengen.GenerischeMenge<int>();

        TestTeilmenge3.Add(3);

        TestTeilmenge4 = new src.Mengen.GenerischeMenge<int>();

        TestTeilmenge4.Add(1);

        TestTeilmenge4.Add(2);

        TestTeilmenge5 = new src.Mengen.GenerischeMenge<int>();

        TestTeilmenge5.Add(1);

        TestTeilmenge5.Add(3);

        TestTeilmenge6 = new src.Mengen.GenerischeMenge<int>();

        TestTeilmenge6.Add(2);

        TestTeilmenge6.Add(3);

        TestTeilmenge7 = new src.Mengen.GenerischeMenge<int>();

        TestTeilmenge7.Add(1);

        TestTeilmenge7.Add(2);

        TestTeilmenge7.Add(3);

        src.Mengen.GenerischeMenge<src.Mengen.GenerischeMenge<int>>? potenzmenge = TestMenge1.Potenzmenge();


        Assert.False(potenzmenge == null);

        Assert.True(TestMenge1.KardinalitaetPotenzmenge.Equals(potenzmenge.Kardinalitaet));

        Assert.True(potenzmenge.HatElement(TestTeilmenge0));

        Assert.True(potenzmenge.HatElement(TestTeilmenge1));

        Assert.True(potenzmenge.HatElement(TestTeilmenge2));

        Assert.True(potenzmenge.HatElement(TestTeilmenge3));

        Assert.True(potenzmenge.HatElement(TestTeilmenge4));

        Assert.True(potenzmenge.HatElement(TestTeilmenge5));

        Assert.True(potenzmenge.HatElement(TestTeilmenge6));

        Assert.True(potenzmenge.HatElement(TestTeilmenge7));

        Assert.False(potenzmenge.HatElement(TestMenge2));
    }

    [Fact]
    public void TestKardinalitaetPotenzmenge()
    {
        TestMenge1 = new src.Mengen.GenerischeMenge<int>();

        TestMenge1.Add(1);

        TestMenge1.Add(2);

        TestMenge1.Add(3);

        TestMenge2 = new src.Mengen.GenerischeMenge<int>();

        TestMenge2.Add(1);

        TestMenge2.Add(4);

        Assert.False(TestMenge1.Potenzmenge() == null);

        Assert.Equal(8, TestMenge1.Potenzmenge().Kardinalitaet);

        Assert.Equal(8, TestMenge1.Potenzmenge().Kardinalitaet);

        Assert.Equal(8, TestMenge1.KardinalitaetPotenzmenge);

        Assert.Equal(4, TestMenge2.KardinalitaetPotenzmenge);
    }

    [Fact]
    public void TestPotenzmengeKardinalitaet8ElementMitIndexIstGleichTeilmengen()
    {
        try
        {
            TestMenge1 = new src.Mengen.GenerischeMenge<int>();

            TestMenge1.Add(1);

            TestMenge1.Add(2);

            TestMenge1.Add(3);

            TestTeilmenge0 = new src.Mengen.GenerischeMenge<int>();

            TestTeilmenge1 = new src.Mengen.GenerischeMenge<int>();

            TestTeilmenge1.Add(1);

            TestTeilmenge2 = new src.Mengen.GenerischeMenge<int>();

            TestTeilmenge2.Add(2);

            TestTeilmenge3 = new src.Mengen.GenerischeMenge<int>();

            TestTeilmenge3.Add(3);

            TestTeilmenge4 = new src.Mengen.GenerischeMenge<int>();

            TestTeilmenge4.Add(1);

            TestTeilmenge4.Add(2);

            TestTeilmenge5 = new src.Mengen.GenerischeMenge<int>();

            TestTeilmenge5.Add(1);

            TestTeilmenge5.Add(3);

            TestTeilmenge6 = new src.Mengen.GenerischeMenge<int>();

            TestTeilmenge6.Add(2);

            TestTeilmenge6.Add(3);

            TestTeilmenge7 = new src.Mengen.GenerischeMenge<int>();

            TestTeilmenge7.Add(1);

            TestTeilmenge7.Add(2);

            TestTeilmenge7.Add(3);

            src.Mengen.GenerischeMenge<src.Mengen.GenerischeMenge<int>>? potenzmenge = TestMenge1.Potenzmenge();


            Assert.False(potenzmenge == null);

            Assert.True(TestMenge1.KardinalitaetPotenzmenge.Equals(potenzmenge.Kardinalitaet));


            src.Library.SortierAlgorithmen<src.Mengen.GenerischeMenge<int>> potenzmengenSortierungNachKardinalitaet =
                new src.Library.SortierAlgorithmen<src.Mengen.GenerischeMenge<int>>(potenzmenge);

            src.Mengen.GenerischeMenge<src.Mengen.GenerischeMenge<int>> sortiertePotenzmenge =
                new src.Mengen.GenerischeMenge<src.Mengen.GenerischeMenge<int>>();

            foreach (List<src.Mengen.GenerischeMenge<int>> mengenListe in potenzmengenSortierungNachKardinalitaet.SortierteElementListen.Values)
            {
                foreach (src.Mengen.GenerischeMenge<int> menge in mengenListe)
                {
                    menge.HashCodeFunction = (m) =>
                    {
                        int summe = 0;

                        foreach (int wert in m)
                        {
                            summe += wert;
                        }

                        return summe;
                    };
                }

                src.Library.SortierAlgorithmen<src.Mengen.GenerischeMenge<int>> potenzmengenSortierungNachElemenSumme =
                    new src.Library.SortierAlgorithmen<src.Mengen.GenerischeMenge<int>>(mengenListe);

                foreach (src.Mengen.GenerischeMenge<int> menge in potenzmengenSortierungNachElemenSumme.SortierteElemente)
                {
                    sortiertePotenzmenge.Add(menge);
                }
            }


            Assert.False(sortiertePotenzmenge == null);

            Assert.True(sortiertePotenzmenge.ElementMitIndex(0).IstGleich(TestTeilmenge0));

            Assert.True(sortiertePotenzmenge.ElementMitIndex(1).IstGleich(TestTeilmenge1));

            Assert.True(sortiertePotenzmenge.ElementMitIndex(2).IstGleich(TestTeilmenge2));

            Assert.True(sortiertePotenzmenge.ElementMitIndex(3).IstGleich(TestTeilmenge3));

            Assert.True(sortiertePotenzmenge.ElementMitIndex(4).IstGleich(TestTeilmenge4));

            Assert.True(sortiertePotenzmenge.ElementMitIndex(5).IstGleich(TestTeilmenge5));

            Assert.True(sortiertePotenzmenge.ElementMitIndex(6).IstGleich(TestTeilmenge6));

            Assert.True(sortiertePotenzmenge.ElementMitIndex(7).IstGleich(TestTeilmenge7));
        }
        catch (Exception ex)
        {
            var x = 0;
        }
    }
}