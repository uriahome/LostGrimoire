using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic: MonoBehaviour
{

    [SerializeField] private PlayerMove NowPlayer;
    [SerializeField] private GameObject PlayerObj;

    [SerializeField] int ShotDirection;//発射される方向 0:上 1:右 2:左 3:下
    [SerializeField] float ShotSpeed = 0.4f;

    [SerializeField] string MagicWord;//属性

    public int MagicPower;//攻撃力

    [SerializeField] float WindTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        PlayerObj = GameObject.Find("Player");
        NowPlayer = PlayerObj.GetComponent<PlayerMove>();
        MagicWord =NowPlayer.NowMagicWord;//自分の属性の確定
        ShotDirection = NowPlayer.PlayerDirection;
        Debug.Log(ShotDirection);
        switch (ShotDirection)//方向の確定
        {
            case 0://上
                transform.Rotate(new Vector3(0f, 0f, 0f));//z軸を軸に0°回転
                    break;
            case 1://右
                transform.Rotate(new Vector3(0f, 0f, -90f));
                break;
            case 2://左
                transform.Rotate(new Vector3(0f, 0f, 90f));
                break;
            case 3:
                transform.Rotate(new Vector3(0f, 0f, 180f));
                break;
        }
        if (MagicWord == "wind")
        {
            transform.Translate(1,-1f,0);//風の座標調整
        }

        }

    // Update is called once per frame
    void Update()
    {
        AttackMagic();
    }
    void AttackMagic()
    {
        if(MagicWord == "fire")
        {
            this.MagicPower = 50;
            transform.Translate(0, ShotSpeed, 0);
            if (!GetComponent<Renderer>().isVisible)//画面外に出たら消える
            {
                Destroy(this.gameObject);
            }
        }
        if(MagicWord == "wind")
        {
            this.MagicPower = 50;
            transform.Rotate(new Vector3(0, 0,10));
            transform.Translate(ShotSpeed,ShotSpeed, 0);
            WindTime += Time.deltaTime;
            if(WindTime >= 2.0f)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
