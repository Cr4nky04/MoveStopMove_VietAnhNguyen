using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : UICanvas
{
    public Player player;
    public GameObject Joystick;
    public TMP_InputField TxtPlayerName;
    public GameObject Mainmenu;
    private void Start()
    {
        Joystick.SetActive(false);
    }
    public void SetPlayerName()
    {

    }
    public void Play()
    {
        GameManager.ChangeState(GameManager.GameState.GamePlay);
        Joystick.SetActive(true);
        ((Player)LevelManager.Ins.player).waypoint.ShowName(player.charName = TxtPlayerName.text);
        UIManager.Ins.CloseUI<MainMenu>();
        UIManager.Ins.OpenUI<GamePlay>();
        Alive.Ins.ShowRemain(LevelManager.Ins.EnemyRemain = 50);
        LevelManager.Ins.FirstSpawn();
        for (int i = 0; i < LevelManager.Ins.bots.Count; i++)
        {
            LevelManager.Ins.bots[i].currentState.ChangeState(new BotIdleState());
        }

        ((Player)LevelManager.Ins.player).floatingJoystick = UIManager.Ins.GetUI<GamePlay>().floatingJoystick;
    }
}
