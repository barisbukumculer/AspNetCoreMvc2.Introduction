using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMvc2.Introduction.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CityId { get; set; }
    }
}
