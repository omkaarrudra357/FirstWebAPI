using FirstWebapi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;



namespace WebApiClientConsole
{
    internal class EmployeeAPIClient
    {
        static Uri uri = new Uri("http://localhost:5039/");
        public static async Task CallGetAllEmployee()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                //HttpGet:
                HttpResponseMessage response = await client.GetAsync("ListAllEmployees");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    String x = await response.Content.ReadAsStringAsync();
                    await Console.Out.WriteLineAsync(x);
                }
            }
        }
        public static async Task CallGetAllEmployeeJson()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                List<EmpViewModel> employees = new List<EmpViewModel>();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //HttpGet:
                HttpResponseMessage response = await client.GetAsync("ListAllEmployees");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    String json = await response.Content.ReadAsStringAsync();
                    //install Newtonsoft.Json using PackageManager
                    employees = JsonConvert.DeserializeObject<List<EmpViewModel>>(json);
                    foreach (EmpViewModel emp in employees)
                    {
                        await Console.Out.WriteLineAsync($" {emp.EmpId}, {emp.FirstName}, {emp.LastName}, {emp.BirthDate}, {emp.HireDate}, {emp.Title}, {emp.City}, {emp.ReportsTo}");
                    }
                }
            }
        }
    }
}