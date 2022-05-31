using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Reflection;



namespace runexebat
{
    class Program
    {
        static void Main(string[] args)
        {


            //string s = Assembly.GetExecutingAssembly().GetName().Name;
            //string  str = AppDomain.CurrentDomain.BaseDirectory;




            List<string >  a = getfiles();
            string ini = a[0].ToString() + "\\" + "configpyc.ini";
            IniFile inif = new IniFile(ini);
            string keyname = a[1].ToString();
            /// 修改处理exe  
            string  newkey =  (keyname.Split('.'))[0];

            //// 通过kename 进行读取
            string path = inif.IniReadValue("ini", newkey);
            //// 开始进行拆开运行操作  
            var dir = Path.GetDirectoryName(path);
            var fi = Path.GetFileName(path);
            var newlist = new List<string>();
            newlist.Add(dir);
            newlist.Add(fi);

            run(newlist);

            //Console.WriteLine(path);
            //Console.WriteLine(dir);
            //Console.WriteLine(fi);
            

        }

        public static List<string>  getfiles() 
        {
            List<string> ls = new List<string>(); 
            string str = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            
            string f = Path.GetDirectoryName(str);
            string d = Path.GetFileName(str);
            //Console.WriteLine(d);
            ls.Add(f);
            ls.Add(d); 

            return ls; 
        }

        public static  void run ( List<string>  lis  )
        {
            Process proc = null;
            //string path = ("S:/Main/ArtTools/python_tools/ZeroProjectNameTools/runtools.bat");
            string batDir = string.Format(lis[0]);
            proc = new Process();
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.StartInfo.CreateNoWindow = false;
            proc.StartInfo.WorkingDirectory = batDir;
            proc.StartInfo.FileName = lis[1];



            proc.Start();
            proc.WaitForExit();


        }




    }
}
