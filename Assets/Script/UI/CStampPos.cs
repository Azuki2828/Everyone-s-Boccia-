using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CStampPos : MonoBehaviour
{
    //画像のポジション
    public RectTransform m_pos;
    //移動量
    const float c_move = 1.5f;
    //1フレーム前のメニューバーの座標
    Vector3 m_prevMenuBarPos = new Vector3(0.0f, 0.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        GameObject stampMenuBar = GameObject.Find("StampMenuBar");
        m_prevMenuBarPos = stampMenuBar.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject menuBar = GameObject.Find("StampMenuBar");
        //bool isOpen; menuBar.GetComponent<StampMenu>().GetIsOpen();
        //bool isClose; menuBar.GetComponent<StampMenu>().GetIsClose();

        /*

        //メニューを開く
        if (isOpen)
        {
            pos.position += new Vector3(move, 0, 0);
            if (pos.position.x >= 500.0f)
            {
                pos.position = new Vector3(500, 60, 0);
            }
        }
        //メニューを閉じる
        else if (isClose)
        {
            pos.position += new Vector3(-move, 0, 0);
            if (pos.position.x <= 0.0f)
            {
                pos.position = new Vector3(0, 60, 0);
            }
        }
        */

       

        GameObject stampMenuBar = GameObject.Find("StampMenuBar");

        //現在のメニューバーの位置を取得
        Vector3 stampMoveSpeed = stampMenuBar.transform.position - m_prevMenuBarPos;

        m_pos.position += stampMoveSpeed;

        m_prevMenuBarPos = stampMenuBar.transform.position; ;
    }
}
