using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScript : MonoBehaviour
{
    public GameObject mHandler;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Die()
    {
        Destroy(gameObject);
    }

    // What should I call it, Paige fuckin' uhh
    void RunTheMusic()
    {
        mHandler.SetActive(true);
    }
}
