﻿
namespace CustomerInformationSystem.Components.Pages
{
    public partial class CustomerInfo
    {
        List<Customer> customers = CustomerCsvService.GetCustomerData();
        
    }
}
