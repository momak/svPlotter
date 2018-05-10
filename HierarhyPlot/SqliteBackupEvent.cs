using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HierarhyPlot
{
    public class SqliteBackupEvent
    {
        public int Pages { get; private set; }
        public int Remaining { get; private set; }
        public int PageCount { get; private set; }
        public bool Retry { get; private set; }

        public SqliteBackupEvent(int pages, int remaining, int pageCount, bool retry)
        {
            Pages = pages;
            Remaining = remaining;
            PageCount = pageCount;
            Retry = retry;
        }
    }
}
