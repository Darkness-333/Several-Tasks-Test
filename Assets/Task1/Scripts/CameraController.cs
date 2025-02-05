using UnityEngine;

public class CameraController : MonoBehaviour {
    private float minZoom = 5f; 
    private float maxZoom = 12f; 
    private float zoomSpeed = 0.25f; 
    private float rotationSpeed = 0.2f; 
    
    private float startDistance;

    private bool isDraggingChecker = false; 

    void Update() {
        if (isDraggingChecker) return;

        if (Input.touchCount == 1) {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved) {
                float rotationAmount = touch.deltaPosition.x * rotationSpeed;
                transform.RotateAround(Vector3.zero, Vector3.up, rotationAmount);
            }
        }
        else if (Input.touchCount == 2) {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            if (touch1.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began) {
                startDistance = Vector2.Distance(touch1.position, touch2.position);
            }

            if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved) {
                float newDistance = Vector2.Distance(touch1.position, touch2.position);
                float scaleChange = newDistance / startDistance;

                float targetZoom = Mathf.Clamp(transform.position.magnitude / scaleChange, minZoom, maxZoom);
                transform.position = Vector3.Lerp(transform.position, transform.position.normalized * targetZoom, zoomSpeed);
            }
        }
    }

    public void SetDraggingChecker(bool isDragging) {
        isDraggingChecker = isDragging;
    }
}
