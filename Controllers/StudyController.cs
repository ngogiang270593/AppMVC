using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using LearnAspNet.Controllers.Component;
using LearnAspNet.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearnAspNet.Controllers
{
    public class StudyController : Controller
    {
        private ILogger _logger;

        private ConfigModel _config;
        public ProductService productService;
        [TempData]
        public string? StatusMessage {get;set;}
        public StudyController(ILogger<StudyController> logger ,ConfigModel config ,ProductService productService){
            this._logger = logger;
            this._config = config;
            this.productService = productService;
        }
        public string HiHome() => "Xin chào các bạn ,  tôi là HiHome";
        public IActionResult Index()
        {
            //this.HttpContext
            //this.Request
            //this.Response   
            //this.RouteData
        
            //this.User
            //this.ModelState
            //this.ViewData
            //this.ViewBag  
            //this.Url
            //this.TempData
            _logger.LogTrace("LogTrace");
            _logger.LogDebug("LogDebug");
            _logger.LogInformation("LogInformation");
            _logger.LogError("LogError");
            _logger.LogCritical("LogCritical");

            // Kiểu trả về                 | Phương thức
            // ------------------------------------------------
            // ContentResult               | Content()
            // EmptyResult                 | new EmptyResult()
            // FileResult                  | File()
            // ForbidResult                | Forbid()
            // JsonResult                  | Json()
            // LocalRedirectResult         | LocalRedirect()
            // RedirectResult              | Redirect()
            // RedirectToActionResult      | RedirectToAction()
            // RedirectToPageResult        | RedirectToRoute()
            // RedirectToRouteResult       | RedirectToPage()
            // PartialViewResult           | PartialView()
            // ViewComponentResult         | ViewComponent()
            // StatusCodeResult            | StatusCode()
            // ViewResult                  | View()

            return View();
        }

        public IActionResult ExampleContent(){
            return Content("ExampleContent");
        }

        public IActionResult ExampleEmpty(){
            return new EmptyResult();
        }
        [Route("study-file")]
        public IActionResult ExampleFile(){
            var path = Path.Combine(_config.ContentRootPath,"wwwroot/files","anh_1.jpg" );
            var bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes,"image/jpg");
        }

        public IActionResult ExampleForbid(){
            return Forbid();
        }
       
        public IActionResult ExampleJson(){
            List<Product> obj =  new List<Product>();
            obj.Add(new Product(1,"Iphone X"));
            obj.Add(new Product(2,"Iphone 11"));
            string jsonString = JsonSerializer.Serialize(obj);
            _logger.LogInformation(jsonString);
            return Json(obj);
        }

        public class Product{
            public int ID{get;set;}
            public string Name {get;set;}

            public Product(int ID,string Name){
                this.ID = ID;
                this.Name = Name;
            }
        }
        public IActionResult ExampleStatusCode(){
            return StatusCode(403);
        }

        public IActionResult ExampleLocalRedirect(){
            var url = Url.Action("Privacy","Home");
            return LocalRedirect(url);
        }
        public IActionResult ExampleRedirectResult(){
            var url = "https://www.google.com/";
            return Redirect(url);
        }
        public IActionResult ExamplePartialView(){
            return PartialView("_NamePartial");
        }

        public IActionResult ExampleRedirectToAction(){
            return RedirectToAction("ExampleJson");
        }
        public IActionResult ExampleRedirectToRoute(){
           var routeValue = new RouteValueDictionary
            (new { action = "Index", controller = "Home"});
            return RedirectToRoute(routeValue);
        }

        public IActionResult ExampleViewComponent(){
            var component = new MessagePage.Message {
                title = "Thông báo quan trọng",
                htmlcontent = "Đây là <strong>Nội dung HTML</strong>",
                secondwait = 5,
                urlredirect = "/"
            };
            return ViewComponent("MessagePage",component);
        }

        public IActionResult View(int? ID ){
            var model = productService.Where(x=>x.ID == ID).FirstOrDefault();
            if(model != null)
            {
                //TempData["StatusMessage"] = "Sản phầm không tồn tại";
                StatusMessage = "Sản phầm không tồn tại";
                return RedirectToAction("Index");
            }
            ViewData["Title"] = "study";
            return View(model);
        }
    }
}