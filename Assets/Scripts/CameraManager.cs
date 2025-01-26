using System.Collections;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private float minDist = 0.25f;
    [SerializeField] private float maxDist = 2f;
    [SerializeField] private float minSpeed = 0.25f;
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float zoomSpeed = 0.5f;
    [SerializeField] private float zoomAmount = 0.25f;

    [SerializeField] private Transform playerObj;
    [SerializeField] private PlayerMove playerMove;
    [SerializeField] private Camera cam;

    private float dist;
    private float cameraTranslate;

    private float camSize;

    private void Start()
    {
        camSize = cam.orthographicSize;
    }


    private void LateUpdate()
    {
        dist = Vector3.Distance(transform.position, playerObj.position);
        if (dist > minDist)
        {
            cameraTranslate = Mathf.Lerp(minSpeed, maxSpeed, (dist - minDist) / (maxDist - minDist)) * Time.deltaTime;
            if (cameraTranslate < dist)
            {
                transform.Translate(cameraTranslate * (playerObj.position - transform.position).normalized);
            }
            else
            {
                transform.position = playerObj.position;
            }
        }
        else if (!playerMove.IsEnabled)
        {
            playerMove.SetPlayerEnable(true);
        }
    }

    private IEnumerator ZoomOut(float currentSize)
    {
        float t = 0f;
        while (true)
        {
            cam.orthographicSize = Mathf.Lerp(currentSize, camSize, t / zoomSpeed);
            t += Time.deltaTime;
            yield return null;
        }
    }

    public void StartZoom()
    {
        float currentSize = camSize;
        camSize += zoomAmount;
        StopAllCoroutines();
        StartCoroutine(ZoomOut(currentSize));
    }
}
