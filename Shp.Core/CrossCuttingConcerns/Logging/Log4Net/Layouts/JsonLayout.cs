using System;
using System.IO;
using log4net.Core;
using log4net.Layout;
using Newtonsoft.Json;

//log4net.config implementation
namespace Shp.Core.CrossCuttingConcerns.Logging.Log4Net.Layouts
{
    public class JsonLayout : LayoutSkeleton
    {
        public override void ActivateOptions()
        {
        }

        public override void Format(TextWriter writer, LoggingEvent loggingEvent)
        {
            var json = String.Empty;
            var logEvent = new SerializableLogEvent(loggingEvent);
            if (loggingEvent.LoggerName.Equals("JsonFileLogger"))
                json = JsonConvert.SerializeObject(logEvent, Formatting.Indented);
            else if (loggingEvent.LoggerName.Equals("DatabaseLogger"))
                json = JsonConvert.SerializeObject(logEvent);
            writer.WriteLine(json);
        }
    }
}
