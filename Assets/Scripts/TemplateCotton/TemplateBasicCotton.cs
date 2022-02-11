using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplateBasicCotton : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private float _scale;
    private float _scaleZ;
    private float _limitWindingByZ;
    private float _distancesPreviousWinding = 0.1f;
    private float _valueIncreaseSizeZ = 0.015f;
    private float _valueIncreaseSizeXY = 0.02f;
    private float _valueRapidIncreaseSizeZ = 0.15f;
    private bool _canWinding = true;

    public float Scale => _scale;

    public float ScaleZ => _scaleZ;

    private void Start()
    {
        _scale = transform.localScale.x;
        _scaleZ = transform.localScale.z;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent<ObjectOnCotton>(out ObjectOnCotton objectOnCotton))
        {
            objectOnCotton.transform.SetParent(transform.parent);
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.TryGetComponent<CottonBlock>(out CottonBlock cottonBlock))
        {
            WrapCotton();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.TryGetComponent<CottonBlock>(out CottonBlock cottonBlock))
        {
            _animator.enabled = false;
        }
    }

    private void WrapCotton()
    {
        _animator.enabled = true;
        transform.localScale = new Vector3(_scale, _scale, _scaleZ);
        if (_scaleZ < _limitWindingByZ - _distancesPreviousWinding)
        {
            _scaleZ += _valueRapidIncreaseSizeZ;
        }
        else
        {
            _scaleZ += _valueIncreaseSizeZ;
        }
        if (_canWinding == true)
        {
            _scale += _valueIncreaseSizeXY;
        }
    }

    public void WindingStop()
    {
        _canWinding = false;
    }

    public void ScaleZControlInit(float limitWindingByZ)
    {
        _limitWindingByZ = limitWindingByZ;
    }
}
