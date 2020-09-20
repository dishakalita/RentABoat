using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessService.RentServices;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RentABoat.Controllers
{
    public class RentController : Controller
    {
        private IRentBoatService rentBoatService { get; set; }
        public RentController(IRentBoatService rent)
        {
            rentBoatService = rent;
        }
        public ActionResult Index()
        {
            var boatList = rentBoatService.GetBoats();
            var boatSelectList = new List<SelectListItem>();
            foreach (var item in boatList)
            {
                boatSelectList.Add(new SelectListItem { Text = item.Name, Value = item.BoatId.ToString() });           
            }
            ViewBag.BoatSelectList = boatSelectList;
            return View(boatList);
        }

        // GET: RentController/Details/5
        public ActionResult RentToCustomer(int BoatId, string CustomerName,long ContactNo)
        {
            string errorText = String.Empty;
            try
            {
                //check if boat is available
                var boatList = rentBoatService.GetBoats();
                var isAvailable = boatList.Select(x => x.BoatId == BoatId).FirstOrDefault();
                if(!isAvailable)
                {
                    errorText = "Selected boat is not available right now. Please select a different boat.";
                    return Json(new { success = false, errorText = errorText });
                }
                rentBoatService.RentBoatToCustomer(BoatId, CustomerName, ContactNo);
            }
            catch(Exception ex)
            {
                errorText = ex.Message;
            }
            if (errorText != String.Empty)
            {
                return Json(new { success = false, errortext = errorText });
            }
            else
                return Json(new { success = true, boatid = BoatId.ToString(), cusname = CustomerName.ToString() });
        }

      
    }
}
