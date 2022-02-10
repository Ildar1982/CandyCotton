using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Stick : MonoBehaviour
{
    [SerializeField] private StickMove _stickMove;
    [SerializeField] private GameObject _girl;

    public event UnityAction GirlPossesedStick;

    private void OnEnable()
    {
        _stickMove.StoppedFlight += StickTakeGirl;
    }

    private void OnDisable()
    {
        _stickMove.StoppedFlight -= StickTakeGirl;
    }

    private void StickTakeGirl()
    {
        StartCoroutine(Take());
    }
    private IEnumerator Take()
    {
        WaitForSeconds wait = new WaitForSeconds(0.3f);
        yield return wait;
        GameObject parent = FindChild(_girl, "mixamorig:RightHand");
        transform.SetParent(parent.transform);
        transform.localPosition = new Vector3(-0.085f, 0.068f, 0.019f);
        transform.localRotation = Quaternion.Euler(7, 81.6f, 61);
        GirlPossesedStick?.Invoke();
    }

    private GameObject FindChild(GameObject parent, string name)
    {
        Transform[] children = parent.GetComponentsInChildren<Transform>();
        foreach (Transform t in children)
        {
            if (t.gameObject.name == name)
            {
                return t.gameObject;
            }
        }
        return null;
    }
}
