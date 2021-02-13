using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryRenderer : MonoBehaviour
{   
    [SerializeField]
    private int pointsLength = 30;
    LineRenderer lineRendererComponent;
    // Start is called before the first frame update
    void Start()
    {
        lineRendererComponent = GetComponent<LineRenderer>();
    }
    public void ShowTra(Vector3 origin, Vector3 speed)
    {
        Vector3[] points = new Vector3[pointsLength];
        lineRendererComponent.positionCount = points.Length;
        for (int i = 0; i < points.Length; i++)
        {
            float time = i * 0.1f;
            points[i] = origin + speed * time;
        }
        lineRendererComponent.SetPositions(points);
    }
}
