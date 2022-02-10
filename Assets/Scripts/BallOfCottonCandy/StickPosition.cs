using UnityEngine;
using UnityEngine.Events;

public class StickPosition : MonoBehaviour
{
    private Quaternion _coordinateChangeRotation;    

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
            transform.rotation = Quaternion.RotateTowards(transform.rotation, _coordinateChangeRotation, 200f * Time.deltaTime);
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
