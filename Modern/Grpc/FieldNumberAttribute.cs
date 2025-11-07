using System;

namespace Modern.Analytics;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class FieldNumberAttribute(uint number) : Attribute
{
    public uint Number { get; set; } = number;
}
