using System;
using System.IO;
using Microsoft.VisualBasic; // Install-Package Microsoft.VisualBasic
using Microsoft.VisualBasic.CompilerServices; // Install-Package Microsoft.VisualBasic

namespace FaucetPayLogs
{
    internal partial class FLog
    {
        internal void Loggs(string Logs)
        {
            try
            {
                string Folder = Environment.CurrentDirectory + @"\Logs";
                string DateFile = DateTime.Now.ToShortDateString().Replace(@"\", "-").Replace("/", "-");
                string DateServer = Conversions.ToString(DateTime.Now);
                string FileLog = Folder + @"\Log_" + DateFile + ".log";
                string Message = DateServer + ": " + Logs;


                if (!Directory.Exists(Folder))
                {
                    Directory.CreateDirectory(Folder);
                }

                if (File.Exists(FileLog))
                {
                    File.AppendAllText(FileLog, Constants.vbCrLf + Message);
                }
                else
                {
                    File.AppendAllText(FileLog, Message);
                }
            }


            catch 
            {
            }

        }
    }
}