using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Sprite[] PlayerSprite;
    [SerializeField] SpriteRenderer MainSpriteRenderer;

    [SerializeField] float MovePower;//速度
    public int PlayerDirection;//向いている方向　0:上 1:右 2:左 3:下

    [SerializeField] GameObject AttackMaster;//攻撃位置
    [SerializeField] PlayerAttack MyAttack;
    [SerializeField] Rigidbody2D rigid2d;
    public  string NowMagicWord;//今現在の魔法の属性　Shotクラスなどで読み込むのでpublic


    


    // Start is called before the first frame update
    void Start()
    {
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();//このオブジェクトのSpriteRendererを取得
    }

    // Update is called once per frame
    void Update()
    {
        NowMagicWord = Data.Instance.MagicName;
        rigid2d.velocity = new Vector2(0, 0) * 0;//加速度を0に
        Move();//移動処理
        if (Input.GetKeyDown(KeyCode.Z))
        {
            MyAttack.Attack(NowMagicWord);
        }


    }


    void Move()
    {
        Vector3 MoveLate = new Vector3 (0, 0, 0);
        float MoveLateX = 0, MoveLateY = 0;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            // transform.Translate(MovePower, 0, 0);
            MoveLateX = MovePower;
            MainSpriteRenderer.sprite = PlayerSprite[1];
            PlayerDirection = 1;
        }
        /*else*/ if (Input.GetKey(KeyCode.LeftArrow))
        {
            //transform.Translate(-MovePower, 0, 0);
            MoveLateX = -MovePower;
            MainSpriteRenderer.sprite = PlayerSprite[2];
            PlayerDirection = 2;
        }
        /*else*/ if (Input.GetKey(KeyCode.UpArrow))
        {
            //transform.Translate(0, MovePower, 0);
            MoveLateY = MovePower;
            MainSpriteRenderer.sprite = PlayerSprite[0];
            PlayerDirection = 0;

        }/*else*/ if (Input.GetKey(KeyCode.DownArrow))
        {
            //transform.Translate(0, -MovePower, 0);
            MoveLateY = -MovePower;
            MainSpriteRenderer.sprite = PlayerSprite[3];
            PlayerDirection = 3;
        }

        transform.Translate(MoveLateX, MoveLateY, 0);
    }
}
