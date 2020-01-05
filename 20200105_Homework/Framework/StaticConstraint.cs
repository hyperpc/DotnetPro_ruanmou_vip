using System.Configuration;

namespace Framework
{
    /// <summary>
    /// initial config file, constants
    /// 
    /// manage config data in one place
    /// </summary>
    public class StaticConstraint
    {
        /// <summary>
        /// Factory generate DAL's configuration
        /// </summary>
        public readonly static string IBaseDALConfig = ConfigurationManager.AppSettings["IBaseDALConfig"];
        
    }
}