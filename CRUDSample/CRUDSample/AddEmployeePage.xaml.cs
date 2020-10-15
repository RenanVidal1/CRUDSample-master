using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUDSample
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddEmployeePage : ContentPage
	{
        Employee employeeDetails;
		public AddEmployeePage (Employee details)
		{
			InitializeComponent ();
            if(details!=null)
            {
                employeeDetails = details;
                PopulateDetails(employeeDetails);
            }
		}

        private void PopulateDetails(Employee details)
        {
            name.Text = details.Name;
            address.Text = details.Address;
            phoneNumber.Text = details.PhoneNumber;
            email.Text = details.Email;

            saveBtn.Text = "Editar";
            this.Title = "Editar Mercadoria";
        }

        private void SaveEmployee(object sender, EventArgs e)
        {
            if(saveBtn.Text=="Salvar")
            {
                Employee employee = new Employee();
                employee.Name = name.Text;
                employee.Address = address.Text;
                employee.PhoneNumber = phoneNumber.Text;
                employee.Email = email.Text;

                bool res = DependencyService.Get<ISQLite>().SaveEmployee(employee);
                if (res)
                {
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Message", "Falha ao salvar", "Ok");
                }
            }
            else
            {
                // update employee
                employeeDetails.Name = name.Text;
                employeeDetails.Address = address.Text;
                employeeDetails.PhoneNumber = phoneNumber.Text;
                employeeDetails.Email = email.Text;

                bool res =DependencyService.Get<ISQLite>().UpdateEmployee(employeeDetails);
                if (res)
                {
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Message", "Falha no editar", "Ok");
                }
            }
        }
    }
}