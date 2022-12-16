using Abstractions.Assets.Root.Modules.Abstractions;
using Assets.Root.Modules.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Root.Modules.UserControlSystem.UI.View
{
    public class CommandTableView : MonoBehaviour
    {
        public Action<ICommandExecutor> OnClick;

        [SerializeField] private GameObject _attackButton;
        [SerializeField] private GameObject _moveButton;
        [SerializeField] private GameObject _patrolButton;
        [SerializeField] private GameObject _stopButton;
        [SerializeField] private GameObject _produceUnitButton;
        [SerializeField] private GameObject _holdButton;

        private Dictionary<Type, GameObject> _buttonsByExecutorType;

        private void Start()
        {
            _buttonsByExecutorType = new Dictionary<Type, GameObject>
            {
                { typeof(CommandExecutorBase<IAttackCommand>), _attackButton },
                { typeof(CommandExecutorBase<IMoveCommand>), _moveButton },
                { typeof(CommandExecutorBase<IPatrolCommand>), _patrolButton },
                { typeof(CommandExecutorBase<IStopCommand>), _stopButton },
                { typeof(CommandExecutorBase<IProduceUnitCommand>), _produceUnitButton },
                { typeof(CommandExecutorBase<IHoldCommand>), _holdButton },
            };
        }
        public void MakeLayout(List<ICommandExecutor> commandExecutors)
        {
            for (int i =0; i < commandExecutors.Count; i++)
            {
                var currentExecutor = commandExecutors[i];
                var buttonGameObject = _buttonsByExecutorType
                    .First(type => type
                        .Key
                        .IsInstanceOfType(currentExecutor.GetType()))
                    .Value;
                buttonGameObject.SetActive(true);
                var button = buttonGameObject.GetComponent<Button>();
                button.onClick.AddListener(() => OnClick?.Invoke(currentExecutor));
            }
        }
        public void Clear()
        {
            foreach (var kvp in _buttonsByExecutorType)
            {
                kvp.Value.GetComponent<Button>().onClick.RemoveAllListeners();
                kvp.Value.SetActive(false);
            }
        }

    }
}