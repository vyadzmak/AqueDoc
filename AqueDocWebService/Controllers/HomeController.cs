using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AqueDocWebService.Core.Request_handlers;
using AqueDocWebService.Helpers.Request_helpers;

namespace AqueDocWebService.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "AqueDoc Api Web Service";

            return View();
        }

          [HttpPost]
        public JsonResult FilemanagerAction(string request)
        {
            RequestHandler handler = new RequestHandler();

            Core.Models.Request_models.FileManagerRequest formalizedRequest = 
                RequestFormalizer.FormalizeRequest(request);

           AqueDocWebService.Core.Interfaces.IFileManagerResponse response = handler.Handle(formalizedRequest);
            
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}
