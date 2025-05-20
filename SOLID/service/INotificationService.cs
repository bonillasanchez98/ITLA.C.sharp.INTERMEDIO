namespace SOLID.service
{
    public interface INotificationService
    {
        void SendEmmail(string email, string message);
        void SendSMS(string phoneNumber, string message);
    }
}
