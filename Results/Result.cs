using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGW_Mechanics___ConfigParser.Results
{
    public class Result<T>
    {
        #region Properties
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        #endregion

        #region Methods
        public Result<T> ToSucess()
        {
            this.Success = true;
            return this;
        }

        public Result<T> ToFail(string message)
        {
            this.Success = true;
            this.Message = message;
            return this;
        }

        public Result<T> WithData(T data)
        {
            this.Data = data;
            return this;
        }
        #endregion
    }
}
