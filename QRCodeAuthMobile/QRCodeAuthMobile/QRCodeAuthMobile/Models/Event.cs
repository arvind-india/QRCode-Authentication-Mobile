﻿/*
 * Purpose: 
 * This is a model class for an Event object that has data annotations for its associated SQLite Table
 * 
 * Contributors: 
 * Naomi Wiggins 
 * 
 */

using SQLite;
using System;
using System.Collections.Generic;

namespace QRCodeAuthMobile.Models
{
	[Table("Events")]
	public class Event
	{
		public Event()
		{
		}

		// Primary Key
		[PrimaryKey]
		public int EventId { get; set; }
		public string Name { get; set; }
		public string Location { get; set; }
		public EventType EventType { get; set; }
		public DateTime Date { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public string Description { get; set; }
		public bool isPassed { get; set; }
		[Ignore]
		public List<CredentialType> CredentialsNeeded { get; set; }

		// Foreign Keys
		public string Owner { get; set; }
	}
}
