using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControeer : MonoBehaviour
{
    /// <summary>�e����ԑ���</summary>
    [SerializeField] float m_speed = 3f;
    /// <summary>�e�̐������ԁi�b�j</summary>
    [SerializeField] float m_lifeTime = 5f;

    void Start()
    {


        // �E�����ɔ�΂�
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * m_speed;
        // �������Ԃ��o�߂����玩�����g��j������
        Destroy(this.gameObject, m_lifeTime);
    }
}
