using System;
namespace ReflectionDemo.Models
{
    public class User:BaseModel
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
        public int UserType{get;set;}
        public DateTime? LastLoginTime{get;set;}
        public DateTime? CreateTime{get;set;}
        public int CreatorId{get;set;}
        public int? LastUpdatedById{get;set;}
        public DateTime? LastUpdatedTime{get;set;}
    }
}