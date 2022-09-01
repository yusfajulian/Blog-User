 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pertemuan1.Helper
{
    public static class BanyakBantuan
    {
        public static int ButaOTP()
        {
            Random r = new(); // cara simpel dari Random r = new random();
            return r.Next(1000, 9999); //(Star, Stop)
        }  
        
        public static object Respon(string status, int respon_code, string message, object data)
        {
            return new
            {
                status ,
                respon_code ,
                message ,
                data
            };
        }
    }
}
