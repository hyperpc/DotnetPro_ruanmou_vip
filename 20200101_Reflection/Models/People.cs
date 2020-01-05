namespace ReflectionDemo.Models
{
    public class People
    {
        public People()
        {
            System.Console.WriteLine("{0} was created", this.GetType().FullName);
        }
        public int Id{get;set;}
        public string Name{get;set;}
        public string Description;
    }
}