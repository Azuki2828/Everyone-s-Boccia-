using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COverLockingState : MonoBehaviour
{
    private bool m_isOverLocking = false;
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
        //俯瞰視点のインスタンスを探してONOFFする
    }
}
