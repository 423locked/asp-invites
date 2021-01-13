using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PartyInvites.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View("MyView");
        }

        [HttpGet]
        public ViewResult RsvpForm()
        {
            // Render a template
            return View("RsvpForm");
        }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            // Save guest response
            if (ModelState.IsValid)
            {
                Repository.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
            }
            else
            {
                // Entered credentials are not valid
                return View();
            }
        }

        public ViewResult ListResponses()
        {
            // View guest responses where WillAttend == true
            return View(Repository.Responses.Where(row => row.WillAttend == true));
        }
    }
}
