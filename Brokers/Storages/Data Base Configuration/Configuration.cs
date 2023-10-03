namespace Tarteeb.Importer.DataBase.DAL
{
    internal class Configuration : IConfiguration
    {
        public string GetConfiguration()
        {
            return "Data Source =..\\..\\..\\DbSource.db";
        }
    }
}
