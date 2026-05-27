using System;

namespace EmailLab {
  public sealed class EmailClient {
    private static EmailClient _singleInstance;
    private static readonly object _threadLock = new object();

    private EmailClient() {
      Console.WriteLine("[Singleton] Instance created");
    }

    public static EmailClient GetInstance() {
      if (_singleInstance == null) {
        lock (_threadLock) {
          if (_singleInstance == null) {
            _singleInstance = new EmailClient();
          }
        }
      }
      return _singleInstance;
    }
  }
}