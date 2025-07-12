using FirstWebAPI_Task5.Models;
using System;
using System.Collections.Generic;

namespace FirstWebAPI_Task5.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }                    // ← Nullable
        public int Salary { get; set; }
        public bool Permanent { get; set; }
        public Department? Department { get; set; }          // ← Nullable
        public List<Skill>? Skills { get; set; }             // ← Nullable
        public DateTime DateOfBirth { get; set; }
    }
}
