using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console
{
    class Program
    {
        static void Main(string[] args)
        {
            FtpFileSender FileSender = new FtpFileSender();
            FileSender.setFileName("File.txt");
            FileSender.setUser("ftpuser");
            FileSender.setPass("ftppass");
            FileSender.setServer("ftp://xxx.xxx.xxx.xxx/");
            //FileSender.setServer("ftp://example.com/");
            FileSender.setServerPath("test/");
            //FileSender.setLocalPath("c:/users/");
            Console.WriteLine(FileSender.SendFile());
        }
    }
}
