using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CommandTableView : MonoBehaviour
{
    public Action<ICommandExecutor> OnClick;
    [SerializeField] private GameObject _attackButton;
    [SerializeField] private GameObject _moveButton;
    [SerializeField] private GameObject _patrolButton;
    [SerializeField] private GameObject _stopButton;
    [SerializeField] private GameObject _produceUnitButton;

    private Dictionary<Type, GameObject> _buttonsByExecutorType;

    private void Start()
    {
        _buttonsByExecutorType = new Dictionary<Type, GameObject>
        {
            { typeof(CommandExecutorBase<IAttackCommand>), _attackButton },
            { typeof(CommandExecutorBase<IMoveCommand>), _moveButton },
            { typeof(CommandExecutorBase<IPatrolCommand>), _patrolButton },
            { typeof(CommandExecutorBase<IStopCommand>), _stopButton },
            {
                typeof(CommandExecutorBase<IProduceUnitCommand>),
                _produceUnitButton
            }
        };
    }
    public void MakeLayout(IEnumerable<ICommandExecutor> commandExecutors)
    {
        foreach (var currentExecutor in commandExecutors)
        {
            var buttonGameObject = _buttonsByExecutorType
            .Where(type => type
            .Key
            .IsAssignableFrom(currentExecutor.GetType())
            )
            .First()
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
