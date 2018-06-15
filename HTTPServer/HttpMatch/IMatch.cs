using System;

namespace HttpMatch
{
    public interface IMatch
    {
        (bool, string) Match { get; set; }
    }
}
