using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text.Json;

namespace Marketplace.Models
{
    public class InstructorModelList
    {
        public int Id { get; set; }
        public IList<InstructorModel> Instructors { get; set; }  
    }
}