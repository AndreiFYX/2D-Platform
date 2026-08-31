using System;
using UnityEngine;

public static class GameEvents
{
    public static event Action<MoveEnemy> EnemyTouchedByPlayer;

    public static void RaiseEnemyTouchedByPlayer(MoveEnemy enemy)
    {
        EnemyTouchedByPlayer?.Invoke(enemy);
    }
}