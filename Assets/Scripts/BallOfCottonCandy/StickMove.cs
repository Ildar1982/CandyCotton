using UnityEngine;
using UnityEngine.Events;

public class StickMove : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private float _speed = 4f;
    private Vector3 _finish;
    private float _coordinateXStopTraffic = 103f;
    private float _coordinateXStopFlight = 91.4f;

    public event UnityAction StoppedTraffic;
    public event UnityAction StoppedFlight;

    private void Start()
    {
        _finish = transform.position;
        _finish.x = _coordinateXStopTraffic;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _finish, _speed * Time.deltaTime);
        if (transform.position.x == _coordinateXStopTraffic)
        {
            _animator.enabled = true;
            StoppedTraffic?.Invoke();
        }
        if (transform.position.x <= _coordinateXStopFlight)
        {
            _animator.enabled = false;
            StoppedFlight?.Invoke();
        }
    }
}