using UnityEngine;

/// <summary>
/// 砲台 (Canon) を制御するコンポーネント
/// </summary>
public class CanonController : MonoBehaviour
{
    /// <summary>砲弾として生成するプレハブ</summary>
    [SerializeField] GameObject m_shellPrefab = default;
    /// <summary>砲口を指定する</summary>
    [SerializeField] Transform m_muzzle = default;
    AudioSource m_audio = default;
    [SerializeField]GameObject reticle = default;
    Vector2 posi = Vector2.zero;
    [SerializeField] float time = 1f;
    float m_timer;

    void Start()
    {
        m_audio = GetComponent<AudioSource>();
        m_timer = time;
    }

    void Update()
    {
        posi =  reticle.transform.position - transform.position;
        gameObject.transform.up = posi;
        m_timer += Time.deltaTime;


        if (Input.GetButtonDown("Fire1") && m_timer > time )
        {

            m_timer = 0;
          
            
           
            
            m_audio.Play();
            Instantiate(m_shellPrefab, m_muzzle.position, this.transform.rotation);
        }
    }
}
