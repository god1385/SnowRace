using Agava.Samples.FakeMoba;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using UnityEngine.Scripting;

[Preserve]
public class MoveTowardsBridge : Action
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private SharedFloat _speedRotation;
    [SerializeField] private SharedFloat _speedMoving;
    [SerializeField] private float _currentDistance;
    [SerializeField] private Transform _bridgeTransform;

    public Bridge Bridge => _enemy.CurrentBridge;

    private float _minDistanceForSuccess = 1.0f;

    public override void OnAwake()
    {
        _enemy = GetComponent<Enemy>();
    }

    public override TaskStatus OnUpdate()
    {
        _currentDistance = Vector3.Distance(_enemy.transform.position, _bridgeTransform.position);

        if (_currentDistance < _minDistanceForSuccess)
        {
            return TaskStatus.Success;

        }
        

        _enemy.EnemyMovement.MoveTo(/*Bridge.StartPoint.position, _speedMoving.Value, _speedRotation.Value*/);
        
        return TaskStatus.Running;
    }

    public override void OnStart()
    {
        _bridgeTransform = Bridge.StartPoint;
        _enemy.NavMeshAgent.SetDestination(_bridgeTransform.position);
    }

}
