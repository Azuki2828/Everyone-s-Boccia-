using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CJackBehaviour : MonoBehaviour
{
    Vector3 c_crossPos = new Vector3(-10.0f, 15.0f, 0.0f);             //クロスの位置

    bool m_throwFlg = false;                                        //始めの投球した？
    bool m_flag = false;
   
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("jack is comin");
    }

    //コートから出たとき
    void OnTriggerExit(Collider other)
    {
        //ジャックボールのインスタンスを取得
        GameObject go = GameObject.Find("JackBall(Clone)");
        //通常のコートから出たとき
        if (other.gameObject.tag == "NormalArea")
        {
            //ジャックボールの初回スローが終わっているならば
            if (m_throwFlg)
            {
                //ボールの速度と回転を無くす
                Rigidbody rb = GetComponent<Rigidbody>();
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                //クロスの位置に戻す
                go.transform.position = c_crossPos;
                //Debug.Log("AwayFromCourt");
            }
        }
        //初回にジャックボールを着地させなければいけないエリアから出たとき
        else if (other.gameObject.tag == "FirstJack")
        {
            if (!m_throwFlg)
            {
                Destroy(go);
                //Debug.Log("i died_1");
                GameObject court = GameObject.Find("Court");
                court.GetComponent<CMakeJackBall>().SetThrowFlag(false);
            }
        }
    }

    //エリアに入っている間呼ばれる
    void OnTriggerStay(Collider other)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        //ジャックボール用の領域内ならば
        if (other.gameObject.tag == "FirstJack"
            || other.gameObject.tag == "FirstJack_triangle")
        {
            //Debug.Log("OnJackArea");

            //そこで速度がなくなった＝止まったなら
            if (rb.velocity == Vector3.zero)
            {
                //投げは成功した。
                m_throwFlg = true;
                //Debug.Log("Success Jack");

                //呼び出すところを考える
                m_flag = true;
                if (m_flag)
                {
                    GameObject court = GameObject.Find("Court");
                    court.GetComponent<CJudgeDistance>().Judge();
                }
            }
        }
		//ジャックボールの領域でなく、通常範囲の中だった時（手前のエリア）
		if(other.gameObject.tag == "FirstJackNonActiveArea") { 
            //それが初回スローの時
            if (!m_throwFlg && rb.velocity == Vector3.zero)
            {
                GameObject go = GameObject.Find("JackBall(Clone)");
                Destroy(go);
                //Debug.Log("i died_2");
                GameObject court = GameObject.Find("Court");
                court.GetComponent<CMakeJackBall>().SetThrowFlag(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {


    }
}
