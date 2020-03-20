namespace EFCoreIssues
{
    public class A
    {
        public int Id { get; set; }

        public ASubClass Sub { get; set; }
    }

    public class ASubClass
    {
        public string AValue { get; set; }
    }
}
