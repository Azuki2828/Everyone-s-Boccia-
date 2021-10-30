using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CStampMenu : MonoBehaviour
{
    //画像のポジション
    public RectTransform m_pos;
    //移動量
    const float c_move = 1.5f;
    //今メニューバーを開いているか
    bool m_isOpenMenuBar = false;
    //今メニューバーを閉じているか
    bool m_isCloseMenuBar = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool GetIsOpen() { return m_isOpenMenuBar; }
    public bool GetIsClose() { return m_isCloseMenuBar; }

    public void OpenFlagOn()
	{
        //閉じている状態でクリックされた時
        if (m_isCloseMenuBar)
        {
            m_isOpenMenuBar = true;
            m_isCloseMenuBar = false;
        }
        //開いているときにクリックされた時
        else if(m_isOpenMenuBar)
		{
            m_isOpenMenuBar = false;
            m_isCloseMenuBar = true;
        }
	}

    // Update is called once per frame
    void Update()
    {
        //メニューを開く
        if(m_isOpenMenuBar)
		{
            m_pos.position += new Vector3(c_move, 0, 0);
            if(m_pos.position.x >= 500.0f)
			{
                m_pos.position = new Vector3(500, 60, 0);
            }
        }
        //メニューを閉じる
		else if(m_isCloseMenuBar)
		{
            m_pos.position += new Vector3(-c_move, 0, 0);
            if (m_pos.position.x <= 0.0f)
            {
                m_pos.position = new Vector3(0, 60, 0);
            }
        }
    }
}
