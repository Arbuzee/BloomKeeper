using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class RightMaterial : MonoBehaviour
{

    public GameObject ChangeObject;

    [Header("Key Material")]

    //public Material M1, M2, M3;
    
    private GameObject go1, go2, go3;
    //private bool b1 = false, b2 = false, b3 = false;


    private void Start()
    {
        go1 = transform.GetChild(0).gameObject;
        go2 = transform.GetChild(1).gameObject;
        go3 = transform.GetChild(2).gameObject;
    }

    public void BoolMaterial()
    {
        //if(go1.b)
    }

    //public void CheckMaterial()
    //{
    //    if (go1.GetComponent<Material>().Equals(M1))
    //    {
    //        b1 = true;
    //    }
    //    else
    //    {
    //        b1 = false;
    //    }

        //if (go2.GetComponent<Renderer>().sharedMaterial == M2)
        //{
        //    b2 = true;
        //}
        //else
        //{
        //    b2 = false;
        //}


        //if (go3.GetComponent<Renderer>().sharedMaterial == M3)
        //{
        //    b3 = true;
        //}
        //else
        //{
        //    b3 = false;
        //}

        if(b1 == true && b2 == true && b3 == true)
        {
            Debug.Log("alla material är rätt" + b1 +b2 + b3);
        }
        else
        {
            Debug.Log("något material är fel" + b1 + b2 + b3);

        }

    }






}
