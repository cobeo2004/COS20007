using System;

namespace SwinAdventure
{
    public class IdentifiableObject
    {
        private List<string> _identifiers;

        public IdentifiableObject(string[] idents)
        {
            _identifiers = new List<string>();
            foreach (string s in idents)
            {
                _identifiers.Add(s.ToLower());
            }
        }

        public bool AreYou(string id)
        {
            return _identifiers.Contains(id.ToLower());
        }

        public string FirstId
        {
            get
            {
                return _identifiers.Count == 0 ? "" : _identifiers.First();
            }
        }

        public void AddIdentifiers(string id)
        {
            _identifiers.Add(id.ToLower());
        }
    }
}

