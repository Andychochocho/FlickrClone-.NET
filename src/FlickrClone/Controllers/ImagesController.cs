using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using FlickrClone.Models;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using Microsoft.Data.Entity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace FlickrClone.Controllers
{
    [Authorize]
    public class ImagesController : Controller
    {
        
        //public class FlickrCloneController : Controller
        //{
            private readonly ApplicationDbContext _db;
            private readonly UserManager<ApplicationUser> _userManager;

            public ImagesController(
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
            return View(_db.Images.ToList());
        }


        public IActionResult Details(int id)
        {
            var thisImage = _db.Images.FirstOrDefault(images => images.ImageId == id);
            return View(thisImage);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Image image)
        {
            var currentUser = await _userManager.FindByIdAsync(User.GetUserId());
            image.User = currentUser;
            _db.Images.Add(image);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        
        public IActionResult Edit(int id)
        {
            var thisImage = _db.Images.FirstOrDefault(images => images.ImageId == id);
            return View(thisImage);
        }

        [HttpPost]
        public IActionResult Edit(Image image)
        {
            _db.Entry(image).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}
