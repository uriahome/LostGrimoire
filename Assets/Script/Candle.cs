using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;//アニメーションいじる用

public class Candle : MonoBehaviour
{

    [SerializeField] EnemyRange MyEnemyRange;
    [SerializeField] Rigidbody2D rigidbody2d;

    [SerializeField] Vector3 Mypos;//自分の座標
    [SerializeField] Vector3 Playpos;
    [SerializeField] Vector3 Myangle;
    public float MoveSpeed;//移動速度
    public float angle;
    public Vector2 MoveV;

    private AnimatorState state;//animatorの状態管理用
    private Animator animator;

    private static readonly int hashAttack = Animator.StringToHash("candle?attack");
    //private CharacterController cCon;

    // Start is called before the first frame update
    void Start()
    {
        //代入軍団
        animator = GetComponent<Animator>();
        //cCon = GetComponent<CharacterController>();

        MyEnemyRange = this.GetComponentInChildren<EnemyRange>();//子オブジェクトから取得
    }

    // Update is called once per frame
    void Update()
    {
        if (MyEnemyRange.DetectPlayer)//射程に入っているなら動く
        {
            Candle_Move();
        }
        else
        {
            this.animator.SetBool("AttackBool", false);
        }
    }

    void Candle_Move()
    {
        Mypos = transform.position;//自分の座標を代入
        Playpos = MyEnemyRange.LookTarget.transform.position;//playerの座標
        Myangle = Playpos - Mypos;//座標の差
        angle = Mathf.Atan2(Myangle.x, Myangle.y) * Mathf.Rad2Deg;//2点間の角度を求める
        if (Myangle.x < 0)//向きの調整
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);//回転（右向き
            //state.mirror = false;//アニメーションの向きの調整
            animator.Rebind();
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);//回転（左向き
            //state.mirror = true;//アニメーションの向きの調整
            animator.Rebind();
        }

        this.animator.SetBool("AttackBool",true);
        StartCoroutine(AttackAnimation());
    }

    IEnumerator AttackAnimation()
    {
        animator.Play(hashAttack);
        yield return  new WaitForSeconds(0.5f);
    }
}
