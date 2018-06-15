using System.IO;
using System.Text;

namespace HttpValidatorApplication
{
    public class MockDisk : IDisk
    {
        delegate byte[] Exception(string path);

        public byte[] VerifyPath(string path)
        {
            if (path.EndsWith("index.html"))
            {
                throw new DirectoryNotFoundException();
            }
            return Encoding.UTF8.GetBytes("");
        }
    }
}
