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
    }
}
