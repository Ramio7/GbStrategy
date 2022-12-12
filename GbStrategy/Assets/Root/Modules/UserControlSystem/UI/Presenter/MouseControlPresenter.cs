using Abstractions.Assets.Root.Modules.Abstractions;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Root.Modules.UserControlSystem.UI.Presenter
{
    public class MouseControlPresenter : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private SelectableValue _selectedObject;
        [SerializeField] private EventSystem _eventSystem;

        private void Update()
        {
            if (_eventSystem.IsPointerOverGameObject())
            {
                return;
            }

            if (!Input.GetMouseButtonUp(0))
            {
                return;
            }

            var hits = Physics.RaycastAll(_camera.ScreenPointToRay(Input.mousePosition));
            if (hits.Length == 0)
            {
                return;
            }

            var selectable = hits
            .Select(hit => hit.collider.GetComponentInParent<ISelectable>())
            .FirstOrDefault(c => c != null);

            if (selectable == null && _selectedObject.CurrentValue != null) _selectedObject.CurrentValue.HighlighterScript.enabled = false;

            _selectedObject.SetValue(selectable);

            if (_selectedObject.CurrentValue != null) _selectedObject.CurrentValue.HighlighterScript.enabled = true;
        }
    }
}