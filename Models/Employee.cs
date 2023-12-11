using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Employee
{
    [Key]
    public int EmployeeId { get; set; }
    public string? EmployeeName { get; set; }
    public string EmployeeColor { get; set; } = "#EA7A57";
    public string? EmployeeEmail { get; set; }
    [ForeignKey("EmployeeId")]
    public List<EventModel> Events { get; set; } = new List<EventModel>();
}

