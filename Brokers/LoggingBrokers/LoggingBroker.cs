//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using Xeptions;

namespace Tarteeb.Importer.Brokers.LoggingBrokers
{
    internal class LoggingBroker : Xeption
    {
        internal void LogBroker(string message)
        {
            Console.WriteLine(message);
        }
    }
}
