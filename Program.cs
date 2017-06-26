using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;

namespace PhoneCallScript
{
	class Program
	{
		public static string accountId = ""; //Can be accessed from: https://www.twilio.com/console
		public static string authToken = ""; //Can be accessed from: https://www.twilio.com/console
		public static List<string> numbers = new List<string>(new string[] { "+1", "+1" }); //Get numbers from the twilio API https://www.twilio.com/console/phone-numbers/search (one dollar each)		public static List<string> numbersInUse = new List<string>(); //Idk why the guy included this, it was never used
		public static string NumToCall = "";
		static void Main(string[] args)
		{
			Console.WriteLine(" -- Call Scammer Line Flooder (v0.0.1) -- "); //Fuck yeah, semantic versioning
			Console.Write("Enter number to flood harder than the red sea in egypt (remember to add +1 at the beginning): ");
			NumToCall = Console.ReadLine();
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
					record: true, //You can access the recordings from: https://www.twilio.com/console/voice/dashboard
					url: new Uri("") //Should be a link to this kind of file: https://www.twilio.com/docs/api/twiml - Host here: https://www.twilio.com/console/dev-tools/twiml-bins
				);
				Console.WriteLine($"Starting call to {call.To} from {fromNumber} starting {call.StartTime}.");
			}
			catch (Exception ex)
			{
				Console.WriteLine("An exception occurred when making call object, perhaps you must replace the URI text.");
				Console.WriteLine(ex);
			}
		}
	}
}
