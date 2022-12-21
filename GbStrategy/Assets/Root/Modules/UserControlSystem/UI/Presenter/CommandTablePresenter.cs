using Abstractions.Assets.Root.Modules.Abstractions;
using Assets.Root.Modules.UserControlSystem.UI.View;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Root.Modules.UserControlSystem.UI.Presenter
{
    public class CommandTablePresenter : MonoBehaviour
    {
        [SerializeField] private SelectableValue _selectable;
        [SerializeField] private CommandTableView _view;

        [Inject] private CommandTableModel _model;

        private ISelectable _currentSelectable;

        private void Start()
        {
            _view.OnClick += _model.OnCommandButtonClicked;
            _model.OnCommandSent += _view.UnblockAllInteractions;
            _model.OnCommandCancel += _view.UnblockAllInteractions;
            _model.OnCommandAccepted += _view.BlockInteractions;

            _selectable.onSelected += ONSelected;
            ONSelected(_selectable.CurrentValue);
        }
        private void ONSelected(ISelectable selectable)
        {
            if (_currentSelectable == selectable)
            {
            return;
            }
            if (_currentSelectable != null)
            {
                _model.OnSelectionChanged();
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

    }
}