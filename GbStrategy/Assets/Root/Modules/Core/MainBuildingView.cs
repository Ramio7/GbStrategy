using Abstractions.Assets.Root.Modules.Abstractions;
using Assets.Root.Modules.Abstractions;
using UnityEngine;

namespace Assets.Root.Modules.Core
{
    public class MainBuildingView : MonoBehaviour, ISelectable, IVictim
    {
        public float Health => _health;

        public float MaxHealth => _maxHealth;

        public Sprite Icon => _icon;

        public MonoBehaviour HighlighterScript { get => _highlighterScript; }

        public Transform ObjectPosition => _buildingPosition;

        [SerializeField] private float _maxHealth;
        [SerializeField] private float _health;
        [SerializeField] private Sprite _icon;
        [SerializeField] private MonoBehaviour _highlighterScript;

        private Transform _buildingPosition;

        private void Start()
        {
            _buildingPosition = transform;
        }
    }
}