using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBox : MonoBehaviour
{
    public int Hp = 1;
    public bool ItemCheck;//何かアイテムが入っているかチェックするよう
    public int ItemNumber;//アイテムの種類（入っている場合のみ使うかも？）
    public GameObject[] Items;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Hp <= 0)
        {
            if (ItemCheck)//何かアイテムがあるならここに出す
            {
                Instantiate(Items[ItemNumber], this.transform.position, Quaternion.identity);
            }
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Shot")//自キャラのショットに当たったら～
        {
            Hp--;
        }
    }
}
