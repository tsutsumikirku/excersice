using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControeer : MonoBehaviour
{
    /// <summary>’e‚ª”ò‚Ô‘¬‚³</summary>
    [SerializeField] float m_speed = 3f;
    /// <summary>’e‚Ì¶‘¶ŠúŠÔi•bj</summary>
    [SerializeField] float m_lifeTime = 5f;

    void Start()
    {


        // ‰E•ûŒü‚É”ò‚Î‚·
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * m_speed;
        // ¶‘¶ŠúŠÔ‚ªŒo‰ß‚µ‚½‚ç©•ª©g‚ğ”jŠü‚·‚é
        Destroy(this.gameObject, m_lifeTime);
    }
}
