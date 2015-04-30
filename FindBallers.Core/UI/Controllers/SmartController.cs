using System.Web.Mvc;

namespace CMS.Core.UI.Controllers
{
    public class SmartController: Controller
    {

        protected void Success()
        {
            ViewData["success"] = "";
        }

        protected ViewResult Success<TModel>(TModel viewModel)
        {
            Success();
            return View(viewModel);
        }

    }
}
