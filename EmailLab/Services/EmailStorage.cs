using System;
using System.Collections.Generic;
using EmailLab.Models;

namespace EmailLab.Services {
  public class EmailStorage {
    private readonly List<Email> inbox;
    private readonly List<Email> sentEmails;

    public EmailStorage() {
      inbox = new List<Email>();
      sentEmails = new List<Email>();
    }

    public void AddToInbox(Email email) {
      inbox.Add(email);
    }

    public void AddToSent(Email email) {
      sentEmails.Add(email);
    }

    public List<Email> GetInbox() {
      return inbox;
    }

    public List<Email> GetSentEmails() {
      return sentEmails;
    }

    public void MarkEmailAsRead(int emailNumber) {
      if (emailNumber >= 1 && emailNumber <= inbox.Count) {
        inbox[emailNumber - 1].IsRead = true;
        Console.WriteLine("Email #{0} marked as read", emailNumber);
      } else {
        Console.WriteLine("Invalid email number");
      }
    }

    public void AddTestEmails() {
      Email email1 = new Email("noreply@example.com", "user@example.com", "Welcome", "Thank you");
      Email email2 = new Email("alerts@bank.com", "user@example.com", "Statement", "Balance: 5000 rub");
      Email email3 = new Email("friend@mail.com", "user@example.com", "Meeting", "At 6 PM");

      inbox.Add(email1);
      inbox.Add(email2);
      inbox.Add(email3);

      Console.WriteLine("[Test] 3 test emails added");
    }
  }
}