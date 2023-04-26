using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float distanceBehindObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CameraFollow();
    }

    private void CameraFollow()
    {
        Vector3 cameraPosition = target.transform.position + new Vector3(0f, 1f, -2f) * distanceBehindObject;
        transform.position = cameraPosition;

        transform.LookAt(target.transform);
    }
}