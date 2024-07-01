using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{

    public float panSpeed = 20f;             // Velocidad de panning
    public float zoomSpeed = 5f;             // Velocidad de zoom
    public float minZoom = 5f;               // Mínimo nivel de zoom
    public float maxZoom = 20f;              // Máximo nivel de zoom
    public Vector2 panLimitMin;              // Límites mínimos para panning (x, y)
    public Vector2 panLimitMax;              // Límites máximos para panning (x, y)
    public  bool    active = true;
    private Camera cam;

    void Start()
    {
        cam = Camera.main; // Obtener la cámara principal
    }

    void    limits()
    {
        panSpeed = Mathf.Lerp(20, 300, cam.orthographicSize / maxZoom);
    }

    void Update()
    {
        if (active)
        {
            HandlePan();
            HandleZoom();
            limits();
        }
    }

    void HandlePan()
    {
        if (Input.GetMouseButton(1)) // Botón derecho del ratón para panning
        {
            float h = -Input.GetAxis("Mouse X") * panSpeed * Time.deltaTime;
            float v = -Input.GetAxis("Mouse Y") * panSpeed * Time.deltaTime;

            Vector3 newPosition = transform.position + new Vector3(h, 0, v);

            // Limitar el panning a los límites definidos
            newPosition.x = Mathf.Clamp(newPosition.x, panLimitMin.x, panLimitMax.x);
            newPosition.z = Mathf.Clamp(newPosition.z, panLimitMin.y, panLimitMax.y);
            newPosition.y = 110;

            transform.position = newPosition;
        }
    }

    void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        float newZoom = cam.orthographicSize - scroll * zoomSpeed;
        cam.orthographicSize = Mathf.Clamp(newZoom, minZoom, maxZoom);
    }
}
