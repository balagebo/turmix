using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurmixLog
{
    public class WorkerThread
    {

        private CimOsszesito newCim = new CimOsszesito();
        private List<WorkData> newData = new List<WorkData>();

        public static void DoUpdate(KiosztasDao dao, CimOsszesito oldCim, List<WorkData> oldData)
        {

        }

    }
}
