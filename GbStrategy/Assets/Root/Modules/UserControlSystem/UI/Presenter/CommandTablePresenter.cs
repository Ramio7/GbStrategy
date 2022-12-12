using Abstractions.Assets.Root.Modules.Abstractions;
using Assets.Root.Modules.Core;
using Assets.Root.Modules.UserControlSystem.Commands;
using Assets.Root.Modules.UserControlSystem.UI.View;
using Assets.Root.Modules.Utils;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Root.Modules.UserControlSystem.UI.Presenter
{
    public class CommandTablePresenter : MonoBehaviour
    {
        [SerializeField] private SelectableValue _selectable;
        [SerializeField] private CommandTableView _view;
        [SerializeField] private AssetsContext _context;

        private ISelectable _currentSelectable;

        private void Start()
        {
            _selectable.OnSelected += OnSelected;
            OnSelected(_selectable.CurrentValue);
            _view.OnClick += OnButtonClick;
        }
        private void OnSelected(ISelectable selectable)
        {
            if (_currentSelectable == selectable)
            {
                return;
            }
            _currentSelectable = selectable;
            _view.Clear();
            if (selectable != null)
            {
                var commandExecutors = new List<ICommandExecutor>();
                commandExecutors.AddRange((selectable as
                Component).GetComponentsInParent<ICommandExecutor>());
                _view.MakeLayout(commandExecutors);
            }
        }
        private void OnButtonClick(ICommandExecutor commandExecutor)
        {
            var unitProducer = commandExecutor as
            CommandExecutorBase<IProduceUnitCommand>;
            if (unitProducer != null)
            {
                unitProducer.ExecuteSpecificCommand(_context.Inject(new ProduceUnitCommand()));
                return;
            }
            throw new
            ApplicationException($"{nameof(CommandTablePresenter)}.{nameof(OnButtonClick)}: Unknown type of commands executor: {commandExecutor.GetType().FullName}!");
        }

    }
}