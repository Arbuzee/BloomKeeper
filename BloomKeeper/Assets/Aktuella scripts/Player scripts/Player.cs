using UnityEngine;


public class Player : MonoBehaviour
{

    //public ParticleSystem HitParticle;
    //public Transform hitpos;
    [SerializeField] private GameObject[] hearts;
    public int health;
    public AudioClip hitAudio;
    public static Player instance;

    public void Awake()
    {

        if (instance == null)
            instance = this;

        if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);


        health = hearts.Length;
    }


    public void TakeDamage()
    {
        GetComponentInChildren<PlayerAnimController>().PlayHurtSound();
        if (health <= 1) {

            ResetHealth();
            return;

        }
           
            

        health--;
        //ParticleSystem particleInstance = Instantiate(HitParticle, hitpos.position, Quaternion.identity);
        hearts[health].SetActive(false);
        //Destroy(particleInstance.gameObject, 1.5f);

    }




    public void ResetHealth()
    {
        
        foreach (GameObject heart in hearts)
        {
            heart.SetActive(true);
        }
        health = hearts.Length;

       transform.position = GameObject.Find("PlayerSpawnPoint").transform.position;

    }
}
