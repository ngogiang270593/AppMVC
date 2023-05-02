using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LearnAspNet.Controllers
{
    public class ConfigModel:PageModel
    {
        public string ContentRootPath {get;set;}
        public ConfigModel(IHostEnvironment env){
            ContentRootPath = env.ContentRootPath;
        }
    }
}