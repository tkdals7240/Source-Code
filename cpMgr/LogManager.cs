using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using log4net.Repository;
using log4net.Repository.Hierarchy;
using System;
using System.IO;
using System.Reflection;

[assembly: FmsTec.Util.LogConfigurator]

namespace FmsTec.Util
{
    [AttributeUsage(AttributeTargets.Assembly)]
    public class LogConfigurator : ConfiguratorAttribute
    {
        public LogConfigurator()
            : base(0)
        {
        }

        public override void Configure(Assembly sourceAssembly, ILoggerRepository targetRepository)
        {
            if (!Directory.Exists("Log"))
                Directory.CreateDirectory("Log");

            // Log4net Config
            var hierarchy = (Hierarchy)targetRepository;
            var patternLayout = new PatternLayout();
            patternLayout.ConversionPattern = "%d{yyyy-MM-dd HH:mm:ss.fff} %-5p %-8c %m%n";
            patternLayout.ActivateOptions();

            var roller = new RollingFileAppender();
            roller.File = @"Log\Main.Log";
            roller.AppendToFile = true;
            roller.PreserveLogFileNameExtension = true;
            roller.DatePattern = "_yyyyMMdd";
            roller.Layout = patternLayout;
            roller.MaxSizeRollBackups = 5;
            roller.MaximumFileSize = "100MB";
            roller.RollingStyle = RollingFileAppender.RollingMode.Date;
            roller.StaticLogFileName = false;
            roller.ActivateOptions();
            hierarchy.Root.AddAppender(roller);

            hierarchy.Root.Level = Level.Info;
            hierarchy.Configured = true;
        }
    }
}
