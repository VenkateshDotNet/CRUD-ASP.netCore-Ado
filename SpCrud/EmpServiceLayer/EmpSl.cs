using SpCrud.EmpRepo;
using SpCrud.Models;

namespace SpCrud.EmpServiceLayer
{
    public class EmpSl : IEmpSl
    {
        IEmpRepo _iemprepo;
        public EmpSl(IEmpRepo emprepo)
        {
            _iemprepo = emprepo;
        }
        int IEmpSl.DeleteEmployee(int empId)
        {
            return _iemprepo.DeleteEmployee(empId);
        }

        Employee IEmpSl.GetEmployee(int empId)
        {
            return _iemprepo.GetEmployee(empId);
        }

        List<Employee> IEmpSl.GetEmps()
        {
            return _iemprepo.GetEmps();
        }

        int IEmpSl.SaveEmployee(Employee employee)
        {
            return _iemprepo.SaveEmployee(employee);
        }

        int IEmpSl.UpdateEmployee(Employee employee)
        {
            return _iemprepo.UpdateEmployee(employee);
        }
    }
}
