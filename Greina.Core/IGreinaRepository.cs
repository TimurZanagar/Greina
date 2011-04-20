using Greina.Core.Model;

namespace Greina.Core
{
    public interface IGreinaRepository
    {
        void Save(Request request);
    }
}