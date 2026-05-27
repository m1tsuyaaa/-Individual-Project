using System;
using EmailLab.Services;

namespace EmailLab {
  public static class Program {
    public static void Main() {
      Console.Title = "Email Client - Singleton Pattern";
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine("=========================================");
      Console.WriteLine("         EMAIL CLIENT v1.0");
      Console.WriteLine("         Singleton Pattern");
      Console.WriteLine("=========================================");
      Console.ResetColor();

      EmailClient client = EmailClient.GetInstance();

      Console.Write("\nEnter your email: ");
      string userEmail = Console.ReadLine();
      client.SetUserEmail(userEmail);

      Console.Clear();
      ShowWelcomeMessage(userEmail);

      bool exit = false;

      while (!exit) {
        DisplayMenu();
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
          ShowExitMessage();
        } else {
          ShowErrorMessage("Invalid choice! Please try again.");
        }

        if (!exit) {
          Console.ForegroundColor = ConsoleColor.DarkGray;
          Console.WriteLine("\nPress any key to continue...");
          Console.ResetColor();
          Console.ReadKey();
          Console.Clear();
        }
      }
    }

    private static void ShowWelcomeMessage(string email) {
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine("\nWelcome, {0}!", email);
      Console.WriteLine("Email client successfully started");
      Console.ResetColor();
      Console.WriteLine("\nPress any key to continue...");
      Console.ReadKey();
      Console.Clear();
    }

    private static void ShowExitMessage() {
      Console.Clear();
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine("=========================================");
      Console.WriteLine("              Goodbye!");
      Console.WriteLine("         Thanks for using");
      Console.WriteLine("=========================================");
      Console.ResetColor();
      Console.WriteLine("\nPress any key to exit...");
      Console.ReadKey();
    }

    private static void ShowErrorMessage(string message) {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("\nError: {0}", message);
      Console.ResetColor();
    }

    private static void ShowSuccessMessage(string message) {
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine("\n{0}", message);
      Console.ResetColor();
    }

    private static void DisplayMenu() {
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine("\n+--------------------------------------------------+");
      Console.WriteLine("|                   MAIN MENU                      |");
      Console.WriteLine("+--------------------------------------------------+");
      Console.ResetColor();
      Console.WriteLine("| 1. Send email                                    |");
      Console.WriteLine("| 2. Receive new emails                            |");
      Console.WriteLine("| 3. View inbox                                    |");
      Console.WriteLine("| 4. View sent                                     |");
      Console.WriteLine("| 5. Mark email as read                            |");
      Console.WriteLine("| 6. Show statistics                               |");
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("| 0. Exit                                          |");
      Console.ResetColor();
      Console.WriteLine("+--------------------------------------------------+");
      Console.Write("\nChoose option: ");
    }

    private static void SendEmailFlow(EmailClient client) {
      Console.Clear();
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine("\n=== SEND EMAIL ===");
      Console.ResetColor();

      Console.Write("To: ");
      string to = Console.ReadLine();

      if (string.IsNullOrWhiteSpace(to)) {
        ShowErrorMessage("Recipient address cannot be empty");
        return;
      }

      Console.Write("Subject: ");
      string subject = Console.ReadLine();

      Console.Write("Body: ");
      string body = Console.ReadLine();

      if (client.SendEmail(to, subject, body)) {
        ShowSuccessMessage("Email sent successfully!");
      }
    }

    private static void ReceiveEmailsFlow(EmailClient client) {
      Console.Clear();
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine("\n=== RECEIVE EMAILS ===");
      Console.ResetColor();

      client.ReceiveNewEmails();

      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine("\nMailbox updated successfully");
      Console.ResetColor();
    }

    private static void MarkAsReadFlow(EmailClient client) {
      Console.Clear();
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine("\n=== MARK AS READ ===");
      Console.ResetColor();

      client.DisplayInbox();

      Console.Write("\nEnter email number: ");
      string input = Console.ReadLine();

      if (int.TryParse(input, out int number)) {
        client.MarkEmailAsRead(number);
        ShowSuccessMessage("Email marked as read");
      } else {
        ShowErrorMessage("Enter a valid email number");
      }
    }
  }
}