using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RiverMeThis.Data;
using RiverMeThis.Models;
using RiverMeThis.Models.ProgressViewModels;

namespace RiverMeThis.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;
        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public async Task<IActionResult> Index()
        {
            //get all rivers out of db with total length of river
            //give me the floats where userid= logged in user and river id is 1 - 2 - 3
            //add up mileage from each float on the river to end up with 3 rivers and 3 separate totals 
            //viewmodel depends on what progress bar needs

            //Get current user
            var user = await GetCurrentUserAsync();
            var river = await _context.River.ToListAsync();
            
            var River2Total = await _context.FloatTrip.Include(f => f.River).Include(f => f.User).Where(r => r.UserId == user.Id && r.RiverId == 2)
                .ToListAsync();
            ProgressViewModel viewModel = new ProgressViewModel();
            viewModel.River2 = River2Total.First().River;
            // viewModel.DistanceTraveledOnRiver;
            //viewModel.River2.Name = river.FirstOrDefault().Name;
            
        float ?totalMiles = 0;
            
                foreach (var item in River2Total)
                {
                totalMiles += item.Distance;
                }
            viewModel.DistanceTraveledOnRiver2 = totalMiles;
                  
            
                       
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
