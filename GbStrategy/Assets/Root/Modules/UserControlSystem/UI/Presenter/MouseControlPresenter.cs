using Abstractions.Assets.Root.Modules.Abstractions;
using Assets.Root.Modules.Abstractions;
using Assets.Root.Modules.UserControlSystem.UI.Model;
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
        [Inject] private VictimValue _victimRMB;
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
            var hits = Physics.RaycastAll(ray);

            if (Input.GetMouseButtonUp(0))
            {
                if (RaycastTypeHandler<ISelectable>(hits, out var selectable))
                {
                    _selectedObject.SetValue(selectable);
                }
            }
            else
            {
                if (RaycastTypeHandler<IVictim>(hits, out var victim))
                {
                    _victimRMB.SetValue(victim);
                }
                else if (_groundPlane.Raycast(ray, out var enter))
                {
                    _groundClicksRMB.SetValue(ray.origin + ray.direction * enter);
                }
            }

        }

        private bool RaycastTypeHandler<T>(RaycastHit[] hits, out T result) where T : class
        {
            result = default;
            if (hits.Length == 0)
            {
                return false;
            }
            result = hits
            .Select(hit =>
            hit.collider.GetComponentInParent<T>())
            .Where(c => c != null)
            .FirstOrDefault();
            return result != default;
        }
    }
}