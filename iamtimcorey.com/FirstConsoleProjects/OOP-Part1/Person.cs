namespace OOP_Part1
{
    public class Person
    {
        public string StreetAdress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string FullAddress
        {
            get
            {
                return $"{StreetAdress}, {City} ({ZipCode}), {State}";
            }
        }
    }
}
