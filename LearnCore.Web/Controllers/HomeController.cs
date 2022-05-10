using LearnCore.Web.Interfaces;
using LearnCore.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LearnCore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerService _customerService;

        public HomeController(
            ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _customerService.PrepareCustomerModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                var customer = await _customerService.InsertCustomerModel(model);
                if (customer != null)
                    return RedirectToAction("Index", "Home");
                else
                    ModelState.AddModelError("", "Something went wrong while saving new customer details");
            }

            //if something failed then redisplay form 
            model = await _customerService.PrepareCustomerModel();

            return View(model);
        }

        public async Task<IActionResult> CustomerList()
        {
            var model = await _customerService.PrepareCustomerListModel();
            return View(model);
        }
    }
}
