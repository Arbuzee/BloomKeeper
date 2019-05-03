using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{
    Enemy owner;
    float time;
    public void SetupTimer(Enemy owner, float time)
    {
        this.owner = owner;
        this.time = time;
        
    }

    public void RunTimer()
    {
        StartCoroutine(timer());
    }
    public IEnumerator timer()
    {
        yield return new WaitForSeconds(time);
        owner.Transition<EnemyAttackState>();
        Destroy(this);
        
    }
}