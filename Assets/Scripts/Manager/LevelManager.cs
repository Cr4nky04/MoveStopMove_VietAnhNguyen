using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] NavMeshSurface navmeshSurface;
    public TMP_Text Text;
    public Level[] levelPrefabs;
    public int PlayerCoin;
    public int EnemyRemain=50;
    public int EnemyOnGround = 1;
    public Player player;

    private bool FinishLevel => EnemyRemain <= 0;
    private Level currentLevel;
    private string saveName="PlayerGold";
    
    private void Start()
    {
        UIManager.Ins.OpenUI<MainMenu>();
        
        PlayerCoin = PlayerPrefs.GetInt(saveName);       
        //Text.text = PlayerCoin.ToString();
  
    }

    public void SetGold(int coin)
    {
        PlayerPrefs.SetInt(saveName, PlayerCoin+=coin);
        UIManager.Ins.GetUI<GamePlay>().coinText.text = PlayerCoin.ToString();
    }
    public void Buy(int coin)
    {
        PlayerPrefs.SetInt(saveName, PlayerCoin -= coin);
        UIManager.Ins.GetUI<GamePlay>().coinText.text = PlayerCoin.ToString();
    }

    public List<Bot> bots = new List<Bot>();

    private void SpawnBot()
    {
        Bot botTest = SimplePool.Spawn<Bot>(PoolType.Bot, Vector3.zero, Quaternion.identity);
        bots.Add(botTest);
        botTest.OnInit();
        botTest.OnPlayState();
    }

    public void DespawnBot(Bot bot)
    {
        bots.Remove(bot);

        if (bots.Count == 0 && EnemyRemain==0)
        {
            GameManager.ChangeState(GameManager.GameState.Win);
        }
        if(EnemyRemain > EnemyOnGround)
        {
            StartCoroutine(Spawn());
        }
    }

    public IEnumerator Spawn()
    {
        yield return Cache.GetWFS(1f);
        SpawnBot();
    }
    public void SaveGame()
    {
        PlayerPrefs.SetInt(saveName, PlayerCoin);
        //PlayerPrefs.Save();
    }

    public void LoadLevel(int level)
    {
        if(currentLevel != null)
        {
            Destroy(currentLevel.gameObject);
        }
        if (level < levelPrefabs.Length)
        {
            currentLevel = Instantiate(levelPrefabs[level]);
            currentLevel.OnInit();
        }

    }

    public void FirstSpawn()
    {
        for (int i = 0; i < EnemyOnGround; i++)
        {
            SpawnBot();
        }
    }
    private void OnWin()
    {

    }

    private void OnLose()
    {

    }

    public void OnStartGame()
    {

    }

    public void OnFinishGame()
    {

    }
    public void OnReset()
    {
        
    }
}

