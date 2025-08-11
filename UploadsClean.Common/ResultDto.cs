using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadsClean.Common
{
    public class ResultDto
    {
        public bool IsSuccess { set; get; }
        public string Message { set; get; }
       
    }

    public class ResultDto<T>
    {
        public bool IsSuccess { set; get; }
        public string Message { set; get; }
        public T Data { set; get; }

    }



}
