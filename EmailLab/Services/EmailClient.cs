using System;

namespace EmailLab.Services {
  public sealed class EmailClient {
    private static EmailClient singleInstance;
    private static readonly object threadLock = new object();

    private readonly EmailStorage storage;
    private readonly EmailSender sender;
    private readonly EmailReceiver receiver;
    private readonly EmailStatistics statistics;

    private EmailClient() {
      storage = new EmailStorage();
      sender = new EmailSender(storage);
      receiver = new EmailReceiver(storage, () => sender.GetUserEmail());
      statistics = new EmailStatistics(storage);

      Console.WriteLine("[Singleton] Instance created");
      storage.AddTestEmails();
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
      sender.SetUserEmail(email);
    }

    public bool SendEmail(string recipient, string subject, string body) {
      return sender.SendEmail(recipient, subject, body);
    }

    public void ReceiveNewEmails() {
      receiver.ReceiveNewEmails();
    }

    public void DisplayInbox() {
      statistics.DisplayInbox();
    }

    public void DisplaySentEmails() {
      statistics.DisplaySentEmails();
    }

    public void MarkEmailAsRead(int emailNumber) {
      storage.MarkEmailAsRead(emailNumber);
    }

    public void DisplayStatistics() {
      statistics.DisplayStatistics();
    }
  }
}