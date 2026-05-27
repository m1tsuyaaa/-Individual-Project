using System;

namespace EmailLab {
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
      return $"[Email] From: {Sender}, Subject: {Subject}";
    }
  }
}