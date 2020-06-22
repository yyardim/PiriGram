using System;

namespace PG.Models
{
    public sealed class ConnectionString
    {
        public ConnectionString(string value) => Value = value;
        public String Value { get; }
    }
}
