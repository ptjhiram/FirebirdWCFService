using NET.FirebirdDatabase.DatabaseConnections;
using NET.FirebirdDatabase.EF.AspnetDatabase;
using NET.FirebirdDatabase.Models.FirebirdTableEntities.Generated;
using NET.FirebirdDatabase.QueryManager;
using Newtonsoft.Json;
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
        readonly int SiteId;
        MeterQueries mq;

        public FirebirdDatabaseService(int siteId)
        {
            SiteId = siteId;
            mq = new MeterQueries(siteId);
        }

        private FirebirdDatabaseService()
        {

        }

        public string GetDownloadKeyId()
        {
            try
            {
                var fbConn = new FirebirdDbConnection(SiteId);

                return fbConn.GetNextDownloadKeyId();
            }
            catch (Exception)
            {
                //log....
                return String.Empty;
            }
        }

        public bool UpdateDmdata(string dataJson)
        {
            try
            {
                DMDATAEntity data = JsonConvert.DeserializeObject<DMDATAEntity>(dataJson);

                if (data == null)
                {
                    return false;
                }

                mq.UpdateDmDataValues(data.PATIENTID, data.LOWBGLEVEL, data.HIGHBGLEVEL, data.LASTMODIFIEDDATE);

                return true;
            }
            catch (Exception ex)
            {
                //log...
                return false;
            }
        }

        public bool UpdateInsuletPumpSettings(string dataJson)
        {
            try
            {
                INSULETPUMPSETTINGSEntity data = JsonConvert.DeserializeObject<INSULETPUMPSETTINGSEntity>(dataJson);

                if (data == null)
                {
                    return false;
                }

                mq.UpdateInsuletPumpSettings(data.PATIENTID, data);

                return true;
            }
            catch (Exception ex)
            {
                //log...
                return false;
            }
        }

        public bool InsertMeterReadingHeader(string dataJson)
        {
            try
            {
                METERREADINGHEADEREntity data = JsonConvert.DeserializeObject<METERREADINGHEADEREntity>(dataJson);

                if (data == null)
                {
                    return false;
                }

                mq.AddMeterReadingHeader(data);

                return true;
            }
            catch (Exception ex)
            {
                //log...
                return false;
            }
        }

        public bool InsertMeterReadings(string dataJson)
        {
            try
            {
                List<METERREADINGEntity> data = JsonConvert.DeserializeObject<List<METERREADINGEntity>>(dataJson);

                if (data == null)
                {
                    return false;
                }

                mq.BulkInsertMeterReading(data);

                return true;
            }
            catch (Exception ex)
            {
                //log...
                return false;
            }
        }

        public bool InsertPumpTimeSlots(string dataJson)
        {
            try
            {
                PUMPTIMESLOTSEntity data = JsonConvert.DeserializeObject<PUMPTIMESLOTSEntity>(dataJson);

                if (data == null)
                {
                    return false;
                }

                mq.AddPumpTimeSlot(data.PATIENTID, data);

                return true;
            }
            catch (Exception ex)
            {
                //log...
                return false;
            }
        }

        public bool InsertPatientPumpProgram(string dataJson)
        {
            try
            {
                PATIENTPUMPPROGRAMEntity data = JsonConvert.DeserializeObject<PATIENTPUMPPROGRAMEntity>(dataJson);

                if (data == null)
                {
                    return false;
                }

                mq.AddPatientPumpProgram(data);

                return true;
            }
            catch (Exception ex)
            {
                //log...
                return false;
            }
        }
    }
}
