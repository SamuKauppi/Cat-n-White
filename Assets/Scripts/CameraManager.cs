using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private float maxDist = 2f;
    [SerializeField] private float cameraSpeed = 1f;
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float minDist = 0.25f;
    [SerializeField] private Transform playerObj;

    float dist;

    private void LateUpdate()
    {
        dist = Vector3.Distance(transform.position, playerObj.position);
        Debug.Log(dist);
        if (dist > minDist)
        {
            cameraSpeed = Mathf.Lerp(0f, maxSpeed, (dist - minDist) / (maxDist - minDist)) * Time.deltaTime;
            Debug.Log(Mathf.Lerp(0f, maxSpeed, (dist - minDist) / (maxDist - minDist)));
            if (cameraSpeed < dist)
            {
                transform.Translate(cameraSpeed * (playerObj.position - transform.position).normalized);
            }
        }
    }
}
