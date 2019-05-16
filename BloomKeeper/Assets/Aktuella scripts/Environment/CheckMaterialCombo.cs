using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMaterialCombo : MonoBehaviour
{
    public GameObject TriggerObject;

    public GameObject Pad1, Pad2, Pad3;

    [Header("Rätt material")]
    public Material Mat1;
    public Material Mat2;
    public Material Mat3;

    protected Renderer ren;

    // Start is called before the first frame update
    void Awake()
    {
        ren = GetComponent<Renderer>();
    }
    public void checkMaterial()
    {
        //Debug.Log(pad1.GetComponent<Renderer>().material.ToString() + pad2.GetComponent<Renderer>().material.ToString() + pad3.GetComponent<Renderer>().material.ToString());

        Debug.Log(Pad1.GetComponent<Renderer>().sharedMaterial.ToString() + Pad2.GetComponent<Renderer>().sharedMaterial.ToString() + Pad3.GetComponent<Renderer>().sharedMaterial.ToString());
        if(Pad1.GetComponent<Renderer>().sharedMaterial.Equals(Mat1) && Pad2.GetComponent<Renderer>().sharedMaterial.Equals(Mat2) && Pad3.GetComponent<Renderer>().sharedMaterial.Equals(Mat3))
        {
            TriggerObject.GetComponent<TriggeredObject>().OnTrigger();
            Debug.Log("Colorpads Triggerd");
        }
        else
        {
            TriggerObject.GetComponent<TriggeredObject>().OnDeTrigger();
        }
        
        //if(pad1.GetComponent<Renderer>().sharedMaterial)
    }

}
