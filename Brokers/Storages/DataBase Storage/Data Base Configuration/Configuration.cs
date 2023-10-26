//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

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
