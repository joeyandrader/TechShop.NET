using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndAPI.src.Base.Enums;

namespace BackEndAPI.Models
{
    public class APIDataResponse
    {
        public bool Success { get; set; }
        public EnResultCode Code { get; set; }
        public string Message { get; set; }
        public int ResultCount { get; set; }
    }

    public class APIDataResponse<T> : APIDataResponse
    {
        public T Data { get; set; }
    }
}