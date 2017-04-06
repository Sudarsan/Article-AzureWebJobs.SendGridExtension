using System.IO;
using Microsoft.Azure.WebJobs;
using SendGrid.Helpers.Mail;

namespace AzureWebJobs.SendGridExtension
{
	public class Functions
	{
		// This function will get triggered/executed when a new message is written 
		// on an Azure Queue called queue.
		public static void ProcessQueueMessage([QueueTrigger("queue")] string message, TextWriter log, [SendGrid(From = "no-reply@anydomainxyz.com", To = "anybody@anydomainxyz.com")] out Mail mail)
		{
			log.WriteLine(message);

			mail = new Mail();

			mail.Subject = "WebJob - Queue message processed successfully";
			mail.AddContent(new Content("text/plain", $"The message '{message}' was successfully processed."));
		}
	}
}
