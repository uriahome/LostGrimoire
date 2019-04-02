using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField] EnemyRange MyEnemyRange;
    [SerializeField] Rigidbody2D rigidbody2d;

    [SerializeField] Vector3 Mypos;//自分の座標
    [SerializeField] Vector3 Playpos;
    [SerializeField] Vector3 Myangle;
    public float MoveSpeed;//移動速度
    public float angle;
    public Vector2 MoveV;


    // Start is called before the first frame update
    void Start()
    {

        MyEnemyRange = this.GetComponentInChildren<EnemyRange>();//子オブジェクトから取得

    }

    // Update is called once per frame
    void Update()
    {
        if (MyEnemyRange.DetectPlayer)//射程に入っているなら動く
        {
            Ghost_Move();
        }
        else
        {
            rigidbody2d.velocity = new Vector2(0, 0) * 0;//止める
        }
    }

    public void Ghost_Move()
    {
        Mypos = transform.position;//自分の座標を代入
        Playpos = MyEnemyRange.LookTarget.transform.position;//playerの座標
        Myangle = Playpos - Mypos;//座標の差
        angle = Mathf.Atan2(Myangle.x, Myangle.y) * Mathf.Rad2Deg;//2点間の角度を求める
        MoveV.x = Mathf.Cos(angle) * MoveSpeed * -1;//x軸の加速度
        MoveV.y = Mathf.Sin(angle) * MoveSpeed;//y軸の加速度
        rigidbody2d.velocity = MoveV;//加速
        if (Myangle.x < 0)//向きの調整
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);//回転（右向き
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);//回転（左向き
        }
    }
}
