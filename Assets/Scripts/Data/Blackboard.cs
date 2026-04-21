using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    public class Blackboard
    {
        private readonly Dictionary<string, object> _data = new();

        public void Set<T>(string key, T value) => _data[key] = value;

        public T Get<T>(string key, T fallback = default)
        {
            if (_data.TryGetValue(key, out var val) && val is T typed)
                return typed;
            return fallback;
        }

        public bool GetBool(string key)   => Get<bool>(key);
        public Vector2 GetVector2(string key) => Get<Vector2>(key);
        public float GetFloat(string key) => Get<float>(key);
    }
}
