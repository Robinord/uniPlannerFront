using System;
using System.Collections.Generic;

namespace uniPlanner.Models;

public partial class Student
{
    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Name { get; set; }

    public DateTime? Dob { get; set; }

    public string? City { get; set; }

    public string? Region { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
