using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COVerLockingIconGenerator : MonoBehaviour
{
    private bool m_isOverLocking = false;
    GameObject m_overLockingPrefab;
    GameObject m_overLocking;
    private bool m_isCreatedIcon = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChangeOverLockingState()
	{
        m_isOverLocking = !m_isOverLocking;

    }

    // Update is called once per frame
    void Update()
    {
        if(m_isOverLocking && !m_isCreatedIcon)
		{
            GameObject canvas = GameObject.Find("Canvas");
            //上回転画像のPrefabを取得
            m_overLockingPrefab = (GameObject)Resources.Load("OverLockingIcon");
            //画像のインスタンスを生成
            m_overLocking = Instantiate(m_overLockingPrefab, new Vector3(280.0f, 140.0f, 0.0f), Quaternion.identity);
            //キャンバスの子にする。
            m_overLocking.transform.SetParent(canvas.transform, false);
            m_isCreatedIcon = true;
        }
		else if(!m_isOverLocking && m_isCreatedIcon)
		{
            Destroy(m_overLocking);
            m_isCreatedIcon = false;
        }
    }
}
