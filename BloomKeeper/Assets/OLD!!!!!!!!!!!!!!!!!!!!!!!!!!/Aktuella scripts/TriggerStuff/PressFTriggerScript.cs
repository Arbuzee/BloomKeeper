using UnityEngine;
using System;
using System.Collections;



public class PressFTriggerScript : MonoBehaviour
    {
        public GameObject TriggerObject;
        public LayerMask layerMask;
        public float timer;



        private void OnTriggerStay(Collider other)
        {

            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    try
                    {
                        TriggerObject.GetComponent<TriggeredObject>().OnTrigger();
                        StartCoroutine(Timer());

                    }
                    catch (Exception e) { }

                }
            }


        }

        public IEnumerator Timer()
        {
            yield return new WaitForSeconds(timer);
            TriggerObject.GetComponent<TriggeredObject>().OnDeTrigger();
        }


    }




