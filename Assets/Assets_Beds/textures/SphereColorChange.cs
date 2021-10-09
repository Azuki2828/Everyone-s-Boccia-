using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereColorChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var r = gameObject.GetComponent<Renderer>();
        r.material.color = Color.cyan;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
