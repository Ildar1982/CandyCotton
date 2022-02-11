using UnityEngine;
using UnityEngine.Events;

public class StickControl : MonoBehaviour
{
    private Quaternion _coordinateChangeRotation;
    private float _speed = 200f;

    public event UnityAction TurnedAround;
    public event UnityAction Returned;

    private void Start()
    {
        _coordinateChangeRotation = transform.rotation;
    }

    void Update()
    {
        if (transform.rotation != _coordinateChangeRotation)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, _coordinateChangeRotation, _speed * Time.deltaTime);
        }
        if (Input.GetMouseButtonDown(0))
        {
            _coordinateChangeRotation = Quaternion.Euler(199, 0, 0);
            TurnedAround?.Invoke();
        }
        if (Input.GetMouseButtonUp(0))
        {
            _coordinateChangeRotation = Quaternion.Euler(135, 0, 0);
            Returned?.Invoke();
        }
    }
}
