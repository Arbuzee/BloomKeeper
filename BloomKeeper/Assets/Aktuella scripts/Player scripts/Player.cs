using UnityEngine;

public class Player : PlayerStatemachine
{
    [HideInInspector] public MeshRenderer Renderer;
    

    protected override void Awake()
    {
        Renderer = GetComponent<MeshRenderer>();
        base.Awake();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyWeakSpot"))
        {
            other.transform.parent.root.GetComponent<Enemy>().Transition<EnemyProneState>();
            PlayerPhysics.Instance.PlayerVelocity += new Vector3(0, 50, 0);

        }
    }


   

}
