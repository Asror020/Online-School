﻿namespace Api.Dtos
{
    public class ProfessorDto
    {
        public int Id { get; set; } 
        public string UserId { get; set; }
        public UserDto User{ get; set; }
    }
}