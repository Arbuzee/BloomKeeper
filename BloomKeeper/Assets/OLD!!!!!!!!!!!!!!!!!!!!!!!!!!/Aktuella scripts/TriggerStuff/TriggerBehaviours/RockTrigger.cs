using UnityEngine;

public class RockTrigger : TriggeredObject
{
   
    private Vector3 trns = new Vector3(0, -20, 0);
    private bool activated = false;
  
    
    private void Update()
    {
        if(activated)
        {
            transform.position += trns * Time.deltaTime;
        }
    }

    public override void OnTrigger()
    {
        activated = true;
    }

}
