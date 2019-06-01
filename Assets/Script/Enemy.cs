using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    /*  public class EnemyData
      {
          public int hp;//体力
          public int Score;//倒したときに手に入るスコア
      }*/

    public int Hp;//体力
    public int Score;//倒したときに手に入るスコア
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Hp <= 0)
        {
            Destroy(this.gameObject);//体力がないなら消滅する
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Shot")//弾に当たった時
        {
            Hp -= collision.gameObject.GetComponent<Magic>().MagicPower;//攻撃力分のダメージを受ける
            StartCoroutine("Blink");
            Debug.Log("残りHP=" + Hp);

        }
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
