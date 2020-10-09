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
            //var river = await _context.River.ToListAsync();
            if (user == null)
            {
                return View("Welcome");
            }
            else
            {
                ProgressViewModel viewModel = new ProgressViewModel();

                //Get all of the float Trips for each of the 5 Rivers
                var River1Total = await _context.FloatTrip.Include(f => f.River).Include(f => f.User).Where(r => r.UserId == user.Id && r.RiverId == 1)
                    .ToListAsync();
                if (River1Total.Count > 0)
                {
                    viewModel.River1 = River1Total.First().River;
                }
                float ?totalMilesR1 = 0;
                float TotalLengthR1 = viewModel.River1.TotalLength;
                float ?ProgressBarR1 = 0;

                foreach (var item in River1Total)
                {
                    if (item.Distance != null)
                    {
                        totalMilesR1 += item.Distance;
                    }
                }
                viewModel.DistanceTraveledOnRiver1 = totalMilesR1;
                ProgressBarR1 = (totalMilesR1 / TotalLengthR1) * 100;
                viewModel.PercentofRiver1 = $"{Math.Round((decimal)ProgressBarR1)}%";

                var River2Total = await _context.FloatTrip.Include(f => f.River).Include(f => f.User).Where(r => r.UserId == user.Id && r.RiverId == 2)
                    .ToListAsync();
                if (River2Total.Count > 0)
                {
                    viewModel.River2 = River2Total.First().River;
                }
                float ?totalMilesR2 = 0;
                float TotalLengthR2 = viewModel.River2.TotalLength;
                float? ProgressBarR2 = 0;

                foreach (var item in River2Total)
                {
                    if (item.Distance != null)
                    {
                        totalMilesR2 += item.Distance;
                    }
                }
                viewModel.DistanceTraveledOnRiver2 = totalMilesR2;
                ProgressBarR2 = (totalMilesR2 / TotalLengthR2) * 100;
                viewModel.PercentofRiver2 = $"{Math.Round((decimal)ProgressBarR2)}%";

                var River3Total = await _context.FloatTrip.Include(f => f.River).Include(f => f.User).Where(r => r.UserId == user.Id && r.RiverId == 3)
                    .ToListAsync();
                if (River3Total.Count > 0)
                {
                    viewModel.River3 = River3Total.First().River;
                }
                float ?totalMilesR3 = 0;
                float TotalLengthR3 = viewModel.River3.TotalLength;
                float? ProgressBarR3 = 0;

                foreach (var item in River3Total)
                {
                    if (item.Distance != null)
                    {
                        totalMilesR3 += item.Distance;
                    }
                }

                viewModel.DistanceTraveledOnRiver3 = totalMilesR3;
                ProgressBarR3 = (totalMilesR3 / TotalLengthR3) * 100;
                viewModel.PercentofRiver3 = $"{Math.Round((decimal)ProgressBarR3)}%";

                var River4Total = await _context.FloatTrip.Include(f => f.River).Include(f => f.User).Where(r => r.UserId == user.Id && r.RiverId == 4)
                    .ToListAsync();

                if (River4Total.Count > 0)
                {
                    viewModel.River4 = River4Total.First().River;
                }
                float ?totalMilesR4 = 0;
                float TotalLengthR4 = viewModel.River4.TotalLength;
                float? ProgressBarR4 = 0;

                foreach (var item in River4Total)
                {
                    if (item.Distance != null)
                    {
                        totalMilesR4 += item.Distance;
                    }
                }
                viewModel.DistanceTraveledOnRiver4 = totalMilesR4;
                ProgressBarR4 = (totalMilesR4 / TotalLengthR4) * 100;
                viewModel.PercentofRiver4 = $"{Math.Round((decimal)ProgressBarR4)}%";

                var River5Total = await _context.FloatTrip.Include(f => f.River).Include(f => f.User).Where(r => r.UserId == user.Id && r.RiverId == 5)
                    .ToListAsync();

                if (River5Total.Count > 0)
                {
                    viewModel.River5 = River5Total.First().River;
                }
                float ?totalMilesR5 = 0;
                float TotalLengthR5 = viewModel.River5.TotalLength;
                float? ProgressBarR5 = 0;

                foreach (var item in River5Total)
                {
                    if (item.Distance != null)
                    {
                        totalMilesR5 += item.Distance;
                    }
                }

                viewModel.DistanceTraveledOnRiver5 = totalMilesR5;
                ProgressBarR5 = (totalMilesR5 / TotalLengthR5) * 100;
                viewModel.PercentofRiver5 = $"{Math.Round((decimal)ProgressBarR5)}%";
                return View(viewModel);
            }
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
