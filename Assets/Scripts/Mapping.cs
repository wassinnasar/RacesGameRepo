using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mapping : MonoBehaviour
{
    public Text trackPercentText;
    private int _percents;
    private Vector3 distance;
    private Vector3 currentDistance;
    private float per_cent;
    private float startDis;
    private float currentDis;
    private float check = 0f;
    private float endCheck;
    private float commonDistance;
    private GameObject camera;
    private GameObject punkt;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera");
       punkt = GameObject.Find("Punkt");
        distance = punkt.transform.position - transform.position;
         commonDistance = distance.z * distance.z + distance.x * distance.x;
        startDis = Mathf.Sqrt(commonDistance);
        endCheck = startDis/50;
    }

    // Update is called once per frame
    void Update()
    {
        currentDistance = punkt.transform.position - transform.position;
        float commonCurrentDistance = currentDistance.z * currentDistance.z + currentDistance.x * currentDistance.x;
        currentDis = Mathf.Sqrt(commonCurrentDistance);
      float coveredDis = startDis - currentDis;
        if (commonCurrentDistance <= endCheck)
        {
            endCheck = startDis;
            _percents = 100;
            camera.GetComponent<Timer>().Win();
        }
        else
        {
            per_cent = (coveredDis / startDis) * 100;
            _percents = (int)per_cent;
            if (_percents > 100)
                _percents = 100;
        }
        trackPercentText.text = "Пройденый путь:"+_percents+"%".ToString();
    }
              
}
