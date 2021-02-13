using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarDriver : MonoBehaviour
{
    private bool itsDown;
    public TrajectoryRenderer tra;
    public GameObject trajectory;
    private RaycastHit hit;
    private Rigidbody rb;
    private float Height;
    private float StartTouchHeight;
    private float FinaleTouchHeight;
    private Vector3 speed;
    private float percentage;
    private int percent;
    [SerializeField]
    private Text textPercent;
    private Vector3 stopPosition;
    private bool isStop = true;
    private GameObject camera;
    [SerializeField]
    private int numberToMultiplyPower = 3;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera");
        rb = GetComponent<Rigidbody>();
        Height = Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == stopPosition)
        {
            isStop = true;
        }
        stopPosition = transform.position;
        if (isStop)
        {
            if (Input.GetMouseButtonDown(0))
            {
                itsDown = true;
                StartTouchHeight = Input.mousePosition.y;
                this.GetComponent<Rigidbody>().isKinematic = false;
                this.GetComponent<CarPosition>().Save();
                camera.GetComponent<Timer>().StartTime();
            }
            if (itsDown)
            {
                FinaleTouchHeight = StartTouchHeight - Input.mousePosition.y;
                percentage = (FinaleTouchHeight / (Height/2)) * 100;
                percent = (int)percentage;
                if (percent > 100)
                    percent = 100;
                Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit);
                if (transform.position.z > hit.point.z)
                {
                    speed = (hit.point - transform.position);
                    trajectory.SetActive(true);
                    tra.ShowTra(transform.position, -speed);
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                float power = percent * numberToMultiplyPower;
                itsDown = false;
                rb.AddForce(-speed * power);
                trajectory.SetActive(false);
                isStop = false;
                percent = 0;
            }
        }
        textPercent.text = "Сила натяжения:"+percent.ToString();
    }
}
