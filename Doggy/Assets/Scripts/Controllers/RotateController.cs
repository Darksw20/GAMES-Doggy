using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateController : MonoBehaviour
{
    public GameObject car;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        car.transform.Rotate(Vector3.forward * 40 * Time.deltaTime);
    }
}
