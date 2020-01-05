using System;
using Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface IBaseDAL
    {
        T Find<T>(int Id) where T : BaseModel;
        List<T> FindAll<T>() where T : BaseModel;
        bool Add<T>(T t) where T : BaseModel;
        bool Update<T>(T t) where T : BaseModel;
        bool Delete<T>(T t) where T : BaseModel;
    }
}
