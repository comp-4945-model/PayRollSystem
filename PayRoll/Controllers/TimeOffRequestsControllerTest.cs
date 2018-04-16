using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayRoll.Controllers;

namespace PayRoll.Controllers
{
	[TestClass]
    public class TimeOffRequestsControllerTest : Controller
    {
        // GET: TimeOffRequestsControllerTest
        public ActionResult Index()
        {
            return View();
        }
    }
}