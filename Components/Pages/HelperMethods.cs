using Serilog;

namespace CustomerInformationSystem.Components.Pages
{
    public class HelperMethods
    {
        public static List<Customer> SearchCustomer(List<Customer> customers,string attributeName, string attributeValue)
        {
            Log.Information($"Find {attributeValue} of {attributeName}");
            var property = typeof(Customer).GetProperty(attributeName);
            if (property == null)
            {
                return customers;   
            }
            if(attributeValue == null)
            {
                attributeValue = string.Empty;
            }
            var matchedCustomers = customers.Where(c =>
            {
                var value = property.GetValue(c)?.ToString()??string.Empty;
                return value.Equals(attributeValue, StringComparison.OrdinalIgnoreCase);
            }).ToList();
            return matchedCustomers;
        }
    }
}
