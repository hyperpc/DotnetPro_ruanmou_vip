using System;

namespace Model
{
    public class User : BaseModel
    {
        public string Name{get;set;}
        public string Account{get;set;}
        public string Password{get;set;}
        public string Email{get;set;}
        public string MobileNo{get;set;}
        public int CompanyId{get;set;}
        public string CompanyName{get;set;}
        // 0 : normal
        // 1 : suspend
        // 2 : deleted
        public int Status{get;set;}
        // 1 : normal user
        // 2 : administrator
        // 3 : system administrator
        public int UserType{get;set;}
        public DateTime? LastLoginTime{get;set;}
        public DateTime? CreateTime{get;set;}
        public int CreatorId{get;set;}
        public int? LastUpdatedById{get;set;}
        public DateTime? LastUpdatedTime{get;set;}
        
    }
}