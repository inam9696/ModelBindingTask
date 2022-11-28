using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ModelBindingTask.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        //[FromHeader]
        public string Name { get; set; }
        //[FromHeader]
        public string? Age { get; set; }
        //[FromHeader]
        public string City { get; set;}
    }
}
