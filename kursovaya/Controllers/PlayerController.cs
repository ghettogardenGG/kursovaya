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
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }
     
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public IActionResult Create(Player obj)
        {
            if (ModelState.IsValid)
            {
                _db.Players.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
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
            existingPlayer.distSpear = model.distSpear;
            existingPlayer.distCore = model.distCore;
            existingPlayer.distHammer = model.distHammer;
            existingPlayer.country = model.country;
            existingPlayer.age = model.age;
            existingPlayer.Name = model.Name;
            existingPlayer.Surname = model.Surname;
            existingPlayer.sport_title = model.sport_title;
            existingPlayer.imageUrl = model.imageUrl;
            _db.Players.Update(existingPlayer);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult EditProfile(int? id)
        {
            var player = _db.Players.FirstOrDefault(x => x.Id == id);
            return View(player);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Player model)
        {
            var existingPlayer = await _db.Players.FirstOrDefaultAsync(x => x.Id == model.Id);
            
                if (existingPlayer != null)
                {
                    _db.Players.Remove(existingPlayer);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            
            return NotFound();
        }
    }
}
