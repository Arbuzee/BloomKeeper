using UnityEngine;


public class GameController : MonoBehaviour
{
    public GameObject text;
    public GameObject door;
    public static GameController instance;
    private float timer = 0f;

    
 
    void Start()
    {
        instance = this;
        EnemyCounter.SetEnemyCount(GameObject.FindGameObjectsWithTag("Enemy").Length);
    }
    
    void Update()
    {
        SpitterCooldown();
    }

    public void SpitterCooldown()
    {
        if (Spitter.CanSpitt == false)
        {
            timer += Time.deltaTime;
            if (timer >= 1)
            {
                Spitter.CanSpitt = true;
                timer = 0;

            }
        }
    }




    public void setFinisherText(bool what)
    {
        text.SetActive(what); 
    } 

    public void openDoor()
    {
        door.SetActive(false);
    }


}
