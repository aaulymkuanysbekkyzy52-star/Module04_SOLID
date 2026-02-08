using System;

namespace Module04_SOLID
{
    // ================= SRP =================
    // Order отвечает только за хранение данных
    public class Order
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }

    public class OrderPriceCalculator
    {
        public double CalculateTotalPrice(Order order)
        {
            return order.Quantity * order.Price * 0.9;
        }
    }

    public class PaymentService
    {
        public void ProcessPayment(string paymentDetails)
        {
            Console.WriteLine("Payment processed using: " + paymentDetails);
        }
    }

    public class OrderNotificationService
    {
        public void SendConfirmationEmail(string email)
        {
            Console.WriteLine("Confirmation email sent to: " + email);
        }
    }

    // ================= OCP =================
    public interface ISalaryCalculator
    {
        double CalculateSalary(double baseSalary);
    }

    public class PermanentSalaryCalculator : ISalaryCalculator
    {
        public double CalculateSalary(double baseSalary)
        {
            return baseSalary * 1.2;
        }
    }

    public class ContractSalaryCalculator : ISalaryCalculator
    {
        public double CalculateSalary(double baseSalary)
        {
            return baseSalary * 1.1;
        }
    }

    public class InternSalaryCalculator : ISalaryCalculator
    {
        public double CalculateSalary(double baseSalary)
        {
            return baseSalary * 0.8;
        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public double BaseSalary { get; set; }
        public ISalaryCalculator SalaryCalculator { get; set; }

        public double GetSalary()
        {
            return SalaryCalculator.CalculateSalary(BaseSalary);
        }
    }

    // ================= ISP =================
    public interface IPrinter
    {
        void Print(string content);
    }

    public interface IScanner
    {
        void Scan(string content);
    }

    public interface IFax
    {
        void Fax(string content);
    }

    public class AllInOnePrinter : IPrinter, IScanner, IFax
    {
        public void Print(string content)
        {
            Console.WriteLine("Printing: " + content);
        }

        public void Scan(string content)
        {
            Console.WriteLine("Scanning: " + content);
        }

        public void Fax(string content)
        {
            Console.WriteLine("Faxing: " + content);
        }
    }

    public class BasicPrinter : IPrinter
    {
        public void Print(string content)
        {
            Console.WriteLine("Printing: " + content);
        }
    }

    // ================= DIP =================
    public interface IMessageSender
    {
        void Send(string message);
    }

    public class EmailSender : IMessageSender
    {
        public void Send(string message)
        {
            Console.WriteLine("Email sent: " + message);
        }
    }

    public class SmsSender : IMessageSender
    {
        public void Send(string message)
        {
            Console.WriteLine("SMS sent: " + message);
        }
    }

    public class NotificationService
    {
        private readonly IMessageSender _sender;

        public NotificationService(IMessageSender sender)
        {
            _sender = sender;
        }

        public void SendNotification(string message)
        {
            _sender.Send(message);
        }
    }

    // ================= MAIN =================
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Module 04 — SOLID principles");
        }
    }
}
