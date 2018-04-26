using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns
{
    public interface IPattern
    {
      (bool, string) Match(string s);   
    }

}
