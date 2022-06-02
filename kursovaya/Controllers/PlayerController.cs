using kursovaya.Data;
using kursovaya.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace kursovaya.Controllers
{
    public class PlayerController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PlayerController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Player> objPlayersList = _db.Players.ToList();
            return View(objPlayersList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
     
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public IActionResult Create(Player obj)
        {
            if (ModelState.IsValid)
            {
                _db.Players.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index");
        }
        [Authorize(Roles = "admin, user")]
        public IActionResult ProfilePlayer(int? id)
        {
            var player = _db.Players.FirstOrDefault(x => x.Id == id);
            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Save(Player model)
        {
            var existingPlayer = await _db.Players.FirstOrDefaultAsync(x => x.Id == model.Id);
            if(existingPlayer is null)
            {
                return NotFound();
            }
            existingPlayer.distDisk = model.distDisk;
            _db.Players.Update(existingPlayer);
            await _db.SaveChangesAsync();
            return RedirectToAction("/Home/Index");
        }
        public IActionResult EditProfile(int? id)
        {
            var player = _db.Players.FirstOrDefault(x => x.Id == id);
            return View(player);
        }
    }
}
