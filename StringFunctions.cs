using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;

namespace UsenetFileProcessor
{
    public class StringFunctions
    {
        // TrimAfter
        //
        // Trims everything after the FindString and returns everything before the find string including the find string
        //
        // TrimAfter("Some.Show.Name.S05E02.1080p.HULU.WEB-DL.DDP5.1.H.264-NTb", "WEB-DL") = "Some.Show.Name.S05E02.1080p.HULU.WEB-DL"
        // 
        public string TrimAfter(string s, string FindString)
        {
            if (s.ToLower().Contains(FindString.ToLower()))
                return s.Substring(0, s.IndexOf(FindString.ToLower()) + FindString.Length);        
            return s;
        }
        public string UpperCaseWords(string s)
        {
            var sParts = s.Split(".");
            string sNew = "";
            foreach(string sPart in sParts)
            {
                sNew += (sNew != "" ? "." : "") + Capitalize(sPart);
            }
            return sNew;
        }

        public string Capitalize(string s)
        {
            if (s.Length == 0) return "";
            if (s.Length == 1) return s.ToUpper();
            if (s.ToLower() == "web-dl") return "WEB-DL";
            if (s.ToLower() == "webrip") return "WEBRip";
            if (s.ToLower() == "web.x264") return "WEB.x264";
            if (s.ToLower() == "web.h264") return "WEB.h264";
            if (s.ToLower() == "hdr") return "HDR";
            // S01E06
            if (s.Length == 6)
            {                
                if (s.Substring(0, 1).ToLower() == "s" && s.Substring(3, 1).ToLower() == "e")      
                {
                    return s.ToUpper();
                }
            }
            // S01E01E02
            if (s.Length == 9)
            {
                string sSeasonNumber = s.Substring(1, 2);
                if (IsNumeric(sSeasonNumber))
                {                    
                    if (s.Substring(0, 1).ToLower() == "s" && s.Substring(3, 1).ToLower() == "e" && s.Substring(6, 1).ToLower() == "e")      
                    {
                        return s.ToUpper();
                    }
                }
            }
            return s.Substring(0, 1).ToUpper() + s.Substring(1);
        }

        private bool IsNumeric(string s)
        {
            int n = 0;
            if (int.TryParse(s, out n))
                return true;
            return false;
        }
    }
}
