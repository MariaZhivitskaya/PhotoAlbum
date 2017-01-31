using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Interface.Services;
using BLL.Interfacies.Services;
using WebApplication.Infrastructure.Mappers;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IImageService _imageService;
        private readonly ILikeService _likeService;
       
        public HomeController(IUserService uService, IImageService iService, ILikeService lService)
        {
            _userService = uService;
            _imageService = iService;
            _likeService = lService;
        }

        public ActionResult Index() => View();

        public ActionResult Home()
        {
            string email = Membership.GetUser().UserName;
            var user = _userService.GetUserByEmail(email);

            var model = new UserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                Surname = user.Surname,
                Name = user.Name,
                DateOfBirth = user.DateOfBirth,
                RoleId = user.RoleId,
                Banned = user.Banned
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult Photos()
        {
            string email = Membership.GetUser().UserName;
            var user = _userService.GetUserByEmail(email);

            var model = _imageService.GetByUserId(user.Id).Select(img => new ImageViewModel()
            {
                UserId = user.Id,
                Image = img.Image,
                NumberOfLikes = img.NumberOfLikes
            });
           
            return View(model);
        }

        [HttpPost]
        public ActionResult UploadPhotos()
        {
            foreach (string file in Request.Files)
            {
                var upload = Request.Files[file];
                if (upload != null)
                {
                    byte[] fileData;
                    using (var binaryReader = new BinaryReader(upload.InputStream))
                        fileData = binaryReader.ReadBytes(upload.ContentLength);

                    var email = Membership.GetUser().UserName;
                    var user = _userService.GetUserByEmail(email);

                    var image = new ImageViewModel
                    {
                        Image = fileData,
                        UserId = user.Id,
                        NumberOfLikes = 0
                    };

                    _imageService.CreateImage(image.ToBllImage());
                    var model = image;
                    return PartialView("PhotosPartial", model);
                }
            }
            return PartialView("PhotosPartial", null);
        }

        public ActionResult SearchResults(string selectedEmail)
        {
            var user = _userService.GetUserByEmail(selectedEmail);
            var email = Membership.GetUser().UserName;
            var curUser = _userService.GetUserByEmail(email);
           
            var model = _imageService.GetByUserId(user.Id).Select(img => new ImageViewModel()
            {
                Id = img.Id,
                UserId = user.Id,
                Image = img.Image,
                NumberOfLikes = img.NumberOfLikes,
                HasEstimateOfCurUsr = _likeService.IsInDb(img.Id, curUser.Id)
            });
            
            return PartialView("SearchPartial", model);
        }

        [HttpGet]
        public ActionResult Search()
        {
            var model = new SearchViewModel();
            var email = Membership.GetUser().UserName;
            var m = _userService.GetUnbannedUsersExceptCurrent(email).Select(u => u.Email);
            var list = m.Select(elem => new SelectListItem() {Value = elem, Text = elem}).ToList();
            model.Users = list;
            return View(model);
        }

        [HttpPost]
        public ActionResult Like(string likeButton)
        {
            if (Request.IsAjaxRequest())
            {
                var email = Membership.GetUser().UserName;
                var usr = _userService.GetUserByEmail(email);

                var like = new LikeViewModel
                {
                    ImageId = int.Parse(likeButton),
                    UserId = usr.Id
                };

                _likeService.CreateLike(like.ToBllLike());
                _imageService.ChangeNumberOfLikes(int.Parse(likeButton));

                var imgDb = _imageService.GetImageEntity(int.Parse(likeButton));
                
                var img = new ImageViewModel()
                {
                    Image = imgDb.Image,
                    NumberOfLikes = imgDb.NumberOfLikes,
                    UserId = imgDb.UserId,
                    HasEstimateOfCurUsr = true
                };

                return PartialView("LikesPartial", img);
            }
            return View("Index");
        }

        public ActionResult Users()
        {
            string email = Membership.GetUser().UserName;
            
            var items = _userService.GetUsersExceptCurrent(email).Select(usr => new UserViewModel()
            {
                Id = usr.Id,
                Surname = usr.Surname,
                Name = usr.Name,
                Email = usr.Email,
                DateOfBirth = usr.DateOfBirth,
                RoleId = usr.RoleId,
                Banned = usr.Banned
            });

            return PartialView("Users", items);
        }

        [HttpPost]
        public ActionResult BanUnban(string usrEmail)
        {
            if (Request.IsAjaxRequest())
            {
                _userService.BanUnbanUser(usrEmail);
                var usr = _userService.GetUserByEmail(usrEmail);

                var user = new UserViewModel()
                {
                    Id = usr.Id,
                    Surname = usr.Surname,
                    Name = usr.Name,
                    Email = usr.Email,
                    DateOfBirth = usr.DateOfBirth,
                    RoleId = usr.RoleId,
                    Banned = usr.Banned
                };

                return PartialView("ButtonPartial", user);
            }
            return View("Index");
        }
    }
}