using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NPCListener : MonoBehaviour
{
    public GameObject textBox, background;
    public AudioClip interactionAudio;
    [TextArea]
    public string NPCGreeting;

    private bool playerListening = false;
    private bool playerKnows = false;
    private bool isPrinting = false;

    private void Update()
    {
        if (playerKnows)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                CloseTextbox();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!playerKnows)
        {
            OpenTextbox();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && textBox.activeSelf == true)
        {
            CloseTextbox();
        }
    }

    private void OpenTextbox()
    {
        SoundManager.instance.PlaySound(interactionAudio);
        textBox.SetActive(true);
        background.SetActive(true);
        StartCoroutine(TypeWriter());
    }

    private void CloseTextbox()
    {
        StopAllCoroutines();
        textBox.GetComponent<Text>().text = "";
        textBox.SetActive(false);
        background.SetActive(false);
    }

    public IEnumerator TypeWriter()
    {
        isPrinting = true;
        Text greeting = textBox.GetComponent<Text>();
        greeting.text = "";

        for (int i = 0; i < NPCGreeting.Length; i++)
        {
            yield return new WaitForSeconds(0.01f);
            greeting.text += NPCGreeting[i];
            
        }
        isPrinting = false;
    }
}
