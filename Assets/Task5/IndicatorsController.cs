using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorsController : MonoBehaviour {
    [SerializeField] private Button startStopButton;
    [SerializeField] private Image indicator1, indicator2;
    [SerializeField] private TextMeshProUGUI timerText1, timerText2;

    private bool isRunning = false;
    private int activeTimer = 1; 

    private void Start() {
        startStopButton.onClick.AddListener(ToggleTimers);
        ResetUI();
    }

    private void ToggleTimers() {
        if (isRunning) {
            isRunning = false;
            StopAllCoroutines();
            ResetUI();
        }
        else {
            isRunning = true;
            startStopButton.GetComponentInChildren<TextMeshProUGUI>().text = "Стоп";
            StartCoroutine(TimerCoroutine(timerText1, indicator1, 1));
            StartCoroutine(TimerCoroutine(timerText2, indicator2, 2));
        }
    }

    private IEnumerator TimerCoroutine(TextMeshProUGUI timerText, Image indicator, int timerId) {
        while (isRunning) {
            indicator.color = Color.red; 
            yield return new WaitUntil(() => activeTimer == timerId); 

            indicator.color = Color.green; 
            int time = Random.Range(10, 21);
            timerText.text = time.ToString();

            while (time > 0 && isRunning) {
                yield return new WaitForSeconds(1f);
                time--;
                timerText.text = time.ToString();
            }

            indicator.color = Color.red; 
            activeTimer = (timerId == 1) ? 2 : 1; 
        }
    }

    private void ResetUI() {
        indicator1.color = Color.yellow;
        indicator2.color = Color.yellow;
        timerText1.text = "0";
        timerText2.text = "0";
        startStopButton.GetComponentInChildren<TextMeshProUGUI>().text = "Старт";
    }
}
