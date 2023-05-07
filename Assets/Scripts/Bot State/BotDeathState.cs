using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotDeathState : BotIState<Character>
{
    public void OnStart(Character bot)
    {
        bot.StartCoroutine(IDeath(bot));
    }
    public void OnExecute(Character bot)
    {

    }
    public void OnExit(Character bot)
    {

    }

    public IEnumerator IDeath(Character bot)
    {
        bot.ChangeAnim(Cache.AnimName("IsDead"));
        yield return Cache.GetWFS(1f);
        bot.OnDespawn();
    }
}
