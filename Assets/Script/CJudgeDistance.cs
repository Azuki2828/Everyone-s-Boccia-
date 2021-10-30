using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CJudgeDistance : MonoBehaviour
{
    float m_prevNearestDistance = 9999.0f;
    GameObject m_nearestBall = null;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Judge()
	{
        //Debug.Log("start judge");
        //ジャックボールを取得
        GameObject jackBall = GameObject.Find("JackBall(Clone)");
        //ボールをすべて取得
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");

        //全てのボールが止まっていなければ処理をスキップ
        foreach (GameObject obs in balls)
        {
            Rigidbody rb = obs.GetComponent<Rigidbody>();
            if (rb.velocity != Vector3.zero)
            {
                return;
            }
        }

        foreach (GameObject obs in balls)
        {
            //全てのボールとジャックボールの距離を測る
            float distance = Vector3.Distance(jackBall.transform.position, obs.transform.position);
            //前回の最短距離よりさらに短いならば
            if (m_prevNearestDistance > distance)
            {
                //最短距離を記録
                m_prevNearestDistance = distance;
                //初めてボールを投げるとき、暫定で最短距離のボールとして保存
                if (m_nearestBall == null)
                {
                    m_nearestBall = obs;

                    //Debug.Log("pop sprite");
                    //キャンバスにあるナイス画像呼び出しを命令
                    GameObject canvas = GameObject.Find("Canvas");
                    canvas.GetComponent<CPopNiceSprite>().SetPopFlag(true);
                    //最短距離のボールとして保存
                    m_nearestBall = obs;



                    return;
                }
                //最短距離にあるボールが更新された時
                if (m_nearestBall != obs)
                {
                    //Debug.Log("pop sprite");
                    ////キャンバスにあるナイス画像呼び出しを命令
                    //GameObject canvas = GameObject.Find("Canvas");
                    //canvas.GetComponent<PopNiceSprite>().SetPopFlag(true);
                    ////最短距離のボールとして保存
                    //nearestBall = obs;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
