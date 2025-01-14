using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using CustomerInformationSystem;
namespace CustomerInformationSystem.Components.Pages
{
    public partial class Sort
    {
        List<Customer> customers = CustomerCsvService.GetCustomerData();
        string SelectedSortAttribute = string.Empty;
        List<String> ValidSort = [
                "ID",
                "Name",
                "City",
                "Country",
                "Company",
                "Phone",
                "Email"
            ];
        private bool IsDesc = false;

        private void OnSortAttributeSelected(ChangeEventArgs e)
        {
            SelectedSortAttribute = e.Value?.ToString() ?? ValidSort[0]!;
            customers.SortCustomers(SelectedSortAttribute, IsDesc);
        }
        private void ReloadData()
        {
            customers = CustomerCsvService.GetCustomerData();
            JSRuntime.InvokeVoidAsync("showAlert", "Data Loaded Successfully !");
        }
        
        private void UpdateCsvFile()
        {
            if(CustomerCsvService.UpdateCsv(customers))
            {
                JSRuntime.InvokeVoidAsync("showAlert", "File updated Successfully !");
            }
            else
            {
                JSRuntime.InvokeVoidAsync("showAlert", "File Not Updated !");
            }
        }
    }
}
