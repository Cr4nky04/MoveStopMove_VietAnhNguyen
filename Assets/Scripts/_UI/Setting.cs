using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : UICanvas
{
    public void PauseGame()
    {

    }

    public void ResumeGame()
    {
        UIManager.Ins.CloseUI<Setting>();
        ((Player)LevelManager.Ins.player).floatingJoystick = UIManager.Ins.GetUI<GamePlay>().floatingJoystick;
        Debug.Log("Resume");
    }

    public void BackToMenu()
    {
        for(int i = 0; i< LevelManager.Ins.bots.Count; i++)
        {
            LevelManager.Ins.bots[i].OnDespawn();
        }
        UIManager.Ins.CloseAll();
        UIManager.Ins.OpenUI<MainMenu>();
    }

    public void QuitGame()
    {

    }
}
