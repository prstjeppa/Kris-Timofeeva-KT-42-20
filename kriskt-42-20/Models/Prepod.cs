﻿using System.Text.RegularExpressions;

namespace kriskt_42_20.Models
{
    public class Prepod
    {
        public int PrepodId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? Phone {  get; set; }
        public string? Mail { get; set; }
        public bool IsValidMail()
        {
            return Regex.Match(Mail, @"^((\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)\\s*[;]{0,1}\\s*)+$").Success;
        }
        public int KafedraId { get; set; }
        public Kafedra? Kafedra { get; set; }
        public Degree? Degree { get; set; }


    }
}
