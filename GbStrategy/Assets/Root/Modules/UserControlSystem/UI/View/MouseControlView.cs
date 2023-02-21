using Abstractions.Assets.Root.Modules.Abstractions;
using Assets.Root.Modules.Abstractions;
using System;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
using Assets.Root.Modules.Utils;

public class MouseControlView : MonoBehaviour
{
    public Action<ICommandExecutor, ICommandsQueue> OnClick;

    [SerializeField] private Camera _camera;
    [SerializeField] private EventSystem _eventSystem;
    [SerializeField] private Transform _groundTransform;

    [Inject] private Vector3Value _groundClicksRMB;
    [Inject] private VictimValue _victimRMB;
    [Inject] private SelectableValue _selectedObject;

    private Plane _groundPlane;
    private IObservable<(Ray, RaycastHit[])> _rightClickHits;
    private CompositeDisposable _disposables = new();

    private ICommandExecutor _commandExecutor;
    private ICommandsQueue _commandQueue;

    private void Start()
    {
        _groundPlane = new Plane(_groundTransform.up, 0);

        SubscribeClicks();
    }

    public void ReBindCommandExecutor() => BindCommandExecutor(_commandExecutor, _commandQueue);

    public void BindCommandExecutor(ICommandExecutor commandExecutor, ICommandsQueue queue)
    {
        if (commandExecutor != _commandExecutor)
        {
            SubmitCommandExecutor(commandExecutor, queue);
        }
        _rightClickHits.Subscribe(_ => OnClick.Invoke(_commandExecutor, _commandQueue)).AddTo(_disposables);
    }

    private void SubmitCommandExecutor(ICommandExecutor commandExecutor, ICommandsQueue queue)
    {
        _commandExecutor = commandExecutor;
        _commandQueue = queue;
    }

    public void UnbindCommandExecutor(ICommandExecutor commandExecutor)
    {
        _disposables.Clear();
    }

    private void SubscribeClicks()
    {
        var nonBlockedByUiFramesStream = Observable.EveryUpdate().Where(_ => !_eventSystem.IsPointerOverGameObject());

        var leftClickStream = nonBlockedByUiFramesStream.Where(_ => Input.GetMouseButtonUp(0));
        var rightClickStream = nonBlockedByUiFramesStream.Where(_ => Input.GetMouseButtonUp(1));

        var lmbRaycast = leftClickStream.Select(_ => _camera.ScreenPointToRay(Input.mousePosition));
        var rmbRaycast = rightClickStream.Select(_ => _camera.ScreenPointToRay(Input.mousePosition));

        var lmbHits = lmbRaycast.Select(selector: ray => Physics.RaycastAll(ray));
        var rmbHits = rmbRaycast.Select(selector: ray => (ray, Physics.RaycastAll(ray)));
        _rightClickHits = rmbHits;

        lmbHits.Subscribe(hits =>
        {
            if (RaycastTypeHandler<ISelectable>(hits, out var selectable))
            {
                _selectedObject.SetValue(selectable);
            }
            else
            {
                _selectedObject.SetValue(null);
            }
        });

        rmbHits.Subscribe((ray, hits) =>
        {
            if (RaycastTypeHandler<IVictim>(hits, out var victim))
            {
                _victimRMB.SetValue(victim);
            }
            else if (_groundPlane.Raycast(ray, out var enter))
            {
                _groundClicksRMB.SetValue(ray.origin + ray.direction * enter);
            }
        });
    }

    private bool RaycastTypeHandler<T>(RaycastHit[] hits, out T result) where T : class
    {
        result = default;

        if (hits.Length == 0)
        {
            return false;
        }

        result = hits.Select(hit => hit.collider.GetComponentInParent<T>()).FirstOrDefault(c => c != null);
        return result != default;
    }
}
