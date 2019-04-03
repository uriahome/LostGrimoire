using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;//アニメーションいじる用

public class Candle1 : MonoBehaviour
{

    [SerializeField] EnemyRange MyEnemyRange;
    [SerializeField] Rigidbody2D rigidbody2d;

    [SerializeField] Vector3 Mypos;//自分の座標
    [SerializeField] Vector3 Playpos;
    [SerializeField] Vector3 Myangle;
    public float MoveSpeed;//移動速度
    public float angle;
    public Vector2 MoveV;
    public bool AttackCheck = false;

    private AnimatorState state;//animatorの状態管理用
    private Animator animator;

    //public static readonly int hashAttack = Animator.StringToHash("candle_attack");
    //private CharacterController cCon;
    public GameObject CandleShot;
    public GameObject NowEnemyShot;
    public float ShotSpeed;


    public float ShotSpan = 0.5f;//攻撃間隔
    public float NowTime = 0;//経過時間


    // Start is called before the first frame update
    void Start()
    {
        AttackCheck = false;
        //代入軍団
        animator = GetComponent<Animator>();
        //cCon = GetComponent<CharacterController>();

        MyEnemyRange = this.GetComponentInChildren<EnemyRange>();//子オブジェクトから取得
        StartCoroutine(Candle_Attack());
    }

    // Update is called once per frame
    void Update()
    {
        if (MyEnemyRange.DetectPlayer)//射程に入っているなら動く
        {
            //Candle_Move();
            /* if (!AttackCheck)
             {
                 AttackCheck = true;
                 StartCoroutine(AttackAnimation());
             }*/
            StartCoroutine(AttackInterval());
            //StartCoroutine(Candle_Attack());
        }
        else
        {
            //this.animator.SetBool("AttackBool", false);
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
                                                           //   animator.Rebind();
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);//回転（左向き
                                                             //state.mirror = true;//アニメーションの向きの調整
                                                             // animator.Rebind();
        }
       /* NowTime += Time.deltaTime;
        if (ShotSpan <= NowTime)
        {
            NowTime = 0;
            NowEnemyShot = Instantiate(CandleShot, this.transform.position, this.transform.rotation) as GameObject;
            if (CandleShot != null)
            {
                EnemyShot S = NowEnemyShot.GetComponent<EnemyShot>();
                S.Create(angle, ShotSpeed);
            }
            //this.animator.SetTrigger("AttackTrigger");
            //StartCoroutine(AttackAnimation());
        }*/
    }

 /*   void Candle_Attack()
    {
        NowEnemyShot = Instantiate(CandleShot, this.transform.position, this.transform.rotation) as GameObject;
        if (CandleShot != null)
        {
            EnemyShot S = NowEnemyShot.GetComponent<EnemyShot>();
            S.Create(angle,ShotSpeed);
        }
    }*/
    IEnumerator Candle_Attack()
    {
        while (true)
        {
            NowEnemyShot = Instantiate(CandleShot, this.transform.position, this.transform.rotation) as GameObject;
            if (CandleShot != null)
            {
                EnemyShot S = NowEnemyShot.GetComponent<EnemyShot>();
                S.Create(angle, ShotSpeed);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

  /*  IEnumerator AttackAnimation()
    {
     //   Debug.Log("nyaa");
      //  Candle_Move();
      //  animator.Play(hashAttack);
      //  AttackCheck = false;
        yield return new WaitForSeconds(1f);
        yield break;
    }
    */
    IEnumerator AttackInterval()
    {

        animator.SetBool("AttackBool", true);
        // Candle_Attack();
        Candle_Move();
        yield return new WaitForSeconds(3f);
        animator.SetBool("AttackBool", false);
        //StartCoroutine(AttackAnimation());
    }
}
