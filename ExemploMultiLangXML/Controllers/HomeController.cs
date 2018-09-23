using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExemploMultiLangXML.Models;
using ExemploMultiLangXML.Services;
using Microsoft.AspNetCore.Http;

namespace ExemploMultiLangXML.Controllers
{
    public class HomeController : BaseController
    {

        public HomeController(IMultiLang multiLang, IHttpContextAccessor httpContext) : base(multiLang, httpContext)
        {

        }

        public IActionResult Index()
        {
            ViewData["Message"] = _multiLang.GetEntry("HomeMessage");
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = _multiLang.GetEntry("AboutMessage");
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = _multiLang.GetEntry("ContactMessage");
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
