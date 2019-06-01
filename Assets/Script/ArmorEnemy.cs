using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorEnemy : MonoBehaviour
{
    [SerializeField] EnemyRange MyEnemyRange;
    [SerializeField] Rigidbody2D rigidbody2d;
    [SerializeField] Sprite[] ArmorSprite;
    [SerializeField] SpriteRenderer MainSpriteRenderer;

    [SerializeField] Animator animator;
    [SerializeField] GameObject ArmorShot;
    public Vector3 ShotPosition;
    [SerializeField] GameObject NowEnemyShot;
    [SerializeField] float ShotSpeed;

    // Start is called before the first frame update
    void Start()
    {
        MyEnemyRange = this.GetComponentInChildren<EnemyRange>();//子オブジェクトから取得
        MainSpriteRenderer = this.GetComponent<SpriteRenderer>();
        animator = this.GetComponent<Animator>();
        this.animator.SetTrigger("IdleTrigger");
    }

    // Update is called once per frame
    void Update()
    {
        if (MyEnemyRange.DetectPlayer){//射程に入っているなら動く
            MainSpriteRenderer.sprite = ArmorSprite[1];
            StartCoroutine("Armor_Attack");
        }
        else
        {
            MainSpriteRenderer.sprite = ArmorSprite[0];
            //StopCoroutine("Armor_Attack");
            this.animator.SetTrigger("IdleTrigger");
        }
    }

    IEnumerator Armor_Attack()
    {
        MainSpriteRenderer.sprite = ArmorSprite[1];
        yield return new WaitForSeconds(0.2f);
        this.animator.SetTrigger("AttackTrigger");

    }
    public void Attack()
    {
        ShotPosition = this.transform.position;
        ShotPosition.x -= 0.3f;
        Instantiate(ArmorShot,ShotPosition ,Quaternion.identity);
        NowEnemyShot = Instantiate(ArmorShot, this.transform.position, this.transform.rotation) as GameObject;
        if (ArmorShot != null)
        {
            EnemyShot S = NowEnemyShot.GetComponent<EnemyShot>();
            S.Create(360,-ShotSpeed);
        }
    }
}
