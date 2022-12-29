using Assets.Root.Modules.UserControlSystem.UI.Model;
using System;
using UniRx;

public abstract class StatefullModifiedValue<T> : ModifiedValue<T>, IObservable<T>
{
    private ReactiveProperty<T> _innerDataSource = new ReactiveProperty<T>();

    public override void SetValue(T value)
    {
        base.SetValue(value);
        _innerDataSource.Value = value;
    }

    public IDisposable Subscribe(IObserver<T> observer) =>
    _innerDataSource.Subscribe(observer);
}