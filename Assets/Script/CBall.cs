using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace nsBocciaGame
{
    /// <summary>
    /// ボールクラス
    /// </summary>
    public class CBall : MonoBehaviour
    {
        //ボールクラスの定数。
        static readonly Vector3 c_startPos = new Vector3(50.0f, 5.0f, 0.0f);    //初期座標 
        static readonly float c_maxAngularVelocity = 1000.0f;                   //最大角速度
        private Rigidbody m_rigidBody = null;                                   //剛体
        private Renderer m_renderer = null;                                     //レンダラー
        private GameObject m_ball = null;                                       //ボールオブジェクト
        private bool m_isjackBall = false;                                      //ジャックボール？
        private EnBallState m_ballType = EnBallState.enBall_Jack;               //ボールの種類

        /// <summary>
        /// ボールを生成、投げる関数。
        /// </summary>
        public void ThrowBall(ref Vector3 throwPower,ref float throwVelocity, EnBallState ballColor)
        {
            //Resourcesからボールのprefabをロード。

            GameObject m_redBallInitData = Resources.Load<GameObject>("Ball");
            m_ball = Instantiate(m_redBallInitData);

            //タグの設定。
            m_ball.tag = "Ball";

            //ボールの剛体を取得。
            m_rigidBody = m_ball.GetComponent<Rigidbody>();
            m_rigidBody.maxAngularVelocity = c_maxAngularVelocity;
            //ボールの角速度を設定。
            m_rigidBody.AddTorque(0, 0, throwVelocity, ForceMode.Force);

            //ボールのレンダラーを取得。
            m_renderer = m_ball.GetComponent<Renderer>();
            //ボールの色を設定。
            m_ball.GetComponent<CBall>().m_ballType = ballColor;

            //色を取得、設定。
            switch (m_ball.GetComponent<CBall>().m_ballType)
            {
                case EnBallState.enBall_Red:
                    //赤ボール
                    m_renderer.material.color = Color.red;
                    break;
                case EnBallState.enBall_Blue:
                    //青ボール
                    m_renderer.material.color = Color.blue;
                    break;
                case EnBallState.enBall_Jack:
                    //ジャックボール
                    m_renderer.material.color = Color.white;
                    m_ball.GetComponent<CBall>().m_isjackBall = true;
                    break;
            }

            //ボールの初期座標を設定。
            m_ball.transform.position = c_startPos;

            //ボールに力を与える。
            m_rigidBody.AddForce(throwPower);
        }

        public bool IsJackBall()
        {
            return m_isjackBall;
        }

        /// <summary>
        /// 現在のボールの種類を取得。
        /// </summary>
        /// <returns>ボールの種類</returns>
        public EnBallState GetBallType()
        {
            return m_ballType;
        }
    }
}
