using WpfApp1.Models;
using System.Collections.Generic;

public class Student : User
{
    public string Name { get; set; } = "";
    public int LevelNumber { get; set; }
    public string Level { get; set; } = "";
    public List<Result> Results { get; set; } = new();
}