using UnityEngine;
using Zenject;
public class AttackerParallelnfoUpdater : MonoBehaviour, ITickable
{
    [Inject] private IDamageDealer _automaticAttacker;
    [Inject] private ICommandsQueue _queue;

    public void Tick()
    {
        AutoAttackEvaluator.AttackersInfo.AddOrUpdate(gameObject, new AutoAttackEvaluator.AttackerParallelnfo(_automaticAttacker.VisionRange, _queue.CurrentCommand), (go, value) =>
        {
            value.VisionRange = _automaticAttacker.VisionRange;
            value.CurrentCommand = _queue.CurrentCommand;
            return value;
        });
    }

    private void OnDestroy()
    {
        AutoAttackEvaluator.AttackersInfo.TryRemove(gameObject, out _);
    }
}
