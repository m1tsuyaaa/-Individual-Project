using System;

namespace EmailLab.UI {
  public static class MenuRenderer {
    public static void DisplayMainMenu() {
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

    public static void ShowWelcomeMessage(string email) {
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine("\nWelcome, {0}!", email);
      Console.WriteLine("Email client successfully started");
      Console.ResetColor();
    }

    public static void ShowExitMessage() {
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine("\n=========================================");
      Console.WriteLine("              Goodbye!");
      Console.WriteLine("         Thanks for using");
      Console.WriteLine("=========================================");
      Console.ResetColor();
    }

    public static void ShowErrorMessage(string message) {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("\nError: {0}", message);
      Console.ResetColor();
    }

    public static void ShowSuccessMessage(string message) {
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine("\n{0}", message);
      Console.ResetColor();
    }

    public static void ShowSectionTitle(string title) {
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine("\n=== {0} ===", title);
      Console.ResetColor();
    }

    public static void ShowSeparator() {
      Console.ForegroundColor = ConsoleColor.DarkGray;
      Console.WriteLine("\n----------------------------------------");
      Console.ResetColor();
    }
  }
}