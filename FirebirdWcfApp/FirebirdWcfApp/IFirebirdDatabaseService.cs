using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace FirebirdWcfApp
{
    [ServiceContract]
    public interface IFirebirdDatabaseService
    {
        [OperationContract]
        string GetDownloadKeyId(int siteId);

        [OperationContract]
        bool InsertMeterReadingHeader(int siteId, string dataJson);

        [OperationContract]
        bool InsertMeterReadings(int siteId, string dataJson);

        [OperationContract]
        bool UpdateDmdata(int siteId, string dataJson);

        [OperationContract]
        bool UpdateInsuletPumpSettings(int siteId, string dataJson);

        [OperationContract]
        bool InsertPumpTimeSlots(int siteId, string dataJson);

        [OperationContract]
        bool InsertPatientPumpProgram(int siteId, string dataJson);
    }
}
