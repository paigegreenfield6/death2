using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameObject player;
    bool fallen;
    bool imActive;
    float point;
    public GameObject music;
    bool collected = false;
    MusicHandling mH;

    void Start()
    {
        imActive = false;
        fallen = false;
        collected = false;
        GetComponent<SpriteRenderer>().enabled = false;
        point = Random.Range(1f, 7.3f);
        Debug.Log("point is " + point);
        mH = music.GetComponent<MusicHandling>();
        GetComponent<Animator>().SetFloat("Blend", Random.Range(-2f, 2f));
    }

    void Update()
    {
        if(mH.panningDown)
        {
            imActive = true;
            GetComponent<SpriteRenderer>().enabled = true;
        }
        if (!fallen && imActive)
        {
            transform.Translate(Vector3.down *0.05f, Space.World);
            if(transform.position.y <= point)
            {
                Debug.Log("it happened!");
                fallen = true;
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && !collected)
        {
            Debug.Log("snatched");
            player = col.gameObject;
            collected = true; 
            transform.parent = player.transform;
            transform.position = player.transform.position + new Vector3(2f, 0f);
            GetComponent<Animator>().SetTrigger("Collected");
            player.GetComponent<PlayerCollection>().addCollectable(gameObject);
            //Destroy(gameObject);
            //col.GetComponent<NewMove>().hasBoost = true;
        }
    }
}
