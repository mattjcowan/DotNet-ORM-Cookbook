using Recipes.Views;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.Chain.Views
{
    [Table("HR.Employee")]
    public class EmployeeSimple : IEmployeeSimple
    {
        public int EmployeeKey { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Title { get; set; }
        public string? OfficePhone { get; set; }
        public string? CellPhone { get; set; }
        public int EmployeeClassificationKey { get; set; }
    }
}
