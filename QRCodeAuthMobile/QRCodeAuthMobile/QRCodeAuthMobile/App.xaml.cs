﻿/*
 * Purpose: 
 * Startup class of the application that initializes the application and global variables and 
 * passes them into other classes
 * 
 * Contributors: 
 * Marilin Ortuno
 * Naomi Wiggins
 * 
 */

using Xamarin.Forms;
using QRCodeAuthMobile.Data;

namespace QRCodeAuthMobile
{
	public partial class App : Application
	{
		string dbPath => FileAccessHelper.GetLocalFilePath("UserData.db3");
		public static UserRepository UserRepo { get; private set; }
		public static CredentialRepository CredentialRepo { get; private set; }
		public static EventRepository EventRepo { get; private set; }
		public static MobileAccountRepository MobileAccountRepo { get; private set; }

		public App()
		{
			InitializeComponent();

			UserRepo = new UserRepository(dbPath);
			CredentialRepo = new CredentialRepository(dbPath);
			EventRepo = new EventRepository(dbPath);
			MobileAccountRepo = new MobileAccountRepository(dbPath);

			MainPage = new NavigationPage(new MainPage());
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
