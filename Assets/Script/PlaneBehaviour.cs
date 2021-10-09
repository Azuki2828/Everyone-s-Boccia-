using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBehaviour : MonoBehaviour
{
    //ゲームオブジェクト
    GameObject ob;
    // Start is called before the first frame update
    void Start()
    {
        ob = GameObject.Find("Plane");
    }

    // Update is called once per frame
    void Update()
    {
        var vec = ob.transform.position;
        vec.x += 0.1f;
        ob.transform.position = vec;
    }
}
