using UnityEngine;

public class StickRotate : MonoBehaviour
{
    [SerializeField] private StickControl _stickControl;
    private bool _isDown = false;
    private float _speed = -200f;

    private void OnEnable()
    {
        _stickControl.TurnedAround += Enable;
        _stickControl.Returned += Disable;
    }

    private void OnDisable()
    {
        _stickControl.TurnedAround -= Enable;
        _stickControl.Returned -= Disable;
    }

    private void Update()
    {
        if (_isDown == true)
        {
            transform.Rotate(0, 0, _speed * Time.deltaTime);
        }
    }

    private void Enable()
    {
        _isDown = true;
    }

    private void Disable()
    {
        _isDown = false;
    }
}
