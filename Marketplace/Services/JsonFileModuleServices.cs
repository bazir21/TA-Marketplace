using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Marketplace.Models;
using Microsoft.AspNetCore.Hosting;

namespace Marketplace.Services
{
    public class JsonFileModuleService
    {
        public JsonFileModuleService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonModuleFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "modules.json"); }
        }

        public IEnumerable<ModuleModel> GetModules()
        {
            using(var jsonFileReader = File.OpenText(JsonModuleFileName))
            {
                return JsonSerializer.Deserialize<ModuleModel[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        

    }
}