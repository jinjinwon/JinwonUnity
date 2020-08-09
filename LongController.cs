using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongController : MonoBehaviour
{
    Transform platform;

    float delta = 0;
    bool play = true;


    // Start is called before the first frame update
    void Start()
    {
        platform = GameObject.Find("platform-long").transform;

    }

    // Update is called once per frame
    void Update()
    {

        delta += Time.deltaTime;
        
        if (play)
        {           
            transform.Translate(0.01f, 0, 0);
            if (delta > 7f)
            {
                play = false;
                delta = 0;
            }
        }
        if (!play)
        {
            transform.Translate(-0.01f, 0, 0);
            if (delta > 7f)
            {
                play = true;
                delta = 0;
            }                   
        }

    }

}
