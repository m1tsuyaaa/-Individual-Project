using System;
using System.Collections.Generic;
using EmailLab.Models;

namespace EmailLab.Services {
  public class EmailStatistics {
    private readonly EmailStorage storage;

    public EmailStatistics(EmailStorage emailStorage) {
      storage = emailStorage;
    }

    public void DisplayInbox() {
      List<Email> inbox = storage.GetInbox();

      if (inbox.Count == 0) {
        Console.WriteLine("Inbox is empty");
        return;
      }

      Console.WriteLine("\n=== INBOX ({0}) ===", inbox.Count);

      for (int position = 0; position < inbox.Count; ++position) {
        Email current = inbox[position];

        string status;
        if (current.IsRead) {
          status = "[READ]";
        } else {
          status = "[NEW]";
        }

        Console.WriteLine("\n{0} Email #{1}", status, position + 1);
        Console.WriteLine(current.ToString());
      }
    }

    public void DisplaySentEmails() {
      List<Email> sentEmails = storage.GetSentEmails();

      if (sentEmails.Count == 0) {
        Console.WriteLine("No sent emails");
        return;
      }

      Console.WriteLine("\n=== SENT ({0}) ===", sentEmails.Count);

      for (int position = 0; position < sentEmails.Count; ++position) {
        Console.WriteLine("\nEmail #{0}", position + 1);
        Console.WriteLine(sentEmails[position].ToString());
      }
    }

    public void DisplayStatistics() {
      List<Email> inbox = storage.GetInbox();
      List<Email> sentEmails = storage.GetSentEmails();

      int unreadCount = 0;

      for (int position = 0; position < inbox.Count; ++position) {
        if (!inbox[position].IsRead) {
          ++unreadCount;
        }
      }

      int total = inbox.Count + sentEmails.Count;

      Console.WriteLine("\n=== STATISTICS ===");
      Console.WriteLine("Total emails: {0}", total);
      Console.WriteLine("Inbox: {0} (Unread: {1})", inbox.Count, unreadCount);
      Console.WriteLine("Sent: {0}", sentEmails.Count);
    }
  }
}