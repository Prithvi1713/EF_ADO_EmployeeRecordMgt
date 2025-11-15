using EF_ADO_EmployeeRecordMgt.Models;

namespace EF_ADO_EmployeeRecordMgt.IRepository
{
    public interface IDepartmentMaster
    {
        IEnumerable<DepartmentMaster> GetAllDepartment();
        DepartmentMaster GetDepartmentById(int id);
        void AddDepartment(DepartmentMaster departmentMaster);

        void EditDepartment(DepartmentMaster departmentMaster);

        void DeleteDepartment(int id);
    }
}
