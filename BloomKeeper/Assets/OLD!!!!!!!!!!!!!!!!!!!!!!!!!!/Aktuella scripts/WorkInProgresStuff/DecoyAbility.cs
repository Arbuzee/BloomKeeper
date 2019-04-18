using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoyAbility : MonoBehaviour
{
    Bezier bezier;
    public Ability ability;
    public Transform dropPoint;

    public void SetDecoy()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            bezier = gameObject.AddComponent<Bezier>();
            gameObject.AddComponent<LineRenderer>();
        }
        if (Input.GetKey(KeyCode.Q))
        {

            bezier.DrawBezier(dropPoint);

        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            ability.Execute(dropPoint);
            Destroy(GetComponent<LineRenderer>());
        }
    }


}
