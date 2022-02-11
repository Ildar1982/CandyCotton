using System.Collections;
using UnityEngine;

public class Girl : MonoBehaviour
{
    [SerializeField] private StickMove _stickMove;
    [SerializeField] private StickControl _stickControl;
    [SerializeField] private Animator _animator;
    [SerializeField] private Stick _stick;
    [SerializeField] private GameObject _imageFail;
    [SerializeField] private ParticleSystem _particleLeft;
    [SerializeField] private ParticleSystem _particleRight;
    [SerializeField] private SkinnedMeshRenderer _eyelidLeft;
    [SerializeField] private SkinnedMeshRenderer _eyelidRight;

    private void Start()
    {
        _particleLeft.Stop();
        _particleRight.Stop();
        _eyelidLeft.enabled = false;
        _eyelidRight.enabled = false;
    }

    private void OnEnable()
    {
        _stickMove.StoppedFlight += StickForHand;
        _stick.GirlPossesedStick += Cry;
    }

    private void OnDisable()
    {
        _stickMove.StoppedFlight -= StickForHand;
        _stick.GirlPossesedStick -= Cry;
    }

    private void StickForHand()
    {
        _animator.enabled = true;
        _stickMove.enabled = false;
        _stickControl.enabled = false;       
    }

    private void Cry()
    {
        _particleRight.Play();
        _particleLeft.Play();
        _eyelidLeft.enabled = true;
        _eyelidRight.enabled = true;
        _animator.SetBool("GirlCry", true);
        StartCoroutine(Fail());
    }

    private IEnumerator Fail()
    {
        WaitForSeconds wait = new WaitForSeconds(2f);
        yield return wait;
        _imageFail.SetActive(true);
    }
}
