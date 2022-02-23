using System;

namespace scopes
{
    public class Transient
    {
        Guid guid = Guid.NewGuid();

        public string Id { get { return guid.ToString(); } }
    }
}