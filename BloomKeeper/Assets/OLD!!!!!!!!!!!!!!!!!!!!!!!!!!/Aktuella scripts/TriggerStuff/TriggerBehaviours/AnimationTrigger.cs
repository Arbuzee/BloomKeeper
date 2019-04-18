using UnityEngine;

public class AnimationTrigger: TriggeredObject
{
    public Animator anim;
    public bool hasDeactivation;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
   
    public override void OnTrigger()
    {
        anim.SetBool("Activate", true);
    }

    public override void OnDeTrigger()
    {
        if (!hasDeactivation)
            return;

        anim.SetBool("Activate", false);

    }
}
