using UnityEngine;
using UnityEngine.UI;

public class FinishMovmend : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            winPanel.SetActive(true);
            other.gameObject.SetActive(false);
        }
    }
}
