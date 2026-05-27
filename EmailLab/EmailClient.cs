using System;
using System.Collections.Generic;

namespace EmailLab {
  public sealed class EmailClient {
    private static EmailClient singleInstance;
    private static readonly object threadLock = new object();
    private readonly List<Email> inbox;
    private readonly List<Email> sentEmails;
    private string userEmail;

    private EmailClient() {
      inbox = new List<Email>();
      sentEmails = new List<Email>();
      userEmail = string.Empty;
      Console.WriteLine("[Singleton] Instance created");
      AddTestEmails();
    }

    public static EmailClient GetInstance() {
      if (singleInstance == null) {
        lock (threadLock) {
          if (singleInstance == null) {
            singleInstance = new EmailClient();
          }
        }
      }
      return singleInstance;
    }

    public void SetUserEmail(string email) {
      userEmail = email;
      Console.WriteLine("User email: {0}", userEmail);
    }

    public bool SendEmail(string recipient, string subject, string body) {
      if (string.IsNullOrEmpty(userEmail)) {
        Console.WriteLine("Error: Set user email first");
        return false;
      }

      Email newEmail = new Email(userEmail, recipient, subject, body);
      sentEmails.Add(newEmail);
      Console.WriteLine("Sent to: {0}", recipient);
      return true;
    }

    private void AddTestEmails() {
      Email email1 = new Email("noreply@example.com", "user@example.com", "Welcome", "Thank you");
      Email email2 = new Email("alerts@bank.com", "user@example.com", "Statement", "Balance: 5000 rub");
      Email email3 = new Email("friend@mail.com", "user@example.com", "Meeting", "At 6 PM");

      inbox.Add(email1);
      inbox.Add(email2);
      inbox.Add(email3);

      Console.WriteLine("[Test] 3 test emails added");
    }

    public int ReceiveNewEmails() {
      Random randomGenerator = new Random();
      int newCount = randomGenerator.Next(1, 4);

      for (int index = 0; index < newCount; ++index) {
        string sender = string.Format("sender{0}@example.com", index + 1);

        string recipient;
        if (string.IsNullOrEmpty(userEmail)) {
          recipient = "user@example.com";
        } else {
          recipient = userEmail;
        }

        string subject = string.Format("New message #{0}", index + 1);
        string body = string.Format("Auto-generated at {0:HH:mm:ss}", DateTime.Now);

        Email newEmail = new Email(sender, recipient, subject, body);
        inbox.Add(newEmail);
      }

      Console.WriteLine("[RECEIVED] {0} new emails", newCount);
      return newCount;
    }
  }
}