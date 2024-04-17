using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageTimer : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private Image timerImage;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject winPanel;

    private float _timeLeft = 0f;

    private void Start()
    {
        _timeLeft = time;
        StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        while (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            var normalizedValue = Mathf.Clamp(_timeLeft / time, 0.0f, 1.0f);
            timerImage.fillAmount = normalizedValue;

            if (!winPanel)
            {
                if (_timeLeft < 0)
                {
                    losePanel.SetActive(true);
                    Time.timeScale = 0;
                }
            }
            yield return null;
        }
    }

}
