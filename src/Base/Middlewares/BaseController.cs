using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BackEndAPI.Models;
using BackEndAPI.src.Base.Enums;
using Microsoft.AspNetCore.Mvc;

namespace BackEndAPI.src.Base.Middlewares
{
    public abstract class BaseController : ControllerBase
    {
        /// <summary>
        /// Default API Response
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="value"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="httpStatusCode"></param>
        /// <returns></returns>
        protected ActionResult BuildResponse<TValue>(TValue value, EnResultCode code = EnResultCode.Success, string message = "", HttpStatusCode httpStatusCode = HttpStatusCode.OK, bool success = true)
        {
            int resultCount = 0;
            if (value != null && value is IList && value.GetType().IsGenericType)
            {
                var property = typeof(ICollection).GetProperty("Count");
                resultCount = (int)property.GetValue(value, null);
            }
            else if (value != null)
            {
                resultCount = 1;
            }

            if (success) code = EnResultCode.Success;
            if (!success) code = EnResultCode.Erro;

            APIDataResponse<TValue> response = new()
            {
                Success = success,
                Code = code,
                Message = message,
                ResultCount = resultCount,
                Data = value,
            };

            return StatusCode(httpStatusCode.GetHashCode(), response);
        }

        /// <summary>
        /// Defautl API Response
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="httpStatusCode"></param>
        /// <returns></returns>
        protected ActionResult BuildResponse(EnResultCode code = EnResultCode.Success, string message = "", HttpStatusCode httpStatusCode = HttpStatusCode.OK, bool success = true)
        {
            if (success) code = EnResultCode.Success;
            if (!success) code = EnResultCode.Erro;

            APIDataResponse response = new()
            {
                Success = success,
                Code = code,
                Message = message,
            };

            return StatusCode(httpStatusCode.GetHashCode(), response);
        }
    }
}