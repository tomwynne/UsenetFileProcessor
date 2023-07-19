using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UsenetFileProcessor
{
    public class FileFunctions
    {
        public string? LastError {  get; set; }

        public bool RenameFile(string Filename, string NewFilename)
        {
            try
            {
                if (Filename == NewFilename) return true;                
                if (File.Exists(NewFilename))
                {
                    File.Delete(NewFilename);
                }
                File.Move(Filename, NewFilename);
                return true;
            }
            catch(Exception e)
            {
                LastError = e.Message.ToString();
                return false;
            }


        }
    }
}
