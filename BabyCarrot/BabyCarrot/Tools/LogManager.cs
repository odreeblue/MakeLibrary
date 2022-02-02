using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyCarrot.Tools
{
    public class LogManager
    {
        private string _path;

        #region Constructors
        public LogManager(string path)
        {
            _path = path;
            _SetLogPath();
        }
        public LogManager()
            :this(System.IO.Path.Combine(Application.Root,"Log"))
        {
            //_path =System.IO.Path.Combine(Application.Root,"Log");
            ////_path = BabyCarrot.Tools.Application.Root; // 같은 네임스페이스 안에 있으므로 자동참조됨
            //_SetLogPath();
        }
        #endregion


        #region Methods
        private void _SetLogPath()
        {
            if (!System.IO.Directory.Exists(_path))
                System.IO.Directory.CreateDirectory(_path);

            string logFile = DateTime.Now.ToString("yyyyMMdd") + ".txt";
            _path = System.IO.Path.Combine(_path, logFile);
        }

        public void Write(string data)
        {
            try
            {
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(_path, true))
                {
                    writer.Write(data);
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void WriteLine(string data)
        {
            try 
            { 
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(_path, true))
                {
                    writer.WriteLine(DateTime.Now.ToString("yyyyMMdd HH:mm:ss\t") + data);
                } 
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
    }
}
