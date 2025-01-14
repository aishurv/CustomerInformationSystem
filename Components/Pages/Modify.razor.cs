using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Serilog;

namespace CustomerInformationSystem.Components.Pages
{
    public partial class Modify
    {
        List<Customer> customers = CustomerCsvService.GetCustomerData();
        [Inject]
        public NavigationManager? NavigationManager { get; set; }
        private string value=string.Empty;
        public void EditCustomer(string id)
        {
            NavigationManager?.NavigateTo($"/modify/{id}");
            JSRuntime.InvokeVoidAsync("showAlert", $"Edit Customer having ID {id}");
        }
        private async Task DeleteCustomer(string id)
        {
            // Await the result of the confirmation dialog
            var customer = customers.FirstOrDefault(c => c.ID == id);
            var confirm = await JSRuntime.InvokeAsync<bool>("confirm", $"Are you sure you want to delete {customer?.Name} customer?");
            if (confirm)
            {
                if (customer != null)
                {
                    customers.Remove(customer);
                }
            }
        }
        private void UpdateCsvFile()
        {
            if (CustomerCsvService.UpdateCsv())
            {
                JSRuntime.InvokeVoidAsync("showAlert", "File updated Successfully !");
            }
            else
            {
                JSRuntime.InvokeVoidAsync("showAlert", "Error ! Check log for more details !");
            }
        }
        List<String> SearchAttribute = [
                "ID",
                "Name",
                "City",
                "Country",
                "Company",
                "Phone",
                "Email"
            ];
        
        string SelectedSearchAttribute = string.Empty;
        private void OnSearchAttributeSelected(ChangeEventArgs e)
        {
            SelectedSearchAttribute = e.Value?.ToString() ?? SearchAttribute[0]!;

        }
        private void ReloadData()
        {
            customers = CustomerCsvService.GetCustomerData();

        }
        private void SearchValue()
        {
            customers.SearchCustomer(SelectedSearchAttribute, value);
        }


    }
}
