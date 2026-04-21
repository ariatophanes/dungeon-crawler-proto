using UnityEngine;

namespace Spawn
{
    public class SpawnPoint : MonoBehaviour
    {
        public SpawnType spawnType = SpawnType.Player;
        [Range(0f, 5f)] public float radius = 0.5f;

#if UNITY_EDITOR
        private static readonly Color ColorPlayer = new(0.2f, 0.7f, 1.0f);
        private static readonly Color ColorEnemy = new(1.0f, 0.1f, 0.1f);
        private static readonly Color ColorItem = new(1.0f, 0.85f, 0.2f);

        private SpawnType _cachedType = (SpawnType)(-1);
        private Color _cachedColor;
        private Color _cachedColorFill;

        private void OnDrawGizmos()
        {
            EnsureColorCache();

            var pos = transform.position;

            Gizmos.color = _cachedColorFill;
            Gizmos.DrawSphere(pos, radius);

            Gizmos.color = _cachedColor;
            Gizmos.DrawWireSphere(pos, radius);

            var s = radius * 0.4f;
            Gizmos.DrawLine(pos - Vector3.right * s, pos + Vector3.right * s);
            Gizmos.DrawLine(pos - Vector3.forward * s, pos + Vector3.forward * s);
        }

        private void OnDrawGizmosSelected()
        {
            EnsureColorCache();

            Gizmos.color = new Color(_cachedColor.r, _cachedColor.g, _cachedColor.b, 0.15f);
            Gizmos.DrawWireSphere(transform.position, radius * 1.3f);

            UnityEditor.Handles.Label(
                transform.position + Vector3.up * (radius + 0.3f),
                $"[ {spawnType} Spawn Point ]",
                new GUIStyle { fontSize = 14, normal = { textColor = _cachedColor }, fontStyle = FontStyle.Bold}
            );
        }

        private void EnsureColorCache()
        {
            if (_cachedType == spawnType) return;

            _cachedType = spawnType;
            _cachedColor = GetColor();
            _cachedColorFill = new Color(_cachedColor.r, _cachedColor.g, _cachedColor.b, 0.15f);
        }
        
        private Color GetColor() => spawnType switch
        {
            SpawnType.Player => ColorPlayer,
            SpawnType.Enemy => ColorEnemy,
            SpawnType.Item => ColorItem,
            _ => Color.white
        };
#endif
    }
}