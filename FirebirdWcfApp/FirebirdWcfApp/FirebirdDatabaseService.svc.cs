using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace FirebirdWcfApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FirebirdDatabaseService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select FirebirdDatabaseService.svc or FirebirdDatabaseService.svc.cs at the Solution Explorer and start debugging.
    public class FirebirdDatabaseService : IFirebirdDatabaseService
    {
        public string GetDownloadKeyId(int value)
        {
            return (value > 0) ? "0.0" : "11111.11111";
        }

        public bool UpdateDmdata(string dataJson)
        {
            return dataJson.Equals("yes");
        }

        public bool UpdateInsuletPumpSettings(string dataJson)
        {
            return dataJson.Equals("yes");
        }

        public bool InsertMeterReadingHeader(string dataJson)
        {
            return dataJson.Equals("yes");
        }

        public bool InsertMeterReadings(string dataJson)
        {
            return dataJson.Equals("yes");
        }

        public bool InsertPumpTimeSlots(string dataJson)
        {
            return dataJson.Equals("yes");
        }

        public bool InsertPatientPumpProgram(string dataJson)
        {
            return dataJson.Equals("yes");
        }
    }
}
