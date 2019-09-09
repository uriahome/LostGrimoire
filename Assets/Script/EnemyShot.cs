using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public Rigidbody2D rigid2d;
    public SpriteRenderer Sprite;
    // Start is called before the first frame update
    void Start()
    {
        rigid2d = GetComponent<Rigidbody2D>();
        if (rigid2d.IsSleeping())
        {
            Destroy(this.gameObject);
        }
        Sprite = this.gameObject.GetComponent<SpriteRenderer>();
        Sprite.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (rigid2d.IsSleeping()) {
            Destroy(this.gameObject);
        }
        if(Sprite.enabled == false)
        {
            Sprite_Change();
        }
    }
    public void Sprite_Change()
    {
        Sprite.enabled = true;
    }
    public void Create(float direction,float speed)
    {
        transform.rotation = Quaternion.Euler(0, 0, direction);//回転させる
        //Debug.Log("Create!!!");
        rigid2d = GetComponent<Rigidbody2D>();//rigid2dの取得
        Vector2 v;
        v.x = Mathf.Sin(Mathf.Deg2Rad * direction) * speed;
        v.y = Mathf.Cos(Mathf.Deg2Rad * direction) * speed;
        rigid2d.velocity = v;

        //Spriteの表示関連
        Sprite = this.gameObject.GetComponent<SpriteRenderer>();
        Sprite.enabled = false;
    }

    void OnBecameInvisible()
    {//画面外に出たら消える
        Destroy(this.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
