using System.Linq;
using UnityEngine;

public class MouseControlPresenter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private SelectableValue _selectedObject;

    private void Update()
    {
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
        _selectedObject.SetValue(selectable);

        if (_selectedObject.CurrentValue != null) _selectedObject.CurrentValue.HighlighterScript.enabled = true;
    }
}