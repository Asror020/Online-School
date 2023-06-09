namespace Api.Dtos
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string RegistrationId { get; set; }
        public int UserId { get; set;}
        public UserDto User { get; set; }
    }
}
