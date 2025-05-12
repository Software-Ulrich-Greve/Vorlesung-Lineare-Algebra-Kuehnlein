using Mengen;

namespace Tests.Console
{
    public class ConsoleTest
    {
        public AbstractMenge<int> ? TestMenge { get; set; }

        public AbstractMenge<int> ? TestTeilMenge0 { get; set; }

        public AbstractMenge<int> ? TestTeilMenge1 { get; set; }

        public AbstractMenge<int> ? TestTeilMenge2 { get; set; }

        public AbstractMenge<int> ? TestTeilMenge3 { get; set; }

        public AbstractMenge<AbstractMenge<int>>? MengeDerTeilmengenCalculated { get; set; }

        public ConsoleTest()
        {
            TestMenge = new TestMenge();

            TestMenge.Add(1);

            TestMenge.Add(2);

            TestMenge.Add(3);

            //TestMenge.Add(4);

            //TestMenge.Add(5);

            //TestTeilMenge0 = new TestMenge();

            //TestTeilMenge1 = new TestMenge();

            //TestTeilMenge1.Add(1);

            //TestTeilMenge2 = new TestMenge();

            //TestTeilMenge2.Add(1);

            //TestTeilMenge3 = new TestMenge();

            //TestTeilMenge3.Add(1);

            //TestTeilMenge3.Add(2);

            TestMenge.BerechnePotenzMenge();

            MengeDerTeilmengenCalculated = TestMenge.Potenzmenge;
        }
    }
}
