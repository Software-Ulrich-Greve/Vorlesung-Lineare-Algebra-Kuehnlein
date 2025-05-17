namespace Mengen
{
    public class ConsoleTestMengen
    {
        public src.Mengen.AbstractMenge<int> ? TestMenge { get; set; }

        public src.Mengen.AbstractMenge<int> ? TestTeilMenge0 { get; set; }

        public src.Mengen.AbstractMenge<int> ? TestTeilMenge1 { get; set; }

        public src.Mengen.AbstractMenge<int> ? TestTeilMenge2 { get; set; }

        public src.Mengen.AbstractMenge<int> ? TestTeilMenge3 { get; set; }

        public src.Mengen.Interfaces.IMenge<src.Mengen.Interfaces.IMenge<int>>? MengeDerTeilmengenCalculated { get; set; }

        public ConsoleTestMengen()
        {
            TestMenge = new src.Mengen.TestMenge
            {
                1,
                2,
                3,
                4,
                5
            };

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
