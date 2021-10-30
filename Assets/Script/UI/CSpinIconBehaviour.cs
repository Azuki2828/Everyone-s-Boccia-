using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSpinIconBehaviour : MonoBehaviour
{
    private bool m_isThrowScene = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ここで今投げようとしているボールのインスタンスを探してきて
        //回転の数値を上げ下げする関数を呼び出す

        GameObject controller = GameObject.Find("UIController");
        controller.GetComponent<CStampMenu>().OpenFlagOn();
        //Debug.Log("clicked");
    }
}
