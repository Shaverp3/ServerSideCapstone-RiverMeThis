using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RiverMeThis.Data;
using RiverMeThis.Models;
using RiverMeThis.Models.FloatTripViewModels;

namespace RiverMeThis.Controllers
{
    public class FloatTripsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;
        public FloatTripsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: FloatTrips
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            var applicationDbContext = _context.FloatTrip.Include(f => f.Device).Include(f => f.PutInAP).Include(f => f.River).Include(f => f.Sherpa).Include(f => f.TakeOutAP).Include(f => f.User).OrderBy(f => f.Date).Where(r => r.UserId == user.Id);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FloatTrips/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var floatTrip = await _context.FloatTrip
                .Include(f => f.Device)
                .Include(f => f.PutInAP)
                .Include(f => f.River)
                .Include(f => f.Sherpa)
                .Include(f => f.TakeOutAP)
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.FloatTripId == id);
            if (floatTrip == null)
            {
                return NotFound();
            }

            return View(floatTrip);
        }

        // GET: FloatTrips/Create
        public IActionResult Create()
        {
            FloatTripCreateViewModel ViewModel = new FloatTripCreateViewModel();

            ViewModel.rivers = _context.River.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.RiverId.ToString()
            }
          ).ToList();

            ViewModel.rivers.Insert(0, new SelectListItem() { Value = "0", Text = "--Select A River--" });

            ViewModel.devices = _context.Device.Select(d => new SelectListItem
            {
                Text = d.Type,
                Value = d.DeviceId.ToString()
            }
            ).ToList();

            ViewModel.devices.Insert(0, new SelectListItem() { Value = "0", Text = "--Select A Device" });

            return View(ViewModel);
        }

        // POST: FloatTrips/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Date,NumberOfFloaters,UserId,RiverId,DeviceId")] FloatTrip floatTrip)
        {
            ModelState.Remove("floatTrip.User");
            ModelState.Remove("floatTrip.UserId");

            FloatTripCreateViewModel ViewModel = new FloatTripCreateViewModel();
            if (ModelState.IsValid)
            {
                //Check User's Id
                var user = await GetCurrentUserAsync();
                floatTrip.UserId = user.Id;
                _context.Add(floatTrip);
                await _context.SaveChangesAsync();
                return RedirectToAction("PicAPs", new { id = floatTrip.FloatTripId });
            }

            ViewModel.rivers = _context.River.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.RiverId.ToString()
            }).ToList();

            ViewModel.devices = _context.Device.Select(d => new SelectListItem
            {
                Text = d.Type,
                Value = d.DeviceId.ToString()
            }).ToList();

            return View(ViewModel);
        }

        // GET: FloatTrips/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var floatTrip = await _context.FloatTrip
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.FloatTripId == id);

            if (floatTrip == null)
            {
                return NotFound();
            }

            ViewData["DeviceId"] = new SelectList(_context.Device, "DeviceId", "Type", floatTrip.DeviceId);
            ViewData["PutInAPId"] = new SelectList(_context.AccessPoint, "AccessPointId", "AccessPointId", floatTrip.PutInAPId);
            ViewData["RiverId"] = new SelectList(_context.River, "RiverId", "RiverId", floatTrip.RiverId);
            ViewData["SherpaId"] = new SelectList(_context.Sherpa, "SherpaId", "FirstName", floatTrip.SherpaId);
            ViewData["TakeOutAPId"] = new SelectList(_context.AccessPoint, "AccessPointId", "AccessPointId", floatTrip.TakeOutAPId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", floatTrip.UserId);
            return View(floatTrip);
        }

        // POST: FloatTrips/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FloatTripId,Title,Date,Distance,NumberOfFloaters,Duration,Notes,Rating,PicPath,NeedASherpa,UserId,User,RiverId,PutInAPId,TakeOutAPId,DeviceId,SherpaId")] FloatTrip floatTrip)
        {

            if (id != floatTrip.FloatTripId)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
            try
            {
                _context.Update(floatTrip);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FloatTripExists(floatTrip.FloatTripId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        
            return RedirectToAction(nameof(Index));

            ViewData["DeviceId"] = new SelectList(_context.Device, "DeviceId", "Type", floatTrip.DeviceId);
            ViewData["PutInAPId"] = new SelectList(_context.AccessPoint, "AccessPointId", "AccessPointId", floatTrip.PutInAPId);
            ViewData["RiverId"] = new SelectList(_context.River, "RiverId", "RiverId", floatTrip.RiverId);
            ViewData["SherpaId"] = new SelectList(_context.Sherpa, "SherpaId", "FirstName", floatTrip.SherpaId);
            ViewData["TakeOutAPId"] = new SelectList(_context.AccessPoint, "AccessPointId", "AccessPointId", floatTrip.TakeOutAPId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", floatTrip.UserId);
            return View(floatTrip);
        }

        // GET: FloatTrips/PicAPs/5
        public async Task<IActionResult> PicAPs(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var floatTrip = await _context.FloatTrip
                .Include(r => r.River)
                .ThenInclude(ap => ap.AvailableAPs)
                .FirstOrDefaultAsync(m => m.FloatTripId == id);
            
            if (floatTrip == null)
            {
                return NotFound();
            }
                       
            AccessPointsPickViewModel ViewModel = new AccessPointsPickViewModel();
            ViewModel.riverId = floatTrip.River.RiverId;
            //ViewModel.floatTrip.User = floatTrip.User;
            
            ViewModel.putIns = floatTrip.River.AvailableAPs.Select(p => new SelectListItem
            {
                Text = p.Name,
                Value = p.AccessPointId.ToString()
            }
            ).ToList();

            ViewModel.putIns.Insert(0, new SelectListItem() { Value = "0", Text = "--Select A Put-In--" });

            ViewModel.takeOuts = floatTrip.River.AvailableAPs.Select(t => new SelectListItem
            {
                Text = t.Name,
                Value = t.AccessPointId.ToString()
            }
            ).ToList();

            ViewModel.takeOuts.Insert(0, new SelectListItem() { Value = "0", Text = "--Select A Take-Out--" });

            //This ViewModel only has PutInAPId and TakeOutAPId
            return View(ViewModel);
        }
    

        // POST: FloatTrips/PicAPs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        //The following line with Type FloatTrip floatTrip is what is coming in from the Get model above
        public async Task<IActionResult> PicAPs(int id, [Bind("User, UserId, Title,RiverId,PutInAPId,TakeOutAPId,")] FloatTrip floatTrip)
        {
            //Don't need this next line because I am IN the new FloatTrip I'm creating - comes from the int id in the call above

            //if (id != floatTrip.FloatTripId)
            //{
            //    return NotFound();
            //}

            //New ThisfloatTrip variable to get the information on this floattrip from the database
           var ThisfloatTrip = await _context.FloatTrip
               .FirstOrDefaultAsync(f => f.FloatTripId == id);

            //Then add the PutInAPId and the TakeoutAPId from the floatTrip that came in from the Model to ThisfloatTrip from the database

            ThisfloatTrip.PutInAPId = floatTrip.PutInAPId;
            ThisfloatTrip.TakeOutAPId = floatTrip.TakeOutAPId;

            //Don't need to check ModelState because it's not valid - I don't have everything I need in the ModelState
            //if (ModelState.IsValid)
             
                try
                {
                    //Don't need to set the UserId because it's already in ThisfloatTrip variable
                    //var user = await GetCurrentUserAsync();
                    //floatTrip.UserId = user.Id;
                    
                    //Update the database with the new ThisfloatTrip parms (PutInApId and TakeOutApId
                    _context.Update(ThisfloatTrip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FloatTripExists(floatTrip.FloatTripId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            //    AccessPointsPickViewModel viewModel = new AccessPointsPickViewModel();
                
            //    viewModel.floatTrip = await _context.FloatTrip
            //        .FirstOrDefaultAsync(f => f.FloatTripId == id);
            //    viewModel.riverId = floatTrip.RiverId.Value;
            //    viewModel.putIns = _context.AccessPoint.Select(p => new SelectListItem
            //    {

            //        Value = p.AccessPointId.ToString(),
            //        Text = p.Name
            //    }
            //    ).ToList();

            //viewModel.takeOuts = _context.AccessPoint.Select(t => new SelectListItem
            //{
            //    Value = t.AccessPointId.ToString(),
            //    Text = t.Name
            //}
            //).ToList();
            //    return View(viewModel);
            }
            
        
        // GET: FloatTrips/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var floatTrip = await _context.FloatTrip
                .Include(f => f.Device)
                .Include(f => f.PutInAP)
                .Include(f => f.River)
                .Include(f => f.Sherpa)
                .Include(f => f.TakeOutAP)
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.FloatTripId == id);
            if (floatTrip == null)
            {
                return NotFound();
            }

            return View(floatTrip);
        }

        // POST: FloatTrips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var floatTrip = await _context.FloatTrip.FindAsync(id);
            _context.FloatTrip.Remove(floatTrip);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FloatTripExists(int id)
        {
            return _context.FloatTrip.Any(e => e.FloatTripId == id);
        }
    }
}
