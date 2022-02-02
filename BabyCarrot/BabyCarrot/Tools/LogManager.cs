using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyCarrot.Tools
{
    public enum LogType { Daily, Monthly}
    public class LogManager
    {
        //LogPath\2015\12\20151207.txt
        //LogPath\2016\01\20160101.txt
        //LogPath\2016\201601.txt

        private string _path;

        #region Constructors
        public LogManager(string path,LogType logType, string prefix, string postfix)
        {
            _path = path;
            _SetLogPath(logType,prefix, postfix);
        }
        public LogManager(string prefix, string postfix)
            :this(System.IO.Path.Combine(Application.Root, "Log"),LogType.Daily,prefix,postfix)
        {

        }

        public LogManager()
            :this(System.IO.Path.Combine(Application.Root,"Log"),LogType.Daily,null,null)
            ///아무런 매개변수가 입력이 없는 경우 this로 다시 생성자 호출하여 디폴트 매개변수 입력
        {
            //_path =System.IO.Path.Combine(Application.Root,"Log");
            ////_path = BabyCarrot.Tools.Application.Root; // 같은 네임스페이스 안에 있으므로 자동참조됨
            //_SetLogPath();
        }
        #endregion


        #region Methods
        private void _SetLogPath(LogType logType, string prefix, string postfix)
        {
            string path = String.Empty;
            string name = String.Empty;

            switch (logType)
            {
                case LogType.Daily:
                    path = String.Format(@"{0}\{1}\", DateTime.Now.Year, DateTime.Now.ToString("MM"));
                    name = DateTime.Now.ToString("yyyyMMdd");
                    break;
                case LogType.Monthly:
                    path = String.Format(@"{0}\", DateTime.Now.Year);
                    name = DateTime.Now.ToString("yyyyMM");
                    break;
            }

            _path = System.IO.Path.Combine(_path, path);

            if (!System.IO.Directory.Exists(_path))
                System.IO.Directory.CreateDirectory(_path);
            if (!String.IsNullOrEmpty(prefix))
            {
                name = prefix + name;
            }
            if (!String.IsNullOrEmpty(postfix))
            {
                name =name+postfix;
            }

            name += ".txt";

            _path = System.IO.Path.Combine(_path, name);
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
