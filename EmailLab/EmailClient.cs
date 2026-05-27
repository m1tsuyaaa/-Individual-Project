using System;
using System.Collections.Generic;

namespace EmailLab {
  public sealed class EmailClient {
    private static EmailClient singleInstance;
    private static readonly object threadLock = new object();
    private List<Email> sentEmails;
    private string userEmail;

    private EmailClient() {
      sentEmails = new List<Email>();
      userEmail = string.Empty;
      Console.WriteLine("[Singleton] Instance created");
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
  }
}