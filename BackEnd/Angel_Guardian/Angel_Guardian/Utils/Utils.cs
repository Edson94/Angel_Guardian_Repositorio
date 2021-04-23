using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angel_Guardian.Utils
{
    public class Utils
    {
        public static bool IsNumber(String value) {
            try {
                String numbers = "1234567890";
                for (int i = 0; i < value.Length; i++) {
                    if (numbers.IndexOf(value[i]) < 0)
                        return false;
                }                        
            }
            catch (Exception) { throw; }
            return true;
        }
        public static bool IsEMail(String value) {
            try {
                int lenght = value.Length - 1;
                int pos = value.IndexOf('@');
                if (pos > 0) 
                     return true;
            }catch (Exception) { throw; }
            return false;
        }
    }
}
