using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField] GameObject[] Shot;
    [SerializeField] Vector3 Mytransform;//自分の座標
    [SerializeField] GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Mytransform = Player.transform.position;   
    }

    public void Attack(string word)
    {
        switch (word)
        {
            case "fire":
                Instantiate(Shot[0], Mytransform, Quaternion.identity);
                break;
            case "wind":
                Instantiate(Shot[1], Mytransform, Quaternion.identity);
                break;
        }
    }
}
