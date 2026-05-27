using System;
using EmailLab.Models;

namespace EmailLab.Services {
  public class EmailSender {
    private readonly EmailStorage storage;
    private string userEmail;

    public EmailSender(EmailStorage emailStorage) {
      storage = emailStorage;
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
      storage.AddToSent(newEmail);
      Console.WriteLine("Sent to: {0}", recipient);
      return true;
    }

    public string GetUserEmail() {
      return userEmail;
    }
  }
}