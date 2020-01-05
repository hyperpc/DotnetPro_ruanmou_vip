using System;
using System.Reflection;
using System.Configuration;
using IDAL;
using Framework;

namespace Factory
{
    public class SimpleFactory
    {
        private static string DllName = StaticConstraint.IBaseDALConfig.Split(',')[1];
        private static string TypeName = StaticConstraint.IBaseDALConfig.Split(',')[0];
        public static IBaseDAL CreateInstance()
        {
            Assembly assembly = Assembly.Load(DllName);
            Type type = assembly.GetType(TypeName);
            return (IBaseDAL)Activator.CreateInstance(type);
        }
    }
}
