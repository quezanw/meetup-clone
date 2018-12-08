using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BeltExam.Models;
using System.Collections.Generic;

    namespace BeltExam.Models {
    public class Attendee
    {
        [Key]
        public int AttendeeId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
    }


}
