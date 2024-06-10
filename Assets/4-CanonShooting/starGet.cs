using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starGet : MonoBehaviour
{
    float time;
    [SerializeField] float timer = 2f;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();

    }

    // Update is called once per frame
    void Update()
    {
       time = time + Time.deltaTime;
        if(time > timer)
        {
            Destroy(gameObject);
        }
     
        
    }
}
