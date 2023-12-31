﻿//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

namespace Tarteeb.Importer.Brokers.DateTimeBrokers
{
    internal class DateTimeBroker : IDateTimeBroker
    {
        public DateTimeOffset GetCurrentTime() => DateTimeOffset.UtcNow;
    }
}
