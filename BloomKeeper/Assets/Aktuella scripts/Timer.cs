using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{
    private Enemy owner;
    private float time;

    public void SetupTimer(Enemy owner, float time)
    {
        this.owner = owner;
        this.time = time;
        
    }

    public void RunTimer(string methodName)
    {

        Debug.Log("testar switch");
        switch (methodName.ToLower())
        {
            case "transitiontoattacktimer":
                StartCoroutine(TransitionToAttackTimer());
                break;

            case "spittimer":
                StartCoroutine(SpitTimer());
                break;

            default:
                Debug.Log("");
                break;



        }
    }
    public IEnumerator TransitionToAttackTimer()
    {
        
        yield return new WaitForSeconds(time);
        owner.Transition<SpitterAttackState>();
        Destroy(this);
        
    }

 

    public IEnumerator SpitTimer() {

        yield return new WaitForSeconds(1);
        Spitter.CanSpitt = true;
        Destroy(this);
    }
}