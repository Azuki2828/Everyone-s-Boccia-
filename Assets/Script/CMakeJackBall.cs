using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMakeJackBall : MonoBehaviour
{
    //�{�[���N���X�̒萔�B
    Vector3 c_throwPower = new Vector3(-6400.0f, 0.0f, 0.0f);       //�����鋭��
    Vector3 c_fallPower = new Vector3(0.0f, -800.0f, 0.0f);            //�d��
    Vector3 c_startPos = new Vector3(50.0f, 0.0f, 0.0f);           �@ //���W
    Vector3 c_crossPos = new Vector3(-10.0f, 15.0f, 0.0f);             //�N���X�̈ʒu


    public bool m_throwFlg = false;                                        //�n�߂̓��������H
    Rigidbody m_rigidBody = null;                                   //����
    Renderer m_renderer = null;                                     //�����_���[
    GameObject m_Ball = null;                                       //�{�[���Ɏg�p����I�u�W�F�N�g�̃C���X�^���X

    /// <summary>
    /// Update()�֐��̑O�Ɉ�x�����Ă΂��֐��B
    /// </summary>
    void Start()
    {
        //Debug.Log("JackBallReady");
    }

    public void SetThrowFlag(bool isJackAlive)
    {
        m_throwFlg = isJackAlive;
    }

    /// <summary>
    /// �X�V�֐��B
    /// </summary>
    void Update()
    {
        //�܂��������Ă��Ȃ�
        if (!m_throwFlg && Input.GetKeyDown(KeyCode.RightArrow))
        {
            //Resources����{�[����prefab�����[�h�B
            GameObject m_BallInitData = Resources.Load<GameObject>("JackBall");
            //�{�[�����������B�����B
            m_Ball = Instantiate(m_BallInitData);
            //�{�[���̍��̂��擾�B
            m_rigidBody = m_Ball.GetComponent<Rigidbody>();
            //�{�[���̃����_���[���擾�B
            m_renderer = m_Ball.GetComponent<Renderer>();
            //�{�[���̏������W��ݒ�B
            m_Ball.transform.position = c_startPos;
            //�{�[���ɗ͂�^����B
            m_rigidBody.AddForce(c_throwPower);
            m_rigidBody.AddForce(c_fallPower);
            //���������B
            m_throwFlg = true;
        }
    }
}