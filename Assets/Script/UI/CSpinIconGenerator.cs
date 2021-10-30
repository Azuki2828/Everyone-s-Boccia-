using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSpinIconGenerator : MonoBehaviour
{
    private bool m_isThrowScene = false;
    private bool m_isCreatedIcon = false;


    GameObject upSpritePrefab;
    GameObject upSprite;
    GameObject downSpritePrefab;
    GameObject downSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChangeThrowSceneState()
	{
        m_isThrowScene = !m_isThrowScene;
	}

    // Update is called once per frame
    void Update()
    {
        //スローシーンに入ったら1つインスタンスをプレハブから作る
        if (m_isThrowScene && !m_isCreatedIcon)
        {
            //1枚目（上回転画像のインスタンスを作成）
            //ゲーム上のキャンバスを取得
            GameObject canvas = GameObject.Find("Canvas");
            //上回転画像のPrefabを取得
            upSpritePrefab = (GameObject)Resources.Load("SpinIcon");
            //画像のインスタンスを生成
            upSprite = Instantiate(upSpritePrefab, new Vector3(-280.0f, 140.0f, 0.0f), Quaternion.identity);
            //キャンバスの子にする。
            upSprite.transform.SetParent(canvas.transform, false);

            //2枚目（下回転画像のインスタンスを作成）
            //下回転画像のPrefabを取得
            downSpritePrefab = (GameObject)Resources.Load("SpinIcon");
            //画像のインスタンスを生成
            downSprite = Instantiate(downSpritePrefab, new Vector3(-280.0f, 100.0f, 0.0f), Quaternion.identity);
            //キャンバスの子にする。
            downSprite.transform.SetParent(canvas.transform, false);
            //1枚以上出さないようにここで状態を変える。
            m_isCreatedIcon = true;
        }
        //スローシーンじゃなくなり、回転の画像2枚がすでに出ている状況ならば
        else if(!m_isThrowScene && m_isCreatedIcon)
		{
            //画像を破棄
            Destroy(upSprite);
            Destroy(downSprite);
            m_isCreatedIcon = false;
        }
    }
}
