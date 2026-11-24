namespace SpCrud.EmpServiceLayer
{
    public interface IEmpSl
    {
        int SaveEmployee(Models.Employee employee);
        int DeleteEmployee(int empId);
        int UpdateEmployee(Models.Employee employee);
        Models.Employee GetEmployee(int empId);
        List<Models.Employee> GetEmps();
    }
}
