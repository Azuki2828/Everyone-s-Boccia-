using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nsBocciaGame
{

    public class COutLine : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider collision)
        {
            //ボールと接触したら削除する。
            if (collision.gameObject.tag == "Ball")
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
