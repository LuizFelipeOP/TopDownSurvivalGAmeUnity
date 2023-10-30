using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothTime = .3f;
    public Vector3 offset;
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null) {
            Vector3 targetPosition = target.position + offset;

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
            if (Input.GetMouseButton(1)){
                moveCameraToCursor(targetPosition);
            }

        }
    }
    public void moveCameraToCursor(Vector3 targetPosition)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 desiredPosition;

        if (Physics.Raycast(ray, out hit))
        {
            desiredPosition = hit.point;
        }
        else
        {
            desiredPosition = transform.position;

        }
        float distance = Vector3.Distance(desiredPosition, targetPosition);
        Vector3 direction = Vector3.Normalize(desiredPosition - targetPosition);

        transform.position += direction / 20;
    }
}
