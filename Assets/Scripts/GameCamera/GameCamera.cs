using UnityEngine;
using UnityEngine.Animations;

public class GameCamera : MonoBehaviour
{
    [SerializeField] private StickMove _stickMove;
    [SerializeField] private PositionConstraint _positionConstrant;

    private float _speed = 7f;
    private bool _stickMoveFinish = false;
    private Vector3 _position= new Vector3(96f, 90.3f, 130.9f);
    private Quaternion _rotation = Quaternion.Euler(12.1f, -137.4f, 0);

    private void OnEnable()
    {
        _stickMove.StoppedTraffic += CameraMove;
    }

    private void OnDisable()
    {
        _stickMove.StoppedTraffic -= CameraMove;
    }

    private void Update()
    {
        if (_stickMoveFinish == true)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, _rotation, _speed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, _position, _speed * Time.deltaTime);
        }
    }

    private void CameraMove()
    {
        _positionConstrant.enabled = false;
        _stickMoveFinish = true;
    }
}
