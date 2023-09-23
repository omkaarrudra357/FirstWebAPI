using WebApiClientConsole;
Console.WriteLine("API Client!");
EmployeeAPIClient.CallGetAllEmployee().Wait();
Console.ReadLine();
