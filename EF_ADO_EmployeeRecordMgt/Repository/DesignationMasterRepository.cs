using EF_ADO_EmployeeRecordMgt.Models;
using EF_ADO_EmployeeRecordMgt.IRepository;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EF_ADO_EmployeeRecordMgt.Repository
{
    public class DesignationMasterRepository : IDesignationMaster
    {
        private readonly string _connectionString;

        public DesignationMasterRepository(IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(connection))
                throw new InvalidOperationException(" Connection string is not Found");
            _connectionString = connection;
        }

        public IEnumerable<DesignationMaster> GetAllDesignations()
        {
            var designation = new List<DesignationMaster>();

            using (var conn = new SqlConnection(_connectionString))
            {
                
                var cmd = new SqlCommand("usp_GetAllDesignations" ,conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DesignationMaster designationMaster = new DesignationMaster()
                        {
                            DesignId = Convert.ToInt32(reader["DesignId"]),
                            DesignName = reader["DesignName"]?.ToString() ?? string.Empty
                        };

                        designation.Add(designationMaster);
                    }
                }
            }

            return designation;
        }

        public DesignationMaster GetDesignationById(int DesignId)
        {
            DesignationMaster designation = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                //var query = "select * from DesignationMasters where DesignId=@DesignId";
                var sp = "usp_GetDesignById";
                var cmd = new SqlCommand(sp, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DesignId", DesignId);
                
                connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        designation = new DesignationMaster()
                        {
                            DesignId = Convert.ToInt32(reader["DesignId"]),
                            DesignName = reader["DesignName"]?.ToString() ?? string.Empty
                        };
                    }
                }
            }
            return designation;
        }
        public void AddDesignation(DesignationMaster designationMaster)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sp = "usp_InsertDesignation";
                //var query = " insert into DesignationMasters(DesignName) values(@DesignName)";

                var cmd = new SqlCommand(sp, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DesignName", designationMaster.DesignName);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EditDesignation(DesignationMaster designationMaster)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sp = "usp_UpdateDesignation";
                //var query = "update DesignationMasters set DesignName=@DesignName where DesignId=@DesignId";
                var command = new SqlCommand(sp, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@DesignName", designationMaster.DesignName);
                command.Parameters.AddWithValue("@DesignId", designationMaster.DesignId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteDesignation(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                //var query = "Delete DesignationMasters where DesignId = @DesignId";
                var sp = "usp_DeleteDesignation";
                var command = new SqlCommand(sp, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@DesignId", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

    }
}
