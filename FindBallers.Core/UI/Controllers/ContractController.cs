using System.Web.Mvc;
using CMS.Core.UI.Controllers;

namespace CMS.Controllers
{
    public class ContractController : SmartController
    {
        [Authorize]
        public ActionResult ContractList()
        {
            return View("ContractList");
        }

        
    }
}