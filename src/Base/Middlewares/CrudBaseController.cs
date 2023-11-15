using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BackEndAPI.Models.Data.Interfaces;
using BackEndAPI.src.Base.Contracts.Service;
using BackEndAPI.src.Base.Enums;
using Microsoft.AspNetCore.Mvc;

namespace BackEndAPI.src.Base.Middlewares
{
    public class CrudBaseController<TModel, TKey> : BaseController where TModel : class, IData<TKey>
    {
        #region  Constructor
        private readonly IService<TModel, TKey> _service;
        public CrudBaseController(IService<TModel, TKey> service)
        {
            _service = service;
        }
        #endregion

        #region GET
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TModel>> Get(TKey id)
        {
            try
            {
                return BuildResponse<TModel>(await _service.Get(id));
            }
            catch (System.Exception ex)
            {
                return BuildResponse(message: $"{ex.Message}", code: EnResultCode.Erro, success: false, httpStatusCode: HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("list")]
        public virtual async Task<ActionResult<List<TModel>>> List()
        {
            try
            {
                return BuildResponse<List<TModel>>(await _service.List());
            }
            catch (System.Exception ex)
            {
                return BuildResponse(message: $"{ex.Message}", code: EnResultCode.Erro, success: false, httpStatusCode: HttpStatusCode.BadRequest);
            }
        }
        #endregion

        #region POST
        [HttpPost("create")]
        public virtual async Task<ActionResult<TModel>> Post([FromBody] TModel createDTO)
        {
            try
            {
                return BuildResponse<TModel>(await _service.Create(createDTO));
            }
            catch (System.Exception ex)
            {
                return BuildResponse(message: $"{ex.Message}", code: EnResultCode.Erro, success: false, httpStatusCode: HttpStatusCode.BadRequest);
            }
        }
        #endregion

        #region PATCH
        [HttpPatch("{id}")]
        public virtual async Task<ActionResult<TModel>> Patch(TKey id, TModel updateDTO)
        {
            try
            {
                return BuildResponse<TModel>(await _service.Update(id, updateDTO));
            }
            catch (System.Exception ex)
            {
                return BuildResponse(message: $"{ex.Message}", code: EnResultCode.Erro, success: false, httpStatusCode: HttpStatusCode.BadRequest);
            }
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult<bool>> Delete(TKey id)
        {
            try
            {
                return BuildResponse<bool>(await _service.Delete(id));
            }
            catch (System.Exception ex)
            {
                return BuildResponse(message: $"{ex.Message}", code: EnResultCode.Erro, success: false, httpStatusCode: HttpStatusCode.BadRequest);
            }
        }
        #endregion
    }
}