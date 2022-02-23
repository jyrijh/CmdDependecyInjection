using System;

namespace scopes
{
    public class Singleton
    {
        Guid guid = Guid.NewGuid();

        public string Id { get { return guid.ToString(); } }
    }
}