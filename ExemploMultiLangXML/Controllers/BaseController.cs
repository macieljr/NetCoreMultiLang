using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExemploMultiLangXML.Models;
using ExemploMultiLangXML.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExemploMultiLangXML.Controllers
{

    public class BaseController : Controller
    {

        protected readonly IMultiLang _multiLang;

        protected readonly IHttpContextAccessor _httpContext;

        public BaseController(IMultiLang multiLang, IHttpContextAccessor httpContext)
        {
            _multiLang = multiLang;
            _httpContext = httpContext;
        }

        [HttpPost]
        public IActionResult UpdateMultiLang([FromBody] string lang)
        {
            ResultBase result = new ResultBase { Success = false };
            try
            {
                _multiLang.SetLang(lang);
                _httpContext.HttpContext.Session.SetString("MultiLang_CurrentLang", lang);
                result.Success = true;
            }
            catch(Exception e)
            {
                result.Success = false;
                result.Message = e.Message;
            }
            return Json(result);
        }
        
    }
}