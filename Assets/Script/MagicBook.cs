using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBook : MonoBehaviour
{
    public string MagicWord;//この本の名前

    public float MutekiTime;
    public float NowTime;


    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<BoxCollider2D>().enabled = false;
        NowTime = 0;
        MutekiTime = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        NowTime += Time.deltaTime;
        if(NowTime >= MutekiTime)
        {
            this.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
