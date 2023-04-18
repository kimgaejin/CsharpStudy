using System.Diagnostics;

/* 
 * 2023-04-18
 * 100,000,000 회 기준, 약 40ms 차이
 * 1회당 약 0.0000025 ms
 * Write() 1회에 0.014 ms 정도
 */

namespace CSharpStudy
{
    public class NullCheckPerformance
    {
        private DummyData _data;
        public NullCheckPerformance()
        {
            _data = new DummyData();
        }

        public void Play(long cycles = 10000000)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            for (long i = 0; i < cycles; i++)
            {
                //NotNullCheckProcess();
            }
            stopWatch.Stop();
            var result1 = stopWatch.ElapsedMilliseconds;
            stopWatch.Reset();
            stopWatch.Restart();
            for (long i = 0; i < cycles; i++)
            {
                Console.Write($".");
                //NullCheckProcess();
            }
            stopWatch.Stop();
            var result2 = stopWatch.ElapsedMilliseconds;

            Console.WriteLine($"Cycle: {cycles}\nCommon: {result1}\nNull Check: {result2}\n{((result2-result1)/(float)cycles)}/ms");
        }

        private void NullCheckProcess()
        {
            if (_data != null)
                _data.DoSomething();
        }
        private void NotNullCheckProcess()
        {
            _data.DoSomething();
        }
    }

    internal class DummyData
    {
        private int _data1;
        private double _data2;
        private string _data3;

        public void DoSomething()
        {
            _data1 = 1;
            _data2 = 1.0f;
            _data3 = $"Hello";
        }
    }
}
