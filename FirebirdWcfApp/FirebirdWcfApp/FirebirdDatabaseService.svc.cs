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
    public class FirebirdDatabaseService : IFirebirdDatabaseService
    {
        int SiteId;
        MeterQueries mq;

        public string GetDownloadKeyId(int siteId)
        {
            try
            {
                SiteId = siteId;
                //mq = new MeterQueries(siteId);

                var fbConn = new FirebirdDbConnection(SiteId);
                return fbConn.GetNextDownloadKeyId();
            }
            catch (Exception ex)
            {
                //log....
                return String.Empty;
            }
        }

        public bool UpdateDmdata(int siteId, string dataJson)
        {
            try
            {
                SiteId = siteId;
                mq = new MeterQueries(siteId);

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

        public bool UpdateInsuletPumpSettings(int siteId, string dataJson)
        {
            try
            {
                SiteId = siteId;
                mq = new MeterQueries(siteId);

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

        public bool InsertMeterReadingHeader(int siteId, string dataJson)
        {
            try
            {
                SiteId = siteId;
                mq = new MeterQueries(siteId);

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

        public bool InsertMeterReadings(int siteId, string dataJson)
        {
            try
            {
                SiteId = siteId;
                mq = new MeterQueries(siteId);

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

        public bool InsertPumpTimeSlots(int siteId, string dataJson)
        {
            try
            {
                SiteId = siteId;
                mq = new MeterQueries(siteId);

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

        public bool InsertPatientPumpProgram(int siteId, string dataJson)
        {
            try
            {
                SiteId = siteId;
                mq = new MeterQueries(siteId);

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
