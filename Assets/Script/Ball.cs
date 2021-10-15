using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ボールクラス
/// </summary>
/// 
public class Ball : MonoBehaviour
{
    //ボールクラスの定数。
    Vector3 c_throwPower = new Vector3(-8000.0f, 100.0f, 0.0f);       //投げる強さ
    Vector3 c_fallPower = new Vector3(0.0f, -800.0f, 0.0f);
    Vector3 c_startPos = new Vector3(50.0f, 10.0f, 0.0f);           //座標


    bool m_throwFlg = false;                                        //投球した？
    Rigidbody m_rigidBody = null;                                   //剛体
    Renderer m_renderer = null;                                     //レンダラー
    GameObject m_redBall = null;                                    //赤ボールに使用するオブジェクトのインスタンス


    /// <summary>
    /// Update()関数の前に一度だけ呼ばれる関数。
    /// </summary>
    void Start()
    {
        Debug.Log("I am alive!");
    }



    /// <summary>
    /// 更新関数。
    /// </summary>
    void Update()
    {
        //まだ投球していなくて、上方向が入力されたら
        if (!m_throwFlg && Input.GetAxis("Vertical") > 0.0f)
        {

            //Resourcesから赤ボールのprefabをロード。
            GameObject m_redBallInitData = Resources.Load<GameObject>("Ball_Red");
            //赤ボールを初期化。生成。
            m_redBall = Instantiate(m_redBallInitData);
            //赤ボールの剛体を取得。
            m_rigidBody = m_redBall.GetComponent<Rigidbody>();
            //赤ボールのレンダラーを取得。
            m_renderer = m_redBall.GetComponent<Renderer>();
            //赤ボールの初期座標を設定。
            m_redBall.transform.position = c_startPos;

            //赤ボールに力を与える。
            m_rigidBody.AddForce(c_throwPower);
            m_rigidBody.AddForce(c_fallPower);
            //投球完了。
            m_throwFlg = true;
        }
    }
}
