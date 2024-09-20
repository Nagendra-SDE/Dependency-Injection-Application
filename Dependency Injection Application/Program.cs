using Microsoft.Extensions.DependencyInjection;


namespace Dependency_Injection_Application
{
    public interface IMessageService
    {
        void SendMessage(string message);
    }

    public class ConsoleMessageService : IMessageService
    {
        public void SendMessage(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class Notification 
    {
        private readonly IMessageService messageService;
        public Notification(IMessageService messageService)
        {
            this.messageService = messageService;
        }
        public void notify(string message)
        {
            messageService.SendMessage(message);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceprovider = new ServiceCollection() 
                .AddSingleton<IMessageService, ConsoleMessageService>()
                .AddSingleton<Notification>()
                .BuildServiceProvider();

            var notification = serviceprovider.GetService<Notification>();
            notification.notify("Notification Message");
        }
    }
}
