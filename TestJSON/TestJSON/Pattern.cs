using System;
using System.Collections.Generic;
using System.Text;

namespace TestJSON
{
    interface IPattern
    {
      (bool, string) Match(string s);   
    }

}
