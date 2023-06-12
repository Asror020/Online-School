using System.ComponentModel.DataAnnotations;

namespace Api.Dtos
{
    public class SubjectDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int ProfessorId { get; set; }

        [Required]
        public string ProfessorFullName { get; set; }
        public string StudentsList { get; set; } = string.Empty;
    }
}
