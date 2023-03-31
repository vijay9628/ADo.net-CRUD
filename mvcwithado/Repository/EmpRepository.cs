using mvcwithado.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace mvcwithado.Repository
{
    public class EmpRepository
    {


        private SqlConnection con;
        //To Handle connection related activities    
        private void connection()
            {
            string constr = ConfigurationManager.ConnectionStrings["testdb"].ToString();
            con = new SqlConnection(constr);

        }

        public List<EmpModel> GetAllEmployees()
        {
            connection();
            List<EmpModel> EmpList = new List<EmpModel>();


            SqlCommand com = new SqlCommand("spGetEmployee", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {

                EmpList.Add(

                    new EmpModel
                    {

                        EmployeeId = Convert.ToInt32(dr[0]),
                        EmployeeName = Convert.ToString(dr[1]),
                        EmployeeGender = Convert.ToString(dr[2]),
                        EmployeeDesignation = Convert.ToString(dr[3]),
                        Image =Convert.ToString(dr[4])
                       

                    }
                    );
            }

            return EmpList;
        }

        public void AddEmployee(EmpModel emp)
        {
            connection();
            con.Open();

            SqlCommand cmd = new SqlCommand("spAddEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmployeeId", emp.EmployeeId);
            cmd.Parameters.AddWithValue("@EmployeeName", emp.EmployeeName);
            cmd.Parameters.AddWithValue("@EmployeeGender", emp.EmployeeGender);
            cmd.Parameters.AddWithValue("@EmployeeDesignation", emp.EmployeeDesignation);
            cmd.Parameters.AddWithValue("@Image", emp.Image);
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public void EditEmployee(EmpModel emp)
        {
            connection();
            con.Open();
            SqlCommand cmd = new SqlCommand("spEditEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmployeeId", emp.EmployeeId);
            cmd.Parameters.AddWithValue("@EmployeeName", emp.EmployeeName);
            cmd.Parameters.AddWithValue("@EmployeeGender", emp.EmployeeGender);
            cmd.Parameters.AddWithValue("@EmployeeDesignation", emp.EmployeeDesignation);
            cmd.Parameters.AddWithValue("@Image", emp.Image);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteEmployee(int id)
        {
            connection();
            con.Open();
            SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmployeeId", id);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}