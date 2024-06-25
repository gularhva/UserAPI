using System.ComponentModel.DataAnnotations;

namespace UserAPI.Entities
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Surname { get; set; }
        public int Age { get; set; }
    }
}
