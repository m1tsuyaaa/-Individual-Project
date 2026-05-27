using System;
using EmailLab.Models;

namespace EmailLab.Services {
  public class EmailReceiver {
    private readonly EmailStorage storage;
    private readonly Func<string> getUserEmail;

    public EmailReceiver(EmailStorage emailStorage, Func<string> getUserEmailFunction) {
      storage = emailStorage;
      getUserEmail = getUserEmailFunction;
    }

    public void ReceiveNewEmails() {
      Random randomGenerator = new Random();
      int newCount = randomGenerator.Next(1, 4);

      for (int index = 0; index < newCount; ++index) {
        string sender = string.Format("sender{0}@example.com", index + 1);

        string recipient;
        string userEmail = getUserEmail();

        if (string.IsNullOrEmpty(userEmail)) {
          recipient = "user@example.com";
        } else {
          recipient = userEmail;
        }

        string subject = string.Format("New message #{0}", index + 1);
        string body = string.Format("Auto-generated at {0:HH:mm:ss}", DateTime.Now);

        Email newEmail = new Email(sender, recipient, subject, body);
        storage.AddToInbox(newEmail);
      }

      Console.WriteLine("[RECEIVED] {0} new emails", newCount);
    }
  }
}