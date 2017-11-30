using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using TraceLogger.EF;

namespace FirebirdWcfApp.ServiceLogging
{
    public class ServiceLog
    {
        Log log;

        public void Log(Guid userId, string method, string serviceName, string callStack, string message, string data, TraceEventType traceEventType)
        {
            log = new Log
            {
                UserId = userId,
                Action = method,
                Controller = serviceName,
                CallStack = callStack,
                ApplicationId = ConfigurationManager.AppSettings["SqlApplicationId"],
                DateTime = DateTime.Now,
                Source = "Firebird WCF Service",
                Timestamp = DateTime.Now.Ticks,
                Message = message,
                Data = data,
                TraceEventType = traceEventType.ToString()
            };

            Commit();
        }

        private void Commit()
        {
            using (var ctx = new TraceLogEntities())
            {
                ctx.Logs.Add(log);
                ctx.SaveChanges();
            }
        }

        public enum TraceEventType
        {
            Informational,
            Warning,
            Error,
            Critical
        }
    }
}