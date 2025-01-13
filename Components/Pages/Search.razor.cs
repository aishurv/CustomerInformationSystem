using Microsoft.AspNetCore.Components;
using Serilog;

namespace CustomerInformationSystem.Components.Pages
{
    public partial class Search
    {
        List<Customer> customers = CustomerCsvHandler.GetCustomerData();
        List<String> SearchAttribute = [
                "ID",
                "Name",
                "City",
                "Country",
                "Company",
                "Phone",
                "Email"
            ];
        List<String> DistinctValues = new(){
    "Select Attribute"
    };
        string SelectedSearchAttribute = string.Empty;
        string SelectedAttributevalue = string.Empty;
        private void OnSearchAttributeSelected(ChangeEventArgs e)
        {
            SelectedSearchAttribute = e.Value?.ToString() ?? SearchAttribute[0]!;

            if (SelectedSearchAttribute != null)
                DistinctValues = getDistinctValues( SelectedSearchAttribute);
        }
        private void OnValueSelected(ChangeEventArgs e)
        {
            SelectedAttributevalue = e.Value?.ToString() ?? DistinctValues[0]!;
            customers = HelperMethods.SearchCustomer(customers,SelectedSearchAttribute, SelectedAttributevalue);

        }
        private void ReloadData()
        {
            customers = CustomerCsvHandler.GetCustomerData();

        }
        
        List<string> getDistinctValues (string attributeName)
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
