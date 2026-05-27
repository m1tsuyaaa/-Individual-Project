using System;
using EmailLab.Services;
using EmailLab.UI;

namespace EmailLab {
  public static class Program {
    public static void Main() {
      Console.Title = "Email Client - Singleton Pattern";
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine("=========================================");
      Console.WriteLine("           EMAIL CLIENT");
      Console.WriteLine("         Singleton Pattern");
      Console.WriteLine("=========================================");
      Console.ResetColor();

      EmailClient client = EmailClient.GetInstance();

      Console.Write("\nEnter your email: ");
      string userEmail = Console.ReadLine();
      client.SetUserEmail(userEmail);

      MenuRenderer.ShowWelcomeMessage(userEmail);

      bool exit = false;

      while (!exit) {
        MenuRenderer.DisplayMainMenu();
        string choice = Console.ReadLine();

        if (choice == "1") {
          SendEmailFlow(client);
        } else if (choice == "2") {
          ReceiveEmailsFlow(client);
        } else if (choice == "3") {
          client.DisplayInbox();
        } else if (choice == "4") {
          client.DisplaySentEmails();
        } else if (choice == "5") {
          MarkAsReadFlow(client);
        } else if (choice == "6") {
          client.DisplayStatistics();
        } else if (choice == "0") {
          exit = true;
          MenuRenderer.ShowExitMessage();
        } else {
          MenuRenderer.ShowErrorMessage("Invalid choice! Please try again.");
        }

        if (!exit) {
          MenuRenderer.ShowSeparator();
        }
      }
    }

    private static void SendEmailFlow(EmailClient client) {
      MenuRenderer.ShowSectionTitle("SEND EMAIL");

      Console.Write("To: ");
      string to = Console.ReadLine();

      if (string.IsNullOrWhiteSpace(to)) {
        MenuRenderer.ShowErrorMessage("Recipient address cannot be empty");
        return;
      }

      Console.Write("Subject: ");
      string subject = Console.ReadLine();

      Console.Write("Body: ");
      string body = Console.ReadLine();

      if (client.SendEmail(to, subject, body)) {
        MenuRenderer.ShowSuccessMessage("Email sent successfully!");
      }
    }

    private static void ReceiveEmailsFlow(EmailClient client) {
      MenuRenderer.ShowSectionTitle("RECEIVE EMAILS");

      client.ReceiveNewEmails();

      MenuRenderer.ShowSuccessMessage("Mailbox updated successfully");
    }

    private static void MarkAsReadFlow(EmailClient client) {
      MenuRenderer.ShowSectionTitle("MARK AS READ");

      client.DisplayInbox();

      Console.Write("\nEnter email number: ");
      string input = Console.ReadLine();

      if (int.TryParse(input, out int number)) {
        client.MarkEmailAsRead(number);
        MenuRenderer.ShowSuccessMessage("Email marked as read");
      } else {
        MenuRenderer.ShowErrorMessage("Enter a valid email number");
      }
    }
  }
}