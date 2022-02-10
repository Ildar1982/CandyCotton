using UnityEngine;

public class StickRotate : MonoBehaviour
{
    [SerializeField] StickPosition _stickPosition;
    private bool _isDown = false;

    private void OnEnable()
    {
        _stickPosition.TurnedAround += Enable;
        _stickPosition.Returned += Disable;
    }

    private void OnDisable()
    {
        _stickPosition.TurnedAround -= Enable;
        _stickPosition.Returned -= Disable;
    }

    private void Update()
    {
        if (_isDown == true)
        {
            transform.Rotate(0, 0, -200f * Time.deltaTime);
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
