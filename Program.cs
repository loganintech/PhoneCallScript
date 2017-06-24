using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;

namespace PhoneCallScript
{
	class Program
	{
		public static string accountId = "";
		public static string authToken = "";
		public static List<string> numbers = new List<string>(new string[] { "", "" }); //Configure in your twilio account. Numbers must be in +12223334444 where 222 is area code and 3334444 is number. More numbers, more calls.
		public static List<string> numbersInUse = new List<string>(); //Idk why the guy included this, it was never used
		public static string NumToCall = "";
		static void Main(string[] args)
		{
			Console.WriteLine(" -- Call Scammer Line Flooder (v0.0.1) -- "); //Fuck yeah, semantic versioning
			Console.WriteLine("Enter number to flood harder than the red sea in egypt (remember to add +1 at the beginning): ");
			Console.ReadLine();
			Console.WriteLine("Press ENTER to let the sea walls fall. Otherwise, hit the X to close.");
			Console.ReadLine();
			Console.Clear();
			TwilioClient.Init(accountId, authToken);

			int count = 0;
			do
			{
				Console.WriteLine($"Starting Call Batch {count + 1} ({numbers.Count} Nums.)");
				foreach (string num in numbers)
				{
					Call(num);
					System.Threading.Thread.Sleep(1000);
				}
				count++;
				System.Threading.Thread.Sleep(5000);
			} while (true); //Dangerous game here, scotty
		}

		static void Call(string fromNumber)
		{
			try
			{
				var call = CallResource.Create(
					to: new PhoneNumber(NumToCall),
					from: new PhoneNumber(fromNumber),
					record: true,
					url: new Uri("Some info on what to do when answering.") //Should be a link to this kind of file: https://www.twilio.com/docs/api/twiml
				);
				Console.WriteLine($"Starting call to {call.To} from {fromNumber}.");
			}
			catch (Exception ex)
			{
				Console.WriteLine("An exception occurred when making call object, perhaps you must replace the URI text.");
				Console.WriteLine(ex);
			}
		}
	}
}
