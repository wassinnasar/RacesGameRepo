using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CarPosition : MonoBehaviour
{
    private Vector3 currentPosition;
    private Vector3 startPosition;
    [Multiline(10)]
    public string data;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if(startPosition.y > transform.position.y + 1.0f)
        {
            Load();
        }
    }
    public void CollectInfo()
       {
         currentPosition = transform.position;
       }
    public void SetInfo()
      {
        transform.position = currentPosition;
      }
    public void Save()
      {
        CollectInfo();
        data = JsonUtility.ToJson(this,true);
        File.WriteAllText(Application.persistentDataPath + "/carPosition.json", data);
    }
    public void Load()
      {
        data = File.ReadAllText(Application.persistentDataPath + "/carPosition.json");
        JsonUtility.FromJsonOverwrite(data, this);
        SetInfo();
        this.GetComponent<Rigidbody>().isKinematic = true;
        this.transform.eulerAngles = new Vector3(0, 0, 90f);
      }
}
