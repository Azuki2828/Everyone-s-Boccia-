using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nsBocciaGame {

    namespace nsPlayer
    {

        public class CPlayer : MonoBehaviour
        {
            private static readonly int c_maxBallNum = 6;               //プレイヤーが所持できるボールの数
            private CBall[] m_ball = new CBall[c_maxBallNum];           //ボールのインスタンス
            private int m_ballNum = 0;                                  //自分が使えるボールの番号(0～5)
            private Vector3 m_throwPower = new Vector3(-1000.0f, 0.0f, 0.0f);       //投げる強さ
            private float m_throwVelocity = 1000.0f;                                //ボールに与える回転力

            // Start is called before the first frame update
            void Start()
            {
                //ボールクラスのコンポーネントを取得。
                for(int ballNum = 0; ballNum < c_maxBallNum; ballNum++)
                {
                    m_ball[ballNum] = GetComponent<CBall>();
                }
            }

            // Update is called once per frame
            void Update()
            {

            }


            /// <summary>
            /// ボールを投げる関数。
            /// </summary>
            /// <param name="ballColor">ボールの種類</param>
            public void ThrowBall(EnBallState ballColor)
            {
                //ボールを投げる関数。
                m_ball[m_ballNum].ThrowBall(ref m_throwPower, ref m_throwVelocity, ballColor);
            }
        }    
    }
}
