using Mengen;

namespace Tests.Mengen
{
    public class UnitTestMengen
    {
        public AbstractMenge<int>? TestMenge { get; set; }

        public AbstractMenge<int>? TestTeilMenge0 { get; set; }

        public AbstractMenge<int>? TestTeilMenge1 { get; set; }

        public AbstractMenge<int>? TestTeilMenge2 { get; set; }

        public AbstractMenge<int>? TestTeilMenge3 { get; set; }

        public AbstractMenge<AbstractMenge<int>>? MengeDerTeilmengenCalculated { get; set; }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestPotenzMenge()
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

            MengeDerTeilmengenCalculated = TestMenge.PotenzMenge();

            Assert.IsTrue((MengeDerTeilmengenCalculated[0]).IstGleich(TestTeilMenge0));

            Assert.IsTrue((MengeDerTeilmengenCalculated[1]).IstGleich(TestTeilMenge1));

            Assert.IsTrue((MengeDerTeilmengenCalculated[2]).IstGleich(TestTeilMenge2));

            Assert.IsTrue((MengeDerTeilmengenCalculated[3]).IstGleich(TestTeilMenge3));

        }
    }
}