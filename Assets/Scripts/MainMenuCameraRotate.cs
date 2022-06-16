using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCameraRotate : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [SerializeField] GameObject pivotPoint;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(pivotPoint.transform.position, new Vector3(0, 1, 0), rotationSpeed * Time.deltaTime);
    }
}
