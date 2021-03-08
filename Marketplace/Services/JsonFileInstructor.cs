using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Marketplace.Models;
using Microsoft.AspNetCore.Hosting;

namespace Marketplace.Services
{
    public class JsonFileInstructor
    {
        public JsonFileInstructor(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "instructors.json"); }
        }

        public IEnumerable<InstructorModel> GetInstructors()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<InstructorModel[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }
    }
}