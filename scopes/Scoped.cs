using System;

namespace scopes
{
    public class Scoped
    {
        Guid guid = Guid.NewGuid();

        public string Id { get { return guid.ToString(); } }
    }
}