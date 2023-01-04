using Abstractions;
using Abstractions.Assets.Root.Modules.Abstractions;
using Assets.Root.Modules.Abstractions;
using UnityEngine;

namespace Assets.Root.Modules.Core
{
    public class MainBuildingView : MonoBehaviour, ISelectable, IVictim, ISetRallyPoint
    {
        public float Health => _health;

        public float MaxHealth => _maxHealth;

        public Sprite Icon => _icon;

        public MonoBehaviour HighlighterScript { get => _highlighterScript; }

        public Transform ObjectPosition => transform;

        public Vector3 RallyPoint { get => _rallyPoint; set => _rallyPoint = value; }

        [SerializeField] private float _maxHealth;
        [SerializeField] private float _health;
        [SerializeField] private Sprite _icon;
        [SerializeField] private MonoBehaviour _highlighterScript;
        [SerializeField] private Vector3 _rallyPoint;

        public void TakeDamage(int damage)
        {
            if (_health <= 0)
            {
                return;
            }
            _health -= damage;
            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}