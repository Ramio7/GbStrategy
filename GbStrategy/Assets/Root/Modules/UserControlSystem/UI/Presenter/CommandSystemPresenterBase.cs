using Abstractions.Assets.Root.Modules.Abstractions;
using Assets.Root.Modules.UserControlSystem.UI.Model;
using System;
using UnityEngine;
using Zenject;

public abstract class CommandSystemPresenterBase : MonoBehaviour
{
    [Inject] protected IObservable<ISelectable> _selectable;
    [Inject] protected ControlSystemModel _model;

    protected ISelectable _currentSelectable;

    protected abstract void OnSelected(ISelectable selectable);
}
