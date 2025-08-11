using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace UploadsClean.Persistence.DataBaceContext
{
    public static class Convertor
    {
        public static int ToInt(this object input)
        {
            try
            {        
                int.TryParse(input.ToString(), out int result);
                return result;
            }
            catch
            {
                return 0;   
            }
        
        }
       public static DateTime ToDateTime(this object input) 
       {
            try
            {
                DateTime.TryParse(input.ToString(), out DateTime result);
                return result;
            }
            catch 
            {
                return SqlDateTime.MinValue.Value;
            }
       }
    
    
    }
}
