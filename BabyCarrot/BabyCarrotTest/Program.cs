using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BabyCarrot.Tools;
using BabyCarrot.Extensions;
namespace BabyCarrotTest
{
    internal class Program
    {
        //log manager : 상태 값 등의 기록
        // 윈도우 서비스 프로그램은 백그라운드에서 로그를 남기는 일이 잦음
        static void Main(string[] args)
        {
            //string temp = "test";
            string temp = "12/08/2015 10:10";
            Console.WriteLine("IsNumeric? : "+ temp.IsNumeric());
            Console.WriteLine("IsDateTime? : " + temp.IsDateTime());
            DateTime temp2 = new DateTime(2022,2,10);
            Console.WriteLine(temp2.FirstDateOfMonth().Date);
            Console.WriteLine(temp2.LastDateOfMonth().Date);
            Console.ReadLine();

        }
    }

}
