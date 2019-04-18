using UnityEngine;

public class EnemyCounter
{
   
    private static int aliveEnemies;


    public static int GetEnemyCount() {

        return aliveEnemies;
    }

    public static void KillEnemy() {

        aliveEnemies--;

    }

    public static void SetEnemyCount(int count)
    {
        aliveEnemies = count;
    }


}
