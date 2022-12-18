using System.Data;
using System.Data.SqlClient;

namespace jsonToAngular_backEnd_.Repository_Pattern
{
    public class SendForm
    {
        private readonly IConfiguration Configuration;//connection Interface

        public SendForm(IConfiguration config)
        {
            Configuration = config;
        }

        public string FormRepository()
        {
            string Form = "";
            try
            {

                SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("DefaultConnection").ToString());

                connection.Open();
                string loadInforamtion = "SELECT JsonForm FROM JsonFormatFormTable";
                SqlCommand comm = new SqlCommand(loadInforamtion, connection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);


                if (dt.Rows.Count > 0)
                {
                    Form = Convert.ToString(dt.Rows[0]["JsonForm"]);

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return Form;

        }

        public void storeInformation(object json)
        {
            
            try
            {

                SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("DefaultConnection").ToString());

                connection.Open();
               // string storeInforamtion = "INSERT INTO userInformationTable (userInfo) VALUES (json)";
                SqlCommand command;
                SqlDataAdapter adapter = new SqlDataAdapter();
                String sql = "";

                sql = "INSERT INTO [userInformationTable] VALUES(@userInfo)";
                

                command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@userInfo", json.ToString());

                command.ExecuteNonQuery();
                //adapter.InsertCommand = new SqlCommand(sql, connection);
                //adapter.InsertCommand.ExecuteNonQuery();

                command.Dispose(); 
		        connection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            

        }

    }
}
