using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    [SerializeField] private PlayerMove NowPlayer;
    [SerializeField] private GameObject PlayerObj;

    [SerializeField] int ShotDirection;//発射される方向 0:上 1:右 2:左 3:下
    [SerializeField] float ShotSpeed = 0.4f;
    public int MagicPower;//攻撃力
    // Start is called before the first frame update
    void Start()
    {
        PlayerObj = GameObject.Find("Player");
        NowPlayer = PlayerObj.GetComponent<PlayerMove>();
        ShotDirection = NowPlayer.PlayerDirection;
        //  Debug.Log(ShotDirection);
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

        transform.Rotate(new Vector3(this.transform.rotation.x, this.transform.rotation.y,
               this.transform.rotation.z +60f));
    }

    // Update is called once per frame
    void Update()
    {
        AttackMagic();
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(this.gameObject);
        }
    }

    void AttackMagic()
    {
            this.MagicPower = 50;

            transform.Translate(0, ShotSpeed * 0.5f, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
