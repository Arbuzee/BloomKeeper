using UnityEngine;

public class Spitter : Enemy
{
    public GameObject spitt;
    public static bool CanSpitt;
    public bool spitter = true;



    protected override void Awake()
    {
        CanSpitt = true;
        base.Awake();

    }



}

