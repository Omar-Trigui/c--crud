using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MyModel;


namespace Controller
{
    public class ClientController
    {
        SqlConnection conn;
        SqlConnectionStringBuilder ConnString;
        public void Connect()
        {
            //Data Source=DESKTOP-T0PFLV5;Initial Catalog=MyDB;Integrated Security=True
            ConnString = new SqlConnectionStringBuilder();
            ConnString.DataSource = "DESKTOP-T0PFLV5";
            ConnString.InitialCatalog = "MyDB";
            ConnString.IntegratedSecurity = true;
            conn = new SqlConnection(ConnString.ToString());
        }
        public ClientController()
        {
            Connect(); 

        }
        public void Insert(Client c)
        {
            try
            {
                String sql = "INSERT INTO dbo.CLient(FirstName,LastName)VALUES(@firstName,@lastName)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@firstName", c.Firstname);
                cmd.Parameters.AddWithValue("@lastName", c.Lastname);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if(conn != null)
                {
                    conn.Close();
                }
            }
        }
       
        public List<Client> FillClient()
        {
            List<Client> clientList = new List<Client>();
            try
            {
                string sql = "SELECT * FROM dbo.client";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                while(Reader.Read()){
                    Client c = new Client();
                    c.Id = Convert.ToInt32(Reader["ID"].ToString());
                    c.Firstname = Reader["Firstname"].ToString();
                    c.Lastname = Reader["Lastname"].ToString();
                    clientList.Add(c);

                }
                return clientList;
                    
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if(conn != null)
                {
                    conn.Close();
                }
            }   

        }
        public void Update(Client oldC , Client newC)
        {
           
            try
            {
                string sql = "UPDATE dbo.client SET FirstName = @firstName ,LastName = @lastName WHERE ID = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@firstName", newC.Firstname);
                cmd.Parameters.AddWithValue("@lastName", newC.Lastname);
                cmd.Parameters.AddWithValue("@id", oldC.Id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if(conn != null)
                {
                    conn.Close();
                }
            }

        }
        public void Delete(Client c)
        {
            try
            {
                string sql = "DELETE FROM dbo.Client WHERE ID = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", c.Id);
                conn.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if(conn != null)
                {
                    conn.Close();
                }
            }
        }

        

    }
}
