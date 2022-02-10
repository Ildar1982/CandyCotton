using UnityEngine;

public class TemplateFluff : MonoBehaviour
{
    private float _valueIncreaseSizeXY = 0.019f;    
    private float _valueIncreaseSizeZ = 0.01f;
    private float _scale;
    private float _scaleZ;
    private bool _canWinding = true;

    private void Start()
    {
        _scale = transform.localScale.x;
        _scaleZ = transform.localScale.z;
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.TryGetComponent<CottonBlockDisgusting>(out CottonBlockDisgusting cottonBlockDisgusting))
        {
            WrapFluffCotton();
        }
        if (collision.gameObject.TryGetComponent<CottonBlockPleasant>(out CottonBlockPleasant cottonBlockPleasant))
        {
            WrapFluffCotton();
        }
    }

    private void WrapFluffCotton()
    {
        transform.localScale = new Vector3(_scale, _scale, _scaleZ);
        if (_canWinding == true)
        {
            _scale += _valueIncreaseSizeXY;
            _scaleZ += _valueIncreaseSizeZ;
        }
    }

    public void StopWinding()
    {
        _canWinding = false;
    }
}
