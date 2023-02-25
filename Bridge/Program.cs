using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new SmsSender());
            customerManager.UpdateCustomer();
            Console.ReadLine();
        }
    }
    abstract class MessageSenderbase
    {
        public void Save()
        {
            Console.WriteLine("Message Saved");
        }
        public abstract void Send(Body body);
    }

    public class Body
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }

    class SmsSender : MessageSenderbase
    {


        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via SmsSender", body.Title);
        }
    }
    class EmailSender : MessageSenderbase
    {


        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via EmailSender", body.Title);
        }
    }
    class CustomerManager
    {
        MessageSenderbase sender;

        public CustomerManager(MessageSenderbase sender)
        {
            this.sender = sender;
        }

        public void UpdateCustomer()
        {
            sender.Send(new Body { Title = "About the Course" });
            Console.WriteLine("Customer update");
        }

    }
}
