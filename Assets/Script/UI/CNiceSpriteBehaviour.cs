using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CNiceSpriteBehaviour : MonoBehaviour
{
    public GameObject m_go;
    Vector3 m_scale = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 c_expandRate = new Vector3(0.001f, 0.001f, 0.001f);

    // Start is called before the first frame update
    void Start()
    {
        //m_go = GameObject.Find("NiceSprite(Clone)");
    }

    // Update is called once per frame
    void Update()
    {
        m_scale += c_expandRate;
        m_go.transform.localScale = m_scale;
        Destroy(m_go, 2.0f);
    }
}
