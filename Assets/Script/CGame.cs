using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nsBocciaGame
{
    public enum EnBallState
    {
        enBall_Red,
        enBall_Blue,
        enBall_Jack,

        enBall_Num
    }
    public class CGame : MonoBehaviour
    {
        static readonly int m_playerMaxNum = 2;
        

        private CBall m_ball;                    //ボールクラスのインスタンス
        private nsPlayer.CPlayer[] m_player = new nsPlayer.CPlayer[m_playerMaxNum];     //プレイヤーのインスタンス
        private bool m_ballThrowFlag = false;   //ボールが投げられた？

        private Vector3 m_touchStartPos;        //フリック開始位置
        private Vector3 m_touchEndPos;          //フリック終了位置
        private string m_direction;             //フリック距離
        private bool m_existJackBall = false;   //コート上にジャックボールがある？
        private EnBallState m_ballType = EnBallState.enBall_Jack;     //ボールの種類
        private float m_flameDeltaTime = 1.0f / 60.0f;
        private float m_throwTime = 0.0f;

        // Start is called before the first frame update
        private void Start()
        {
            //ボールのコンポーネントを取得。
            m_ball = GetComponent<CBall>();

            //プレイヤーのコンポーネントを取得。
            for(int playerNum = 0; playerNum< m_playerMaxNum; playerNum++)
            {
                m_player[playerNum] = GetComponent<nsPlayer.CPlayer>();
            }
        }

        // Update is called once per frame
        private void Update()
        {

            

            if (m_ballThrowFlag)
            {
                m_throwTime += m_flameDeltaTime;
                if (m_throwTime > 5.0f)
                {
                    //次に投げるボールの色を決める。
                    NextBall();
                    m_throwTime = 0.0f;

                    //次のボールの投げたフラグを設定。
                    m_ballThrowFlag = false;
                    m_touchStartPos = new Vector3(0.0f, 0.0f, 0.0f);
                    m_touchEndPos = new Vector3(0.0f, 0.0f, 0.0f);
                }
            }

            //フリック入力しているか調査。
            Flick();

        }


        /// <summary>
        /// フリック判定を調べる関数。
        /// </summary>
        private void Flick()
        {
            //開始位置を取得。
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                m_touchStartPos = new Vector3(Input.mousePosition.x,
                                            Input.mousePosition.y,
                                            Input.mousePosition.z);
            }

            //終了位置を取得。
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                m_touchEndPos = new Vector3(Input.mousePosition.x,
                                          Input.mousePosition.y,
                                          Input.mousePosition.z);
            }


            //距離を計算。
            GetDirection();

            //初フリックかつ、上フリックならボールを投げる。
            if(!m_ballThrowFlag && m_direction == "up")
            {

                if (!m_existJackBall)
                {
                    m_ballType = EnBallState.enBall_Jack;
                    m_existJackBall = true;
                }


                //ボールを投げる。
                m_player[0].ThrowBall(m_ballType);

                //ボールを投げた。
                m_ballThrowFlag = true;
            }
        }

        /// <summary>
        /// 次に投げるボールの色を決める関数。
        /// </summary>
        private void NextBall()
        {
            var obj = GameObject.FindGameObjectsWithTag("Ball");

            Vector3 jackBallPos = new Vector3(0.0f, 0.0f, 0.0f);
            float distance = 1000.0f;

            foreach (GameObject ballObj in obj)
            {
                bool jackBallflag = ballObj.GetComponent<CBall>().IsJackBall();

                //ジャックボールだったら
                if (jackBallflag)
                {
                    //ジャックボールの座標を取得。
                    jackBallPos = ballObj.transform.position;
                    break;
                }
            }

            foreach (GameObject ballObj in obj)
            {
                //オブジェクトをBallクラスにキャスト。
                bool jackBallflag = ballObj.GetComponent<CBall>().IsJackBall();

                //ジャックボールじゃなかったら
                if (!jackBallflag)
                {
                    //ジャックボールとの距離を測る。
                    var dis = Vector3.Distance(ballObj.transform.position, jackBallPos);
                    
                    //今まで記録した距離より短かったら更新。
                    if (dis < distance)
                    {
                        
                        //次に投げるボールの色を設定。
                        switch (ballObj.GetComponent<CBall>().GetBallType())
                        {
                            
                            case EnBallState.enBall_Red:
                                m_ballType = EnBallState.enBall_Blue;
                                break;
                            case EnBallState.enBall_Blue:
                                m_ballType = EnBallState.enBall_Red;
                                break;
                        }
                        //距離を更新。
                        distance = dis;
                    }
                }
            }

            if (distance > 999.0f)
            {
                //コート上にはジャックボールしかない。

                //次のボールは赤に設定。
                m_ballType = EnBallState.enBall_Red;
            }
        }
        /// <summary>
        /// フリックの距離を調べる関数。
        /// </summary>
        private void GetDirection()
        {
            float directionX = m_touchEndPos.x - m_touchStartPos.x;
            float directionY = m_touchEndPos.y - m_touchStartPos.y;

            if (Mathf.Abs(directionY) < Mathf.Abs(directionX))
            {
                if (30 < directionX)
                {
                    //右向きにフリック
                    m_direction = "right";
                }
                else if (-30 > directionX)
                {
                    //左向きにフリック
                    m_direction = "left";
                }
            }
            else if (Mathf.Abs(directionX)<Mathf.Abs(directionY))
            {
                if (30 < directionY){
                    //上向きにフリック
                    m_direction = "up";
                }
                else if (-30 > directionY){
                    //下向きにフリック
                    m_direction = "down";
                }
            }
            else
            {
                //タッチを検出
                m_direction = "touch";
            }
        }
    }
}
