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
    public int Hp;//体力
    public int Score;//倒したときに手に入るスコア

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
        if (Hp <= 0)
        {
            Destroy(this.gameObject);//体力がないなら消滅する
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
        //これはanimationから呼ばれる
        Debug.Log("Armor__Attack");
        ShotPosition = this.transform.position;
        ShotPosition.x -= 0.3f;
        //この下の一行の存在を忘れて永遠に止まっていた許さんぞ過去の俺（許す
       // Instantiate(ArmorShot,ShotPosition ,Quaternion.identity);
        NowEnemyShot = Instantiate(ArmorShot, this.transform.position, this.transform.rotation) as GameObject;
        if (ArmorShot != null)
        {
            EnemyShot S = NowEnemyShot.GetComponent<EnemyShot>();
            S.Create(360,-ShotSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.gameObject.tag == "Shot")//弾に当たった時
            {
            //Hp -= collision.gameObject.GetComponent<Magic>().MagicPower;//攻撃力分のダメージを受ける
                Hp -= 50;//面倒だから一律50にしたい
                StartCoroutine("Blink");
                Debug.Log("残りHP=" + Hp);

            }
        Debug.Log("Armor");
    }
    public IEnumerator Blink()//点滅
    {
        int BlinkCount = 0;
        float interval = 0.1f;
        while (true)
        {
            var renderComponent = GetComponent<Renderer>();
            BlinkCount++;
            if (BlinkCount >= 6)
            {
                renderComponent.enabled = true;
                yield break;
            }
            renderComponent.enabled = !renderComponent.enabled;
            yield return new WaitForSeconds(interval);
        }
    }
}
