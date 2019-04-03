using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
    public class Data//ゲームのデータを保存する
    {
        public readonly static Data Instance = new Data();

        public int score = 0;
        public int SceneNum = 0;
        public float GameTime = 0;
        public int EndScore = 0;
        public string name = string.Empty;
        public string MagicName = "fire";//最初の魔導書
    }

