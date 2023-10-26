//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

namespace Tarteeb.Importer.Brokers.DateTimeBrokers
{
    internal interface IDateTimeBroker
    {
        DateTimeOffset GetCurrentTime();
    }
}
