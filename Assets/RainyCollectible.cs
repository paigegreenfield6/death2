using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainyCollectible : MonoBehaviour
{
    public GameObject player;
    bool fallen;
    float point;

    bool collected;
    public float speed;
    private Vector3 zAxis = new Vector3(0, 0, 1);
    // Start is called before the first frame update
    void Start()
    {
        fallen = false;
        collected = false;
        speed = 2f;
        point = Random.Range(-5f, 6.8f);
        GetComponent<Animator>().SetFloat("Blend", Random.Range(-2f, 2f));
    }

    // Update is called once per frame
    void Update()
    {
        if (!fallen)
        {
            transform.Translate(Vector3.down * 0.05f, Space.World);
            if (transform.position.y <= point)
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
            fallen = true;
            player = col.gameObject;
            Debug.Log("snatched");
            collected = true;
            GetComponent<Animator>().SetTrigger("Collected");
            transform.parent = player.transform;
            transform.position = player.transform.position + new Vector3(2f, 0f);
            player.GetComponent<PlayerCollection>().addCollectable(gameObject);
            //Destroy(gameObject);

        }
    }
}