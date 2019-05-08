using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NPCListener : MonoBehaviour
{
    public GameObject textBox, background;
    public AudioClip interactionAudio;
    [TextArea]
    public string NPCGreeting;

    private bool isPrinting = false;

    private void OnTriggerStay(Collider other)
    {        
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F) && !isPrinting){
            SoundManager.instance.PlaySound(interactionAudio);
            textBox.SetActive(true);
            background.SetActive(true);
            StartCoroutine(TypeWriter());
            isPrinting = true;
        }     
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && textBox.activeSelf == true)
        {
            StopAllCoroutines();
            textBox.GetComponent<Text>().text = "";
            textBox.SetActive(false);
            background.SetActive(false);
            isPrinting = false;
            

        }
    }

    public IEnumerator TypeWriter()
    {
        Text greeting = textBox.GetComponent<Text>();
        greeting.text = "";

        for (int i = 0; i < NPCGreeting.Length; i++)
        {
            yield return new WaitForSeconds(0.1f);
            greeting.text += NPCGreeting[i];
            
        }
        isPrinting = false;
    }
}
