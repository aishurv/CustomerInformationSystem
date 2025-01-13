using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace CustomerInformationSystem.Components.Pages
{
    public partial class Sort
    {
        List<Customer> customers = CustomerCsvHandler.GetCustomerData();
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
            customers = SortCustomers(SelectedSortAttribute, IsDesc);
        }
        private void ReloadData()
        {
            customers = CustomerCsvHandler.GetCustomerData();
            JSRuntime.InvokeVoidAsync("showAlert", "Data Loaded Successfully !");
        }
        List<Customer> SortCustomers(string attributeName, bool IsDesc)
        {
            var property = typeof(Customer).GetProperty(attributeName);
            if (property == null)
                return customers;
            if (IsDesc)
                return customers.OrderByDescending(c => property.GetValue(c, null)).ToList();
            return customers.OrderBy(c => property.GetValue(c, null)).ToList();
        }
        private void UpdateCsvFile()
        {
            if(CustomerCsvHandler.UpdateCsv(customers))
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
