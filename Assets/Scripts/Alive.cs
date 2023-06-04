using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Alive : Singleton<Alive>
{
    [SerializeField] private TMP_Text aliveText;
    private void Start()
    {
        ShowRemain(LevelManager.Ins.EnemyRemain);
        //UIManager.Ins.GetUI<GamePlay>().SetAlive
    }

    public void ShowRemain(int enemyRemain)
    {
        aliveText.text = $"Alive: {enemyRemain}";
    }
}
