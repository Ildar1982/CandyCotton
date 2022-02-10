using System.Collections;
using UnityEngine;

public class CottonDeformation : MonoBehaviour
{
    [SerializeField] private ImpactDeformable[] _deformationObjects;
    [SerializeField] private float _degreeOfDeformation;
    [SerializeField] private StickPosition _takingCottonCandy;

    private bool _isDeformed = false;

    private void OnEnable()
    {
        _takingCottonCandy.TurnedAround += AllowDeformation;
        _takingCottonCandy.Returned += ProhibitDeformation;
    }

    private void OnDisable()
    {
        _takingCottonCandy.TurnedAround -= AllowDeformation;
        _takingCottonCandy.Returned -= ProhibitDeformation;
    }

    private void Update()
    {
        if (_isDeformed == true)
        {
            StartCoroutine(LeavingTrail());
        }
        else
        {
            StopCoroutine(LeavingTrail());
        }
    }

    private IEnumerator LeavingTrail()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);
        yield return wait;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        var layerMask = LayerMask.GetMask("Cotton");
        float MaxDistanse = 10;
        RaycastHit hit;
        Ray ray = new Ray(transform.position, fwd);
        if (Physics.Raycast(ray, out hit, MaxDistanse, layerMask))
            for (int i = 0; i < _deformationObjects.Length; i++)
            {
                _deformationObjects[i].Deform(hit.point, ray.direction.normalized * _degreeOfDeformation);
            }
    }

    private void AllowDeformation()
    {
        _isDeformed = true;
    }

    private void ProhibitDeformation()
    {
        _isDeformed = false;
    }
}
