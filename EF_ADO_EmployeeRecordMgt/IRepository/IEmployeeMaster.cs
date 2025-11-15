using EF_ADO_EmployeeRecordMgt.Models;

namespace EF_ADO_EmployeeRecordMgt.IRepository
{
    public interface IEmployeeMaster
    {
        IEnumerable<EmployeeMaster> GetAllEmployeeMaster();
        void AddEmployee(EmployeeMaster employeeMaster);
        void EditEmployee(EmployeeMaster employeeMaster);

        EmployeeMaster GetEmployeeById(int id);

        void DeleteEmployee(int id);
    }
}
