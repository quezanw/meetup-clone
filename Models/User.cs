using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using BeltExam.Models;

namespace BeltExam.Models {
    public class User {
    [Key]
    public int UserId {get;set;}
    [Required]
    [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "First Name must be non numeric")]
    public string FirstName {get;set;}
    [Required]
    [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Last Name must be non numeric")]
    public string LastName {get;set;}
    [EmailAddress]
    [Required]
    public string Email {get;set;}
    [DataType(DataType.Password)]
    [Required]
    [MinLength(8, ErrorMessage="Password must be 8 characters or longer!")]
    public string Password {get;set;}
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
    // Will not be mapped to your users table!
    [NotMapped]
    [Compare("Password")]
    [DataType(DataType.Password)]
    public string Confirm {get;set;}

    public List<Activity> PlannedActivities { get; set;}
    public List<Attendee> AttendedActivities { get; set;}
    
    }    

}