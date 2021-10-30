using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPopNiceSprite : MonoBehaviour
{
    bool m_popFlag = false;
    int m_count = 0;
    GameObject m_sprite = null;

    // Start is called before the first frame update
    void Start()
    {
       

        //Debug.Log("sprite ready");
    }

    public void SetPopFlag(bool flag)
	{
        m_popFlag = flag;
	}

    // Update is called once per frame
    void Update()
    {
        if(m_popFlag)
		{
            //Debug.Log("create sprite instance");
            //ゲーム上のキャンバスを取得
            GameObject canvas = GameObject.Find("Canvas");
            //NICEと表示する画像のPrefabを取得
            GameObject obj = (GameObject)Resources.Load("NiceSprite");
            //画像のインスタンスを生成
            GameObject sprite = Instantiate(obj, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
            //キャンバスの子にする。
            sprite.transform.SetParent(canvas.transform, false);
            //1枚以上出さないようにここで状態を変える。
            m_popFlag = false;
		}
    }
}
