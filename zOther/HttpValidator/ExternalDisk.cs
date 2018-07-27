using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HttpValidatorApplication
{
    public class ExternalDisk : IDisk
    {
        private string path;

        public ExternalDisk(string path)
        {
            this.path = path;
        }

        public byte[] VerifyPath(string Uri)
        {
            var diskPath = Path.Combine(path + Uri);

            return File.ReadAllBytes(diskPath);
        }
    }
}
