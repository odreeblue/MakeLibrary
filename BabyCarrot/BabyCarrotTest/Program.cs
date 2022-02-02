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
            string contents = "Hello there, <br />This is Derek";
            EmailManager.Send("receiver@test.com", "Hi...", contents);

            EmailManager email = new EmailManager("smtp.com",25,"id","password");
            email.From = "sender@test.com";
            email.To.Add("receiver@test.com");
            email.Subject = "Subject";
            email.Body = contents;
            email.Send();

            email.To.Clear();
            email.To.Add("Receiver2@test.com");
            email.Subject = "Hi Derek";
            email.Send();


        }
    }

}
