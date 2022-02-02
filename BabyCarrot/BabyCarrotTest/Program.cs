using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BabyCarrot.Tools;

namespace BabyCarrotTest
{
    internal class Program
    {
        //log manager : 상태 값 등의 기록
        // 윈도우 서비스 프로그램은 백그라운드에서 로그를 남기는 일이 잦음
        static void Main(string[] args)
        {
            LogManager log = new LogManager();
            log.WriteLine("[Begin Processing]------");
            for (int index = 0; index < 10 ; index++)
                {
                log.WriteLine("Processing: " + index);
                System.Threading.Thread.Sleep(500);
                // Do
                log.WriteLine("Done:  " + index);
            }

            
            log.WriteLine("[Begin Processing]------");
            Console.WriteLine(Application.Root);
            Console.ReadLine();
        }
    }
}
