using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float Smoothing = .1f;
    private Vector3 finalp = Vector3.zero;


    void LateUpdate()
    {
        finalp = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, finalp, Smoothing * Time.deltaTime);
    }
}
