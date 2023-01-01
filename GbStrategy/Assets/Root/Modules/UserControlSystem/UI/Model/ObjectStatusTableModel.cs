using Abstractions;
using Abstractions.Assets.Root.Modules.Abstractions;
using System;
using UniRx;
using UnityEngine;
using Zenject;

public class ObjectStatusTableModel
{
    public IObservable<IUnitProducer> UnitProducers { get; private set; }

    [Inject]
    public void Init(IObservable<ISelectable> currentlySelected)
    {
        UnitProducers = currentlySelected.Select(selectable => selectable as Component).Select(component => component?.GetComponent<IUnitProducer>());
    }

}
