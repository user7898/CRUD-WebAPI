using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace webapi.Models
{
    public class EmployeeDB
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-JUA4SLH\\MSSQLSERVER03;Initial Catalog=ASP_Core;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");

        public string InsertDB(Employee objcls)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Emp_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Emp_Name", objcls.Name);
                cmd.Parameters.AddWithValue("@Emp_Address", objcls.Address);
                cmd.Parameters.AddWithValue("@Emp_Salary", objcls.Salary);
                con.Open();
                cmd.ExecuteNonQuery();
                return ("Inserted Successfully");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ("Eror:" + ex.Message);
            }
        }

        public List<Employee> SelectDB()
        {
            var list = new List<Employee>();
            try
            {
                SqlCommand cmd = new SqlCommand("Emp_SelectAll",con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var o = new Employee
                    {
                        Eid = Convert.ToInt32(dr["Emp_Id"]),
                        Name = dr["Emp_Name"].ToString(),
                        Address = dr["Emp_Address"].ToString(),
                        Salary = dr["Emp_Salary"].ToString()
                    };
                    list.Add(o);
                }
                con.Close();
                return list;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return list;
            }
        }

        public string Update(int id,Employee emp)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Emp_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Emp_Id",id);
                cmd.Parameters.AddWithValue("@Emp_Name", emp.Name);
                cmd.Parameters.AddWithValue("@Emp_Address", emp.Address);
                cmd.Parameters.AddWithValue("@Emp_Salary", emp.Salary);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Data Updated Successfully");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ("Error:" + ex.Message);
            }
        }


        public List<Employee> SelectById(int id)
        {
            var o = new List<Employee>();
            try
            {
                SqlCommand cmd = new SqlCommand("Emp_SelectById",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Emp_Id", id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    var emp = new Employee
                    {
                        Eid = Convert.ToInt32(dr["Emp_Id"]),
                        Name = dr["Emp_Name"].ToString(),
                        Address = dr["Emp_Address"].ToString(),
                        Salary = dr["Emp_Salary"].ToString()
                    };
                    o.Add(emp);
                }
                return o;
            }
            catch(Exception ex)
            {
                if(con.State==ConnectionState.Open)
                {
                    con.Close();
                }
                return o;
            }

        }


        public string DeleteById(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DeleteEmployeeById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteReader();
                con.Close();
                return ("Deleted Succesfully");
            }
            catch(Exception ex)
            {
                if(con.State==ConnectionState.Open)
                {
                    con.Close();
                }
                return ("Error:" + ex.Message);
            }
        }
        
    }
}

