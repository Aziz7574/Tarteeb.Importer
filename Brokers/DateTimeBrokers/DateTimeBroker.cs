namespace Tarteeb.Importer.Brokers.DateTimeBrokers
{
    internal class DateTimeBroker
    {
        internal DateTimeBroker()
        { }
        DateTimeOffset GetCurrentDateTime() => DateTimeOffset.UtcNow;
    }
}
