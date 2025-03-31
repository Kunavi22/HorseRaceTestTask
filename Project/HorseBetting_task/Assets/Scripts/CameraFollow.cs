using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    public Transform target {  set; private get; }  

    public float smoothSpeed = 5f;

    [SerializeField]
    private Transform finishLine;


    private Vector3 initialPosition;


    private void Awake()
    {
        initialPosition = transform.position;
    }

    void LateUpdate()
    {
        if (target == null) return;

        if (finishLine.position.x > target.position.x) target = finishLine;

        // Target position
        Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, transform.position.z);

        // Smoothly move the camera
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

        // Make camera look at the target
        transform.LookAt(target);
    }


    public void ResetCamera()
    {
        transform.position = initialPosition;
        target = null;
    }
}
