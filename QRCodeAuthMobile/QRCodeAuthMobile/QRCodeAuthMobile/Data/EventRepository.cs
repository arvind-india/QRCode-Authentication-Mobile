﻿/*
 * Purpose: Contains all methods needed to perform CRUD operations on the objects in the "events" Table
 * 
 * Algorithm: 
 * Construct class and pass in the database path and create an instance of the events table
 * Add an Event object to the table
 * Get all Event objects from the table and convert them to a list
 * 
 * Notes: All methods in this class are asynchronous
 */

using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QRCodeAuthMobile.Models;

namespace QRCodeAuthMobile.Data
{
	public class EventRepository
	{
		protected static SQLiteAsyncConnection dbconn;
		public static string StatusMessage { get; set; }

		public EventRepository(string dbPath)
		{
			dbconn = new SQLiteAsyncConnection(dbPath);
			dbconn.CreateTableAsync<Event>();
		}

		public static async void AddEventAsync(Event ev)
		{
			int result = 0;
			try
			{
				result = await dbconn.InsertAsync(ev);
				StatusMessage = string.Format("Success! Added event {0}.", ev.Name);
				System.Diagnostics.Debug.WriteLine(StatusMessage);
			}
			catch (Exception ex)
			{
				StatusMessage = string.Format("Failed to add event {0}. Error: {1}", ev.Name, ex.Message);
				System.Diagnostics.Debug.WriteLine(StatusMessage);
			}
		}

		public static async Task<List<Event>> GetAllEventsAsync()
		{
			List<Event> events = new List<Event>();
			try
			{
				events = await dbconn.Table<Event>().ToListAsync();
				StatusMessage = string.Format("Success! Retrieved all events.");
				System.Diagnostics.Debug.WriteLine(StatusMessage);
				return events;
			}
			catch (Exception ex)
			{
				StatusMessage = string.Format("Failed to get event list. Error: {0}", ex.Message);
				System.Diagnostics.Debug.WriteLine(StatusMessage);
				return null;
			}		
		}


	}
}
