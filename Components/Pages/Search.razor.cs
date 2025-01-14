using Microsoft.AspNetCore.Components;
using Serilog;
using CustomerInformationSystem;
namespace CustomerInformationSystem.Components.Pages
{
    public partial class Search
    {
        List<Customer> customers = CustomerCsvService.GetCustomerData();
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
                DistinctValues = customers.getDistinctValues(SelectedSearchAttribute);
        }
        private void OnValueSelected(ChangeEventArgs e)
        {
            SelectedAttributevalue = e.Value?.ToString() ?? DistinctValues[0]!;
            customers.SearchCustomer(SelectedSearchAttribute, SelectedAttributevalue);

        }
        private void ReloadData()
        {
            customers = CustomerCsvService.GetCustomerData();

        }
        
        
    }
}
