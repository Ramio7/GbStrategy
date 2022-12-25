using Abstractions;
using UnityEngine;

public abstract class AwatableBase<T> : MonoBehaviour, IAwaitable<T>
{
    public abstract IAwaiter<T> GetAwaiter();
}
