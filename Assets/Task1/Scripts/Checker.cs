using UnityEngine;

public class Checker : MonoBehaviour {
    private bool isDragging = false;
    private Camera cam;
    private CameraController cameraController;

    private void Start() {
        cam = Camera.main;
        cameraController = cam.GetComponent<CameraController>();
    }

    void OnMouseDown() {
        isDragging = true;
        cameraController.SetDraggingChecker(true);
    }

    void OnMouseDrag() {
        if (isDragging) {
            Vector3 newPosition = GetMouseWorldPosition();
            newPosition.y = 0.35f;
            transform.position = newPosition;
        }
    }

    void OnMouseUp() {
        isDragging = false;
        cameraController.SetDraggingChecker(false);
    }

    private Vector3 GetMouseWorldPosition() {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.up * 0.25f);
        plane.Raycast(ray, out float distance);
        return ray.GetPoint(distance);
    }
}
