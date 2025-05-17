namespace Mengen
{
    public class ConsoleTestMengen
    {
        public src.Mengen.Interfaces.IMenge<int> ? TestMenge { get; set; }

        public src.Mengen.Interfaces.IMenge<int> ? TestTeilMenge0 { get; set; }

        public src.Mengen.Interfaces.IMenge<int> ? TestTeilMenge1 { get; set; }

        public src.Mengen.Interfaces.IMenge<int> ? TestTeilMenge2 { get; set; }

        public src.Mengen.Interfaces.IMenge<int> ? TestTeilMenge3 { get; set; }

        public ConsoleTestMengen()
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

            TestMenge.BerechnePotenzMenge();
        }
    }
}
