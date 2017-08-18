using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KategóriaDetektor
{
    public class InsertInfo
    {
        int totalCount;

        public int TotalCount
        {
            get { return totalCount; }
            set { totalCount = value; }
        }
        int insertCount;

        public int InsertCount
        {
            get { return insertCount; }
            set { insertCount = value; }
        }
        int updateCount;

        public int UpdateCount
        {
            get { return updateCount; }
            set { updateCount = value; }
        }
    }
}
