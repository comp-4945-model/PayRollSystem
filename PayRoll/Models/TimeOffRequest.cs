﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PayRoll.Models
{
	public class TimeOffRequest
	{
        [Key]
		public int TimeOffRequestId { get; set; }

		[Required]
		[DataType(DataType.Date)]
		[Display(Name = "Leave")]
		public DateTime StartDate { get; set; } = DateTime.Now;

		[Required]
		[DataType(DataType.Date)]
		[Display(Name = "Come Back")]
		public DateTime EndDate { get; set; } = DateTime.Now;

		[MaxLength(512)]
		public string Reason { get; set; }

        [RegularExpression("Yes|No")]
        public string Status { get; set; } = "No";

		[DataType(DataType.Date)]
		public DateTime WhenSent { get; set; } = DateTime.Now;

        public Employee Employee { get; set; }

        [RegularExpression("Vacation|Personal Emergency|Appointment")]
        public string Type { get; set; }

		public ICollection<Schedule> ShiftsRemoved { get; set; } = new List<Schedule>();
    }
}