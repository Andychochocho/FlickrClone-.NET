using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using FlickrClone.Models;
using Microsoft.AspNet.Identity;
using System.Security.Claims;

namespace FlickrClone.Controllers
{
    [Authorize]
    public class CommentsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public CommentsController(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext db
        )
        {
            _userManager = userManager;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.FindByIdAsync(User.GetUserId());
            return View(_db.Images.Where(x => x.User.Id == currentUser.Id));
        }

        public IActionResult Create(int id)
        {
            ViewBag.PicId = id; 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Comment comment, int id)
        {
            var currentUser = await _userManager.FindByIdAsync(User.GetUserId());
            comment.User = currentUser;
            comment.ImageId = id;
            _db.Comments.Add(comment);
            _db.SaveChanges();
            return RedirectToAction("Details", "Images");
        }
    }
    
}
