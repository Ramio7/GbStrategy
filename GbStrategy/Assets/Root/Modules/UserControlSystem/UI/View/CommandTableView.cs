using Abstractions.Assets.Root.Modules.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Root.Modules.UserControlSystem.UI.View
{
    public class CommandTableView : MonoBehaviour
    {
        public Action<ICommandExecutor, ICommandsQueue> OnClick;

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
                { typeof(ICommandExecutor<IAttackCommand>), _attackButton },
                { typeof(ICommandExecutor<IMoveCommand>), _moveButton },
                { typeof(ICommandExecutor<IPatrolCommand>), _patrolButton },
                { typeof(ICommandExecutor<IStopCommand>), _stopButton },
                { typeof(ICommandExecutor<IProduceUnitCommand>), _produceUnitButton },
                { typeof(ICommandExecutor<IHoldCommand>), _holdButton }
            };
        }

        public void BlockInteractions(ICommandExecutor ce)
        {
            UnblockAllInteractions();
            GetButtonGameObjectByType(ce.GetType())
                .GetComponent<Selectable>().interactable = false;
        }

        public void UnblockAllInteractions() => SetInteractible(true);

        private void SetInteractible(bool value)
        {
            _attackButton.GetComponent<Selectable>().interactable = value;
            _moveButton.GetComponent<Selectable>().interactable = value;
            _patrolButton.GetComponent<Selectable>().interactable = value;
            _stopButton.GetComponent<Selectable>().interactable = value;
            _produceUnitButton.GetComponent<Selectable>().interactable = value;
            _holdButton.GetComponent<Selectable>().interactable = value;
        }

        public void MakeLayout(IEnumerable<ICommandExecutor> commandExecutors, ICommandsQueue queue)
        {
            foreach (var currentExecutor in commandExecutors)
            {
                var buttonGameObject = GetButtonGameObjectByType(currentExecutor.GetType());
                buttonGameObject.SetActive(true);
                buttonGameObject.GetComponent<Button>().OnClickAsObservable().Subscribe(_ => OnClick.Invoke(currentExecutor, queue));
            }
        }

        private GameObject GetButtonGameObjectByType(Type executorInstanceType)
        {
            return _buttonsByExecutorType
            .Where(type =>
            type.Key.IsAssignableFrom(executorInstanceType))
            .First()
            .Value;
        }

        public void Clear()
        {
            foreach (var kvp in _buttonsByExecutorType)
            {
                kvp.Value.GetComponent<Button>().OnClickAsObservable().Subscribe().Dispose();
                kvp.Value.SetActive(false);
            }
        }
    }
}