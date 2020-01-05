using System;

namespace Model
{
    public class Company : BaseModel
    {
        public string Name{get;set;}
        public DateTime CreateTime{get;set;}
        public int CreatorId{get;set;}
        public int? LastUpdatedById{get;set;}
        public DateTime? LastUpdatedTime{get;set;}
        
    }
}