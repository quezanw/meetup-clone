using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BeltExam.Models {
    public class LoginUser
    {   
    // No other fields!
    [Required]
    public string LoginEmail {get; set;}
    [Required]
    public string LoginPassword { get; set; }
    }

}