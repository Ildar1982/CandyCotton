using UnityEngine;

public class ShowImages : MonoBehaviour
{
    [SerializeField] private GameObject[] _images;

    private int _index;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent<Winding>(out Winding winding))
        {
            _index = Random.Range(0, _images.Length);
            _images[_index].SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.TryGetComponent<Winding>(out Winding winding))
        {
            for (int i = 0; i < _images.Length; i++)
            {
                _images[i].SetActive(false);
            }
        }
    }
}
