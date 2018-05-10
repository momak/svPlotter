using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HierarhyPlot
{
    public class ConsoleWriterObserver : IObserver<SqliteBackupEvent>
    {
        public void OnNext(SqliteBackupEvent value)
        {
            Console.WriteLine("{0} - {1} - {2} - {3}", value.Pages, value.PageCount, value.Remaining, value.Retry);
        }

        public void OnError(Exception error)
        {
            Console.WriteLine(error.Message);
        }

        public void OnCompleted()
        {
            Console.WriteLine("Complete");
        }
    }
}
