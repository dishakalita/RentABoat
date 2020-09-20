using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentABoat.Models;
using BusinessService.RegisterServices;
using ViewModels;
namespace RentABoat.Controllers
{
   
    public class RegisterController : Controller
    {
        private IRegisterBoatService registerBoatService { get; set; }
        public RegisterController(IRegisterBoatService register)
        {
            registerBoatService = register;
        }
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult RegisterBoat(string boatName,decimal hourlyRate)
        {
            var res=registerBoatService.RegisterBoat(boatName, hourlyRate);
            if (res != -1)
                return Json(new { success = true, boatid = res, boatname=boatName }) ;
            else
                return Json(new { success = false, boatid = res });

        }
    }
}
