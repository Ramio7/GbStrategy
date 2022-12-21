using Abstractions.Assets.Root.Modules.Abstractions;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Assets.Root.Modules.UserControlSystem.UI.Presenter
{
    public class MouseControlPresenter : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private SelectableValue _selectedObject;
        [SerializeField] private EventSystem _eventSystem;

        [Inject] private Vector3Value _groundClicksRMB;
        [SerializeField] private Transform _groundTransform;

        private Plane _groundPlane;

        private void Start()
        {
            _groundPlane = new Plane(_groundTransform.up, 0);
        }

        private void Update()
        {
            if (!Input.GetMouseButtonUp(0) && !Input.GetMouseButton(1))
            {
                return;
            }
            if (_eventSystem.IsPointerOverGameObject())
            {
                return;
            }
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Input.GetMouseButtonUp(0))
            {
                var hits = Physics.RaycastAll(ray);
                if (hits.Length == 0)
                {
                    return;
                }
                var selectable = hits
                .Select(hit =>
                hit.collider.GetComponentInParent<ISelectable>())
                .Where(c => c != null)
                .FirstOrDefault();
                _selectedObject.SetValue(selectable);
            }
            else
            {
                if (_groundPlane.Raycast(ray, out var enter))
                {
                    _groundClicksRMB.SetValue(ray.origin + ray.direction * enter);
                }
            }
        }
    }
}