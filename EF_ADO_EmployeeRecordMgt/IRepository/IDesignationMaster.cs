

using EF_ADO_EmployeeRecordMgt.Models;

namespace EF_ADO_EmployeeRecordMgt.IRepository
{
    public interface IDesignationMaster
    {
        IEnumerable<DesignationMaster> GetAllDesignations();
        void AddDesignation(DesignationMaster designationMaster);
        void EditDesignation(DesignationMaster designationMaster);

        DesignationMaster GetDesignationById(int id);

        void DeleteDesignation(int id);
    }
}
