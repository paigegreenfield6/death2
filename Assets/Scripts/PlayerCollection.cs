using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollection : MonoBehaviour
{
    GameObject[] collectableList;
    int size;
    public GameObject replacement;
    // Start is called before the first frame update
    void Start()
    {
        collectableList = new GameObject[5];
        size = 0;
        
    }

    public Color readColor()
    {
        float r = 0;
        float g = 0;
        float b = 0;
        float blen = 0;

        for (int x = 0; x < size; x++)
        {
            blen = collectableList[x].GetComponent<Animator>().GetFloat("Blend");
            if (blen <= -.5f) {
                r += .3f;

            } else if (blen <= .5f)
            {
                g += .3f;

            } else
            {
                b += .3f;

            }
        }
        Debug.LogError("HERE'S THE RED " + r + " and here's the GREEN " + g + "and BLUH :" + b);

        return new Color(r, g, b, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void updateColor()
    {
        replacement.SetActive(true);
        replacement.transform.position = transform.position;
        replacement.GetComponent<SpriteRenderer>().color = readColor();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<PlayerMovement>().controlsEnabled = false;
        replacement.GetComponent<Animator>().SetTrigger("Leave");
        for (int x = 0; x < size; x++)
        {
            Destroy(collectableList[x]);
        }
    }

    public void addCollectable(GameObject collect)
    {
        if (size < collectableList.Length)
        {
            collectableList[size] = collect;
            size++;
        } else
        {
            Destroy(collectableList[size - 1]);

            for (int x = size - 1; x > 0; x--)
            {
                collectableList[x] = collectableList[x - 1];
            }
            //Debug.LogError("Don't do itttt" + size);
            collectableList[0] = collect;
        }
        
    }
}
