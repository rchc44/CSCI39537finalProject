﻿namespace FinalProject.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string? StatusDescription { get; set; }
        public Student? Data { get; set; }
    }
}
