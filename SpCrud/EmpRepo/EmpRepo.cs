using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.SqlClient;
using SpCrud.Models;
using System.Data;

namespace SpCrud.EmpRepo
{
    public class EmpRepo : IEmpRepo
    {
        string? _constr;
        public EmpRepo(IConfiguration _config)
        {
            _constr = _config.GetConnectionString("getcon");
        }
        int IEmpRepo.SaveEmployee(Employee employee)
        {
            //create connection
            SqlConnection con = new SqlConnection(_constr);
            //open connection 
            con.Open();
            //pass procedure 
            SqlCommand cmd = new SqlCommand("proc_saveemp", con);
            //Mention that we are using stored procedure
            cmd.CommandType = CommandType.StoredProcedure;
            //pass the values to parameters 
            cmd.Parameters.AddWithValue("@eno", employee.Eno);
            cmd.Parameters.AddWithValue("@ename", employee.Ename);
            cmd.Parameters.AddWithValue("@sal", employee.Salary);
            //execute the procedure
            int i=cmd.ExecuteNonQuery();
            //close the connection 
            con.Close();
            return i;
        }
        int IEmpRepo.DeleteEmployee(int empId)
        {
            //create connection
            SqlConnection con = new SqlConnection(_constr);
            //open connection 
            con.Open();
            //pass procedure 
            SqlCommand cmd = new SqlCommand("proc_deleteemp", con);
            //Mention that we are using stored procedure
            cmd.CommandType = CommandType.StoredProcedure;
            //pass the values to parameters 
            cmd.Parameters.AddWithValue("@eno",empId);
            //execute the procedure
            int i = cmd.ExecuteNonQuery();
            //close the connection 
            con.Close();
            return i;
        }

        Employee IEmpRepo.GetEmployee(int empId)
        {
            Models.Employee emp = new Employee();
            SqlConnection con = new SqlConnection(_constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("searchemp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                { 
                    emp.Eno = Convert.ToInt32(dr[0]);
                    emp.Ename = dr[1].ToString();
                    emp.Salary = Convert.ToDouble(dr[2]);   
                }
            }
            con.Close();
            return emp;
        }

        List<Employee> IEmpRepo.GetEmps()
        {
            List<Models.Employee> emps = new List<Employee>();
            SqlConnection con = new SqlConnection(_constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getemps",con);
            cmd.CommandType = CommandType.StoredProcedure;
           SqlDataReader dr= cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Models.Employee emp = new Employee();
                    emp.Eno = Convert.ToInt32(dr[0]);
                    emp.Ename= dr[1].ToString();
                    emp.Salary = Convert.ToDouble(dr[2]);
                    emps.Add(emp);
                }
            }
            con.Close();
            return emps;
        }

        

        int IEmpRepo.UpdateEmployee(Employee employee)
        {
            //create connection
            SqlConnection con = new SqlConnection(_constr);
            //open connection 
            con.Open();
            //pass procedure 
            SqlCommand cmd = new SqlCommand("proc_updateemp", con);
            //Mention that we are using stored procedure
            cmd.CommandType = CommandType.StoredProcedure;
            //pass the values to parameters 
            cmd.Parameters.AddWithValue("@eno", employee.Eno);
            cmd.Parameters.AddWithValue("@ename", employee.Ename);
            cmd.Parameters.AddWithValue("@salary", employee.Salary);
            //execute the procedure
            int i = cmd.ExecuteNonQuery();
            //close the connection 
            con.Close();
            return i;
        }
    }
}
