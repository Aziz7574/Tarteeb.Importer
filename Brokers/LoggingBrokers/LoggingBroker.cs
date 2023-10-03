using Xeptions;

namespace Tarteeb.Importer.Brokers.LoggingBrokers
{
    internal class LoggingBroker : Xeption
    {
        internal LoggingBroker()
            : base(message: "Client is null")
        { }

    }
}
