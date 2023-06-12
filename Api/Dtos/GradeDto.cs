using System.ComponentModel.DataAnnotations;

namespace Api.Dtos
{
    public class GradeDto
    {
        public int Id { get; set; }

        [Required]
        public string SubjectName { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        [Range(0, 100)]
        public byte Score { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(4)]
        public string StudentFullName { get; set; }
    }
}
