using UnityEngine;

public class AnimationTrigger: TriggeredObject
{
    private Animator anim;
    public bool hasDeactivation;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
   
    public override void OnTrigger()
    {
        if (anim != null)
            anim.SetBool("Active", true);
    }

    public override void OnDeTrigger()
    {
        if (!hasDeactivation)
            return;
        if (anim != null)
            anim.SetBool("Active", false);
    }
}
