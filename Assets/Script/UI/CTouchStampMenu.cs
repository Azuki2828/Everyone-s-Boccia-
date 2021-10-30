using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTouchStampMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
	/// クリックされたときのメニューバー挙動制御
	/// </summary>
    public void StampBarClicked()
	{
        GameObject controller = GameObject.Find("UIController");
        controller.GetComponent<CStampMenu>().OpenFlagOn();
        //Debug.Log("clicked");



        //todo　プレイヤーが投げるシーンに遷移した時にこの関数を呼び出すようにすること
        controller.GetComponent<CSpinIconGenerator>().ChangeThrowSceneState();
        controller.GetComponent<COVerLockingIconGenerator>().ChangeOverLockingState();
    }
}
