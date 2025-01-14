using Serilog;

namespace CustomerInformationSystem
{
    public static class CustomerListExtension
    {
        public static void SearchCustomer(this List<Customer> customers, string attributeName, string attributeValue)
        {
            Log.Information($"Find {attributeValue} of {attributeName}");
            var property = typeof(Customer).GetProperty(attributeName);
            
            if (attributeValue == null)
            {
                attributeValue = string.Empty;
            }
            if (property != null)
            {
                var matchedCustomers = customers.Where(c =>
                {
                    var value = property.GetValue(c)?.ToString() ?? string.Empty;
                    return value.Equals(attributeValue, StringComparison.OrdinalIgnoreCase);
                }).ToList();
                customers = matchedCustomers;
            }
        }
        public static void SortCustomers(this List<Customer> customers,string attributeName, bool IsDesc)
        {
            var property = typeof(Customer).GetProperty(attributeName);
            if (property != null)
            {
                if (IsDesc)
                    customers.OrderByDescending(c => property.GetValue(c, null)).ToList();
                customers.OrderBy(c => property.GetValue(c, null)).ToList();
            }
        }
        public static List<string> getDistinctValues(this List<Customer> customers, string attributeName)
        {
            var property = typeof(Customer).GetProperty(attributeName);
            if (property == null)
                return new List<string>();

            return customers
                .Select(item => property.GetValue(item, null)?.ToString())
                .Distinct()
                .ToList()!;
        }
    }
}
