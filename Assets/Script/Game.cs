using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nsBocciaGame
{
    public enum EnBall
    {
        enBall_Red,
        enBall_Blue,

        enBall_Num
    }
    public class Game : MonoBehaviour
    {
        
        Vector3 m_throwPower = new Vector3(-2000.0f, 0.0f, 0.0f);       //投げる強さ
        float m_throwVelocity = 1000.0f;                                //ボールに与える回転力

        private Ball m_ball;                    //ボールクラスのインスタンス
        private bool m_getKeyFlag = false;      //キーが押されている？

        private Vector3 m_touchStartPos;        //フリック開始位置
        private Vector3 m_touchEndPos;          //フリック終了位置
        private string m_direction;             //フリック距離


        // Start is called before the first frame update
        private void Start()
        {
            //ボールのコンポーネントを取得。
            m_ball = GetComponent<Ball>();
        }

        // Update is called once per frame
        private void Update()
        {

            //フリック入力しているか調査。
            Flick();
        }

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
            if(!m_getKeyFlag && m_direction == "up")
            {
                //ボールの色を設定。
                var ballColor = EnBall.enBall_Red;

                //ボールを投げる。
                m_ball.ThrowBall(ref m_throwPower, ref m_throwVelocity, ballColor);

                //ボールを投げた。
                m_getKeyFlag = true;
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
