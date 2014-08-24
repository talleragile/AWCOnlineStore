using System; 
using System.Data; 
using System.Collections; 
using System.Configuration; 
using System.Linq; 
using System.Web; 
using System.Data.SqlClient; 
using System.Web.Security; 
using System.Web.UI; 
using System.Web.Configuration; 
using System.Web.UI.HtmlControls; 
using System.Web.UI.WebControls; 
using System.Web.UI.WebControls.WebParts; 
using System.Xml.Linq; 
using System.Collections.Generic; 

/// <summary> 
/// Summary description for EmployeeDB 
/// </summary> 
public class EmployeeDB 
{ 
    private string connectionString; 

    public EmployeeDB() 
    { 
        this.connectionString = WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString; 
    } 
    public EmployeeDB(string connectionstring) 
    { 
        this.connectionString = connectionstring; 
    } 

    public int insertEmployee(EmployeeDetails emp) 
    { 
        SqlConnection conn = new SqlConnection(connectionString); 
        SqlCommand cmd = new SqlCommand("InsertEmployee", conn); 
        cmd.CommandType = CommandType.StoredProcedure; 
        cmd.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.VarChar, 10)); 
        cmd.Parameters["@FirstName"].Value = emp.FirstName; 
        cmd.Parameters.Add(new SqlParameter("@LastName",SqlDbType.VarChar,20)); 
        cmd.Parameters["@LastName"].Value = emp.LastName; 
        cmd.Parameters.Add(new SqlParameter("@TitleOfCourtesy",SqlDbType.VarChar,40)); 
        cmd.Parameters["@TitleOfCourtesy"].Value = emp.TitleOfCourtesy; 
        cmd.Parameters.Add(new SqlParameter("@EmployeeID",SqlDbType.Int,4)); 
        cmd.Parameters["@EmployeeID"].Direction = ParameterDirection.Output; 
        try 
        { 
            conn.Open(); 
            cmd.ExecuteNonQuery(); 
            return (int)cmd.Parameters["@EmployeeID"].Value; 
        } 
        catch (SqlException err) 
        { 
            throw new ApplicationException("Data Error"); 
        } 
        finally 
        { 
            conn.Close(); 
        } 
    } 

    public void deleteEmployee(int ID) 
    { 
        SqlConnection conn = new SqlConnection(connectionString); 
        SqlCommand cmd = new SqlCommand("DeleteEmployee", conn); 
        cmd.CommandType = CommandType.StoredProcedure; 
        cmd.Parameters.Add(new SqlParameter("@EmployeeID", SqlDbType.Int, 4)); 
        cmd.Parameters["@EmployeeID"].Value = ID; 
        try 
        { 
            conn.Open(); 
            cmd.ExecuteNonQuery(); 
        } 
        catch (SqlException err) 
        { 
            throw new ApplicationException("Data Error"); 
        } 
        finally 
        { 
            conn.Close(); 
        } 
    } 

    //public void updateEmployee(int EmployeeID,string firstName,string lastName,string titleOfCourtesy) 
    //{ 
    //} 

    public EmployeeDetails getEmployee(int ID) 
    { 
        SqlConnection conn = new SqlConnection(connectionString); 
        SqlCommand cmd = new SqlCommand("GetEmployee", conn); 
        cmd.CommandType = CommandType.StoredProcedure; 
        cmd.Parameters.Add(new SqlParameter("@EmployeeID", SqlDbType.Int, 4)); 
        cmd.Parameters["@Employee"].Value = ID; 
        try 
        { 
            conn.Open(); 
            SqlDataReader reader = cmd.ExecuteReader(); 
            if (!reader.HasRows) 
                return null; 
            reader.Read(); 
            EmployeeDetails emp = new EmployeeDetails(); 
            emp.EmployeeID = (int)reader["EmployeeID"]; 
            emp.FirstName = (string)reader["FirstName"]; 
            emp.LastName=(string)reader["LastName"]; 
            emp.TitleOfCourtesy=(string)reader["TitleOfCourtesy"]; 
            reader.Close(); 
            return emp; 
        } 
        catch (SqlException err) 
        { 
            throw new ApplicationException("Data Error"); 
        } 
        finally 
        { 
            conn.Close(); 
        } 
    } 

    public List<EmployeeDetails> getAllEmployees() 
    { 
        SqlConnection conn = new SqlConnection(connectionString); 
        SqlCommand cmd = new SqlCommand("getAllEmployees", conn); 
        cmd.CommandType = CommandType.StoredProcedure; 
        List<EmployeeDetails> employees = new List<EmployeeDetails>(); 
        try 
        { 
            conn.Open(); 
            SqlDataReader reader = cmd.ExecuteReader(); 

            while (reader.Read()) 
            { 
                EmployeeDetails emp = new EmployeeDetails(); 
                //(int)reader["EmployeeID"],(string)reader["FirstName"],(string)reader["LastName"],(string)reader["TitleOfCouresy"] 
                emp.LastName = (string)reader["LastName"]; 
                emp.FirstName = (string)reader["FirstName"]; 
                //emp.EmployeeID = (int)reader["EmployeeID"]; 
                emp.TitleOfCourtesy = (string)reader["TitleOfCourtesy"]; 

                employees.Add(emp); 
            } 
            reader.Close(); 
            return employees; 
        } 
        catch (SqlException err) 
        { 
            throw new ApplicationException(err.Message); 
        } 
        finally 
        { 
            conn.Close(); 
        } 
    } 

    //public int countEmployees() 
    //{ 
    // return 0; 
    //} 
} 


