using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CMISEngine.CMIS.Configuration
{
    public class CMISConnection
    {
        public static readonly ILog Log = LogManager.GetLogger(typeof(CMISConnection));
        public static string BaseUrl { get; set; }
        public static string User { get; set; }
        public static string Password { get; set; }
        public static string DocumentRepository { get; set; }
        public static string FolderRepository { get; set; }
        public static string ExternalApplicationProperty { get; set; }
        public static string SiteName { get; set; }
        public static string PublishInEvolveProperty { get; set; }
        public static string CustomAspect { get; set; }
        public static CMISConnectionSection _Config = ConfigurationManager.GetSection("CMISConnection") as CMISConnectionSection;

        public static void GetParameters()
        {
            try
            {
                Log.Debug("Get connection parameters...");
                Dictionary<string, string> parameterDictionary = new Dictionary<string, string>();
                foreach (ParameterElement parameterElement in _Config.Parameters)
                {
                    if (!parameterDictionary.ContainsKey(parameterElement.Name))
                    {
                        Log.Debug("Get parameter <" + parameterElement.Name + ">");
                        parameterDictionary[parameterElement.Name] = parameterElement.Value;
                    }
                }
                Log.Debug("Retrieve <BaseUrl>...");
                BaseUrl = parameterDictionary["BaseUrl"];
                Log.Debug("Parameter <BaseUrl> = " + BaseUrl);
                Log.Debug("Retrieve <User>");
                User = parameterDictionary["User"];
                Log.Debug("Parameter <User> = " + User);
                Log.Debug("Retrieve <Password>...");
                Password = parameterDictionary["Password"];
                Log.Debug("Parameter <Password> = " + Password);
                Log.Debug("Retrieve <DocumentRepository>...");
                DocumentRepository = parameterDictionary["DocumentRepository"];
                Log.Debug("Parameter <DocumentRepository> = " + DocumentRepository);
                Log.Debug("Retrieve <FolderRepository>...");
                FolderRepository = parameterDictionary["FolderRepository"];
                Log.Debug("Parameter <FolderRepository> = " + FolderRepository);
                Log.Debug("Retrieve <CustomAspect>...");
                CustomAspect = parameterDictionary["CustomAspect"];
                Log.Debug("Parameter <CustomAspect> = " + CustomAspect);
                Log.Debug("Retrieve <ExternalApplicationProperty>...");
                ExternalApplicationProperty = parameterDictionary["ExternalApplicationProperty"];//parameter used in an older version, think to remove it later on
                Log.Debug("Parameter <ExternalApplicationProperty> = " + ExternalApplicationProperty);
                Log.Debug("Retrieve <PublishInEvolveProperty>...");
                PublishInEvolveProperty = parameterDictionary["PublishInEvolveProperty"];
                Log.Debug("Parameter <PublishInEvolveProperty> = " + PublishInEvolveProperty);
                Log.Debug("Retrieve <SiteName>...");
                SiteName = parameterDictionary["SiteName"];
                Log.Debug("Parameter <SiteName> = " + SiteName);
                Log.Debug("All parameters retrieved !");
            }
            catch
            {
                throw new Exception("Merci de vérifier les parametres de CMIS connection dans Web.Config");
            }
        }
    }
}