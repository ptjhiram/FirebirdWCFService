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
        bool InsertDmdata(string dataJson);

        [OperationContract]
        bool InsertInsuletPumpSettings(string dataJson);
    }
}
