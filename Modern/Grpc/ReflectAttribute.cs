using System;

namespace Modern.Analytics;

[AttributeUsage(AttributeTargets.All)]
public class ReflectAttribute : Attribute
{
    public bool Reflect { get; set; }

    public ReflectAttribute()
    {
        Reflect = true;
    }

    public ReflectAttribute(bool reflect)
    {
        Reflect = reflect;
    }

}
