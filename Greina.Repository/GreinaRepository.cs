using System;
using Greina.Core;
using Greina.Core.Model;

namespace Greina.Repository
{
    public class GreinaRepository : IGreinaRepository
    {
        #region IGreinaRepository Members

        public void Save(Request request)
        {
            throw new NotImplementedException();
        }

        public bool VisitorExistsById(Guid visitorId)
        {
            throw new NotImplementedException();
        }

        public void CreateVisitor(Guid visitorId)
        {
            throw new NotImplementedException();
        }

        public Visitor GetVisitorById(Guid visitorId)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}