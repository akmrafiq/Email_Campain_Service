using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Email_Campain_Service.Core.Entities;
using Email_Campain_Service.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Email_Campain_Service.Web.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerService _customerService;
        private readonly ILogger _logger;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public ActionResult<Customer> Index()
        {
            var list = _customerService.GetCustomers();
            return View(list);
        }
        public IActionResult Add()
        {
            var model = new Customer();
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _customerService.AddCustomer(customer);
                }
                catch (Exception ex)
                {
                    _logger.LogInformation("Exception", ex);
                    return View(customer);
                };
            }
            return RedirectToAction("Index");
        }
    }
}