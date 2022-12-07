namespace api.casa.popular.Core.Database
{
    using domain.casa.popular.Queries;
    using Microsoft.Data.SqlClient;

    public static class DbSeed
    {
        public static void AddDatabaseWithSeed(string connection)
        {
            AddFamiliaSeed(connection);
            AddPessoasSeed(connection);
        }

        private static void AddFamiliaSeed(string connection)
        {
            var myConn = new SqlConnection(connection);

            SqlCommand myCommand = new SqlCommand(Queries.AddFamiliaSeed(), myConn);

            myConn.Open();
            myCommand.ExecuteNonQuery();
            myConn.Close();
        }

        private static void AddPessoasSeed(string connection)
        {
            var myConn = new SqlConnection(connection);

            SqlCommand myCommand = new SqlCommand(Queries.AddPessoaSeed(), myConn);

            myConn.Open();
            myCommand.ExecuteNonQuery();
            myConn.Close();
        }
    }
}
