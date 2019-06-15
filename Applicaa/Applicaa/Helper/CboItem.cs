namespace Applicaa.Helper
{
    public class CboItem
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public CboItem(string name, string value)
        {
            Name = name;
            Value = value;
        }
       
    }
}