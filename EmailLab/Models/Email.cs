using System;

namespace EmailLab.Models {
  public class Email {
    public string Sender { get; set; }
    public string Recipient { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public DateTime Timestamp { get; set; }
    public bool IsRead { get; set; }

    public Email(string sender, string recipient, string subject, string body) {
      Sender = sender;
      Recipient = recipient;
      Subject = subject;
      Body = body;
      Timestamp = DateTime.Now;
      IsRead = false;
    }

    public override string ToString() {
      return string.Format(
          "From: {0}\nTo: {1}\nSubject: {2}\nDate: {3:yyyy-MM-dd HH:mm}\n{4}\n{5}",
          Sender,
          Recipient,
          Subject,
          Timestamp,
          Body,
          new string('-', 50));
    }
  }
}