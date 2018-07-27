
namespace Patterns
{
    public interface IPattern 
    {
      (IMatch, string) Match(string s);   
    }

}
