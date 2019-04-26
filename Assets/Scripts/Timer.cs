using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float currCountdownValue;
    public float RoundTime;
    public GameObject spawner;
    public AudioMixerSnapshot funLoop;
    public AudioSource soHeSet;
    public Image setOff;
    // Start is called before the first frame update
    void Start()
    {
        currCountdownValue = RoundTime;
        StartCoroutine(StartCountdown(RoundTime));
    }

    public IEnumerator StartCountdown(float countdownValue)
    {
        currCountdownValue = countdownValue;
        while (currCountdownValue > 0)
        {
            if (currCountdownValue <= 40f && currCountdownValue >= 39f)
            {
                soHeSet.Play();
                funLoop.TransitionTo(2.5f);
                //start anim here
                setOff.GetComponent<SoHeSetOff>().ActivateSetOff();
            }

            Debug.Log("this is the time " + currCountdownValue);
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }
        Destroy(spawner);
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log(soHeSet.time);
        }
    }
}
