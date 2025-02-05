using TMPro;
using UnityEngine;

public class ApplicationFPS : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI fpsText;

    private void Start() {
        Application.targetFrameRate = 1000;
    }

    private void Update() {
        fpsText.SetText((Mathf.Round(1 / Time.deltaTime)).ToString());
    }
}