using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCar : MonoBehaviour
{
    [SerializeField]
    public Transform car;
    [SerializeField]
    public float speed = 0.2f;
    [SerializeField]
    public Vector3 offset;
    
    // Update is called once per frame
    void Update()
    {
        Vector3 distance = car.position + offset;
        Vector3 smoothed = Vector3.Lerp(transform.position, distance, speed * Time.deltaTime);
        transform.position = smoothed;
        transform.LookAt(car);
    }
}
