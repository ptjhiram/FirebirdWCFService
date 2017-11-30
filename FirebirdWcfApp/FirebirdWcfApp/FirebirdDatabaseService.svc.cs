using FirebirdWcfApp.ServiceLogging;
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
using TraceLogger;

namespace FirebirdWcfApp
{
    public class FirebirdDatabaseService : IFirebirdDatabaseService
    {
        int SiteId;
        MeterQueries mq;

        public string GetDownloadKeyId(int siteId)
        {
            ServiceLog sl = new ServiceLog();
            try
            {
                SiteId = siteId;

                //var fbConn = new FirebirdDbConnection(SiteId);
                //return fbConn.GetNextDownloadKeyId();

                throw new Exception("Testing");
            }
            catch (Exception ex)
            {
                //log....
                sl.Log(Guid.Empty, "GetDownloadKeyId", "FirebirdDatabaseService", ex.StackTrace, $"SiteId: {SiteId} - Exception: {ex.Message}", String.Empty, ServiceLog.TraceEventType.Error);

                return String.Empty;
            }
        }

        public bool UpdateDmdata(int siteId, string dataJson)
        {
            ServiceLog sl = new ServiceLog();
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
                sl.Log(Guid.Empty, "UpdateDmdata", "FirebirdDatabaseService", ex.StackTrace, $"SiteId: {SiteId} - Exception: {ex.Message}", dataJson, ServiceLog.TraceEventType.Error);

                return false;
            }
        }

        public bool UpdateInsuletPumpSettings(int siteId, string dataJson)
        {
            ServiceLog sl = new ServiceLog();
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
                sl.Log(Guid.Empty, "UpdateInsuletPumpSettings", "FirebirdDatabaseService", ex.StackTrace, $"SiteId: {SiteId} - Exception: {ex.Message}", dataJson, ServiceLog.TraceEventType.Error);

                return false;
            }
        }

        public bool InsertMeterReadingHeader(int siteId, string dataJson)
        {
            ServiceLog sl = new ServiceLog();
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
                sl.Log(Guid.Empty, "InsertMeterReadingHeader", "FirebirdDatabaseService", ex.StackTrace, $"SiteId: {SiteId} - Exception: {ex.Message}", dataJson, ServiceLog.TraceEventType.Error);

                return false;
            }
        }

        public bool InsertMeterReadings(int siteId, string dataJson)
        {
            ServiceLog sl = new ServiceLog();
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
                sl.Log(Guid.Empty, "InsertMeterReadings", "FirebirdDatabaseService", ex.StackTrace, $"SiteId: {SiteId} - Exception: {ex.Message}", dataJson, ServiceLog.TraceEventType.Error);

                return false;
            }
        }

        public bool InsertPumpTimeSlots(int siteId, string dataJson)
        {
            ServiceLog sl = new ServiceLog();
            try
            {
                SiteId = siteId;
                mq = new MeterQueries(siteId);

                List<PUMPTIMESLOTSEntity> data = JsonConvert.DeserializeObject<List<PUMPTIMESLOTSEntity>>(dataJson);

                if (data == null)
                {
                    return false;
                }

                foreach (var slot in data)
                {
                    mq.AddPumpTimeSlot(slot.PATIENTID, slot);
                }

                return true;
            }
            catch (Exception ex)
            {
                //log...
                sl.Log(Guid.Empty, "InsertPumpTimeSlots", "FirebirdDatabaseService", ex.StackTrace, $"SiteId: {SiteId} - Exception: {ex.Message}", dataJson, ServiceLog.TraceEventType.Error);

                return false;
            }
        }

        public bool InsertPatientPumpProgram(int siteId, string dataJson)
        {
            ServiceLog sl = new ServiceLog();
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
                sl.Log(Guid.Empty, "InsertPatientPumpProgram", "FirebirdDatabaseService", ex.StackTrace, $"SiteId: {SiteId} - Exception: {ex.Message}", dataJson, ServiceLog.TraceEventType.Error);

                return false;
            }
        }
    }
}
