using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private float maxDist = 2f;
    [SerializeField] private float cameraSpeed = 1f;
    [SerializeField] private float minDist = 0.25f;
    [SerializeField] private Transform playerObj;

    float dist;

    private void Update()
    {
        dist = Vector3.Distance(transform.position, playerObj.position);
        if (dist > minDist)
        {
            dist = Mathf.Clamp(0f, maxDist, dist);
            cameraSpeed = Mathf.Lerp(0f, cameraSpeed, dist / maxDist);
            transform.Translate(Time.deltaTime * cameraSpeed * (playerObj.position - transform.position).normalized);
        }
    }
}
