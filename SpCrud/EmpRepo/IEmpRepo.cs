namespace SpCrud.EmpRepo
{
    public interface IEmpRepo
    {
        int SaveEmployee(Models.Employee employee);
        int DeleteEmployee(int empId);
        int UpdateEmployee(Models.Employee employee);
        Models.Employee GetEmployee(int empId);
        List<Models.Employee> GetEmps();
    }
}
