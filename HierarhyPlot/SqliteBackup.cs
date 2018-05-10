using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HierarhyPlot
{
    public class SqliteBackup : IObservable<SqliteBackupEvent>
    {
        private readonly List<IObserver<SqliteBackupEvent>> _observers;

        public SqliteBackup()
        {
            _observers = new List<IObserver<SqliteBackupEvent>>();

        }


        public void Execute(string sourceConnectionString, string destinationConnectionString, int pagesToBackupInEachStep)
        {
            try
            {
                using (var srcConnection = new SQLiteConnection(sourceConnectionString))
                using (var destConnection = new SQLiteConnection(destinationConnectionString))
                {
                    srcConnection.Open();
                    destConnection.Open();

                    // Need to use the "main" names as specified at http://www.sqlite.org/c3ref/backup_finish.html#sqlite3backupinit
                    srcConnection.BackupDatabase(destConnection, "main", "main", pagesToBackupInEachStep, Callback, 10);

                    destConnection.Close();
                    srcConnection.Close();
                }
            }
            catch (Exception ex)
            {
                foreach (var observer in _observers)
                    observer.OnError(ex);
            }

            foreach (var observer in _observers)
                observer.OnCompleted();
        }

        protected virtual bool Callback(SQLiteConnection srcConnection, string srcName, SQLiteConnection destConnection, string destName,
                                        int pages, int remaining, int pageCount, bool retry)
        {
            var @event = new SqliteBackupEvent(pages, remaining, pageCount, retry);

            foreach (var observer in _observers)
                observer.OnNext(@event);

            return true;
        }

        public IDisposable Subscribe(IObserver<SqliteBackupEvent> observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);

            return new Unsubscriber(_observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private readonly List<IObserver<SqliteBackupEvent>> _observers;
            private readonly IObserver<SqliteBackupEvent> _observer;

            public Unsubscriber(List<IObserver<SqliteBackupEvent>> observers, IObserver<SqliteBackupEvent> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }
    }
}
