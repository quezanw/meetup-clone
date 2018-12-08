using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using BeltExam.Models;

namespace BeltExam.Models {
    public class Activity {
    [Key]
    public int ActivityId {get;set;}
    [Required]
    [MinLength(2)]
    public string Title { get; set; }
    [Required]
    public TimeSpan Time { get; set; }
    [Required]
    public DateTime Date { get; set; } // custom validation must be in future
    [Required]
    public int Duration { get; set; }
    [Required]
    public string DurationType { get; set; }

    [Required]
    [MinLength(10)]
    public string Description {get;set;}

    public int UserId { get; set; }
    public User Planner { get; set; }

    public List<Attendee> Attendees { get; set;}
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
    
    }    

}