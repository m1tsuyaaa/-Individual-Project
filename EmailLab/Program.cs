using System;

namespace EmailLab {
  class Program {
    private static void Main() {
      Console.Title = "Почтовый клиент - Singleton Pattern";
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine("=========================================");
      Console.WriteLine("   ПОЧТОВЫЙ КЛИЕНТ (Singleton Pattern)");
      Console.WriteLine("=========================================");
      Console.ResetColor();

      EmailClient mailClient = EmailClient.GetInstance();

      Console.Write("\nВведите ваш email: ");
      string userEmail = Console.ReadLine();
      mailClient.SetUserEmail(userEmail);

      bool shouldExitProgram = false;

      while (!shouldExitProgram) {
        DisplayMainMenu();
        string userChoice = Console.ReadLine();
        Console.WriteLine();

        if (userChoice == "1") {
          ProcessSendEmail(mailClient);
        } else if (userChoice == "2") {
          mailClient.ReceiveNewEmails();
        } else if (userChoice == "3") {
          mailClient.DisplayInbox();
        } else if (userChoice == "4") {
          mailClient.DisplaySentEmails();
        } else if (userChoice == "5") {
          ProcessMarkEmailAsRead(mailClient);
        } else if (userChoice == "6") {
          mailClient.DisplayStatistics();
        } else if (userChoice == "0") {
          shouldExitProgram = true;
          Console.ForegroundColor = ConsoleColor.Green;
          Console.WriteLine("До свидания!");
          Console.ResetColor();
        } else {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("Неверный выбор! Пожалуйста, попробуйте снова.");
          Console.ResetColor();
        }

        if (!shouldExitProgram) {
          Console.ForegroundColor = ConsoleColor.DarkGray;
          Console.WriteLine("\nНажмите любую клавишу для продолжения...");
          Console.ResetColor();
          _ = Console.ReadKey();
        }
      }
    }

    private static void DisplayMainMenu() {
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine("\n" + new string('-', 50));
      Console.WriteLine("МЕНЮ ПОЧТОВОГО КЛИЕНТА");
      Console.WriteLine(new string('-', 50));
      Console.ResetColor();
      Console.WriteLine("1. Отправить письмо");
      Console.WriteLine("2. Получить новые письма");
      Console.WriteLine("3. Просмотреть входящие");
      Console.WriteLine("4. Просмотреть отправленные");
      Console.WriteLine("5. Отметить письмо как прочитанное");
      Console.WriteLine("6. Показать статистику");
      Console.WriteLine("0. Выход");
      Console.Write("\nВыберите опцию: ");
    }

    private static void ProcessSendEmail(EmailClient mailClient) {
      Console.Write("Кому: ");
      string recipientAddress = Console.ReadLine();

      Console.Write("Тема: ");
      string emailSubject = Console.ReadLine();

      Console.Write("Содержание: ");
      string emailBody = Console.ReadLine();

      _ = mailClient.SendEmail(recipientAddress, emailSubject, emailBody);
    }

    private static void ProcessMarkEmailAsRead(EmailClient mailClient) {
      Console.Write("Введите номер письма для отметки как прочитанное: ");
      string userInput = Console.ReadLine();

      if (int.TryParse(userInput, out int emailNumber)) {
        mailClient.MarkEmailAsRead(emailNumber);
      } else {
        Console.WriteLine("Неверный номер! Пожалуйста, введите число.");
      }
    }
  }
}