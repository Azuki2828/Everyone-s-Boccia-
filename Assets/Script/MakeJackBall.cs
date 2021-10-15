using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeJackBall : MonoBehaviour
{
    //ボールクラスの定数。
    Vector3 c_throwPower = new Vector3(-6400.0f, 0.0f, 0.0f);       //投げる強さ
    Vector3 c_fallPower = new Vector3(0.0f, -800.0f, 0.0f);            //重力
    Vector3 c_startPos = new Vector3(50.0f, 0.0f, 0.0f);           　 //座標
    Vector3 c_crossPos = new Vector3(-10.0f, 15.0f, 0.0f);             //クロスの位置


    public bool m_throwFlg = false;                                        //始めの投球した？
    Rigidbody m_rigidBody = null;                                   //剛体
    Renderer m_renderer = null;                                     //レンダラー
    GameObject m_Ball = null;                                       //ボールに使用するオブジェクトのインスタンス

    /// <summary>
    /// Update()関数の前に一度だけ呼ばれる関数。
    /// </summary>
    void Start()
    {
        Debug.Log("JackBallReady");
    }

    public void SetThrowFlag(bool isJackAlive)
	{
        m_throwFlg = isJackAlive;
    }

    /// <summary>
    /// 更新関数。
    /// </summary>
    void Update()
    {
        //まだ投球していない
        if (!m_throwFlg && Input.GetKeyDown(KeyCode.RightArrow))
        {
            //Resourcesからボールのprefabをロード。
            GameObject m_BallInitData = Resources.Load<GameObject>("JackBall");
            //ボールを初期化。生成。
            m_Ball = Instantiate(m_BallInitData);
            //ボールの剛体を取得。
            m_rigidBody = m_Ball.GetComponent<Rigidbody>();
            //ボールのレンダラーを取得。
            m_renderer = m_Ball.GetComponent<Renderer>();
            //ボールの初期座標を設定。
            m_Ball.transform.position = c_startPos;
            //ボールに力を与える。
            m_rigidBody.AddForce(c_throwPower);
            m_rigidBody.AddForce(c_fallPower);
            //投球完了。
            m_throwFlg = true;
        }
    }
}