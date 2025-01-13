namespace CustomerInformationSystem
{
    public class Customer
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }

        public string? Company { get; set; }

        public string? Phone { get; set; }
        public string? Email { get; set; }
        public Customer()
        {
            ID = string.Empty;
            Name =string.Empty;
        }
        public Customer (string id,String name)
        {
            ID = id;
            Name = name;
        }

    }
}
