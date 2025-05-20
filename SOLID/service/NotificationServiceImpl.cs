using SOLID.utils;

namespace SOLID.service
{
    public class NotificationServiceImpl : INotificationService
    {
        public void SendEmmail(string email, string message)
        {
            Console.WriteLine();
            Console.WriteLine($"Sending Email to {email}: {message}");
            Logger.Log("Type Notification: Email");
        }

        public void SendSMS(string phoneNumber, string message)
        {
            Console.WriteLine();
            Console.WriteLine($"Sending SMS to {phoneNumber}: {message}");
            Logger.Log("Type Notification: SMS");
        }
    }
}
