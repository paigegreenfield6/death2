using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoHeSetOff : MonoBehaviour
{
    public GameObject player;
    public AudioSource setOff;
    public GameObject replacement;
    Animator anim;
    Image sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<Image>();
        anim = GetComponent<Animator>();
        anim.enabled = false;
        sprite.enabled = false;
    }

    void Update()
    {
        if (setOff.time >= 31 && setOff.time <= 32)
        {
            player.GetComponent<Animator>().SetTrigger("SetOff");
        }

        if (setOff.time >= 40 && setOff.time <= 42)
        {
            player.GetComponent<Animator>().SetTrigger("Final Color");
            
            //Fill with wonder

        }
        if(setOff.time >= 47 && setOff.time <= 48)
        {
            replacement.GetComponent<ReplacementMovement>().leave = true;
        }
        if(setOff.time >= setOff.clip.length - 3f)
        {
            SceneManager.LoadScene("Credits");
        }
    }

    public void ActivateSetOff()
    {
        anim.enabled = true;
        sprite.enabled = true;
    }

    void Done()
    {
        anim.enabled = false;
        sprite.enabled = false;
    }
}
