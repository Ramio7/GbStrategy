using Abstractions.Assets.Root.Modules.Abstractions;
using UniRx;
using UnityEngine;

namespace Assets.Root.Modules.UserControlSystem.UI.Presenter
{
    public sealed class MouseControlPresenter : CommandSystemPresenterBase
    {
        [SerializeField] private MouseControlView _view;

        private void Start()
        {
            _view.OnClick += _model.OnRightMouseButtonClicked;

            _model.OnCommandSent += _view.ReBindCommandExecutor;
            _model.OnCommandCancel += _view.ReBindCommandExecutor;
            _model.OnCommandAccepted += _view.UnbindCommandExecutor;

            _selectable.Subscribe(OnSelected);
        }

        protected override void OnSelected(ISelectable selectable)
        {
            if (_currentSelectable == selectable)
            {
                return;
            }

            if (_currentSelectable != null)
            {
                _model.OnSelectionChanged();
            }

            if (selectable != null)
            {
                var commandExecutor = (selectable as Component).GetComponentInParent<ICommandExecutor<IMoveCommand>>();
                var queue = (selectable as Component).GetComponentInParent<ICommandsQueue>();

                _view.BindCommandExecutor(commandExecutor, queue);
            }
        }
    }
}