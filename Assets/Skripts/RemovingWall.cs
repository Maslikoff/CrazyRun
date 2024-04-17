using UnityEngine;

public class RemovingWall : MonoBehaviour
{
    [SerializeField] private GameObject wall;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(wall);
        }
    }
}
