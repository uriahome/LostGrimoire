using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    public GameObject LookTarget;//見つけたターゲットの座標
    public bool DetectPlayer;//プレイヤーを見つけているかどうか
    // Start is called before the first frame update
    void Start()
    {
        DetectPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)//射程に入った時
    {
        if(collision.gameObject.tag == "Player")
        {
            DetectPlayer = true;
            LookTarget = collision.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collision)//射程外に行ったとき
    {
        if(collision.gameObject.tag == "Player")
        {
            DetectPlayer = false;
            LookTarget = null;
        }   
    }
}
