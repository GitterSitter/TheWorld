using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheWorld.ViewModels;
using TheWorld.Services;
using Microsoft.Extensions.Configuration;
using TheWorld.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheWorld.Controllers
{
    public class AppController : Controller
    {

        private IMailService _mailService;
        private IConfigurationRoot _config;
        private IWorldRepository _repository;
        private ILogger<AppController> _logger;

        // private WorldContext _context;

        public AppController(IMailService mailService, 
            IConfigurationRoot config, 
            IWorldRepository repository,
            ILogger<AppController> logger )
        {
            _mailService = mailService;
            _config = config;
            _repository = repository;
            _logger = logger;
        //    _context = context;
        }

        [Authorize]
        public IActionResult Trips()
        {
            return View();

        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {

           // throw new InvalidOperationException("Something went really wrong :/");

            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {

            if (model.Email.Contains("aol.com"))
                ModelState.AddModelError("Email", "We dont support aol addresses!");

            if (ModelState.IsValid)
            {
                _mailService.SendMail(_config["MailSettings:ToAddress"], model.Email, "From theWorld", model.Message);

                ModelState.Clear();

                ViewBag.UserMessage = "Message Sent";
            }
            return View();
        }

        

        public IActionResult About()
        {

            return View();
        }


    }
}
