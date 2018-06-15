using System;
using System.Collections.Generic;
using System.Text;

namespace HttpValidatorApplication
{
    public interface IDisk
    {
        byte[] VerifyPath(string path);
    }
}
