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
        string GetDownloadKeyId(int value);

        [OperationContract]
        bool InsertMeterReadingHeader(string dataJson);

        [OperationContract]
        bool InsertMeterReadings(string dataJson);

        [OperationContract]
        bool UpdateDmdata(string dataJson);

        [OperationContract]
        bool UpdateInsuletPumpSettings(string dataJson);

        [OperationContract]
        bool InsertPumpTimeSlots(string dataJson);

        [OperationContract]
        bool InsertPatientPumpProgram(string dataJson);
    }
}
