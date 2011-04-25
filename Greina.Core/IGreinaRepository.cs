using System;
using Greina.Core.Model;

namespace Greina.Core
{
    public interface IGreinaRepository
    {
        void Save(Request request);
        bool VisitorExistsById(Guid visitorId);
        void CreateVisitor(Guid visitorId);
        Visitor GetVisitorById(Guid visitorId);
    }
}