using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyCarrot.Tools
{
    public static class Application
    {
        public static string Root
        {
            get
            {
                //현재 어플리케이션이 돌고 있는 루트를 반환
                string root = AppDomain.CurrentDomain.BaseDirectory;
                
                return root;
            }
        }
    }
}
