using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NPCListener : MonoBehaviour
{
    public GameObject textBox, background, textHelp;
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
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (textBox.activeSelf)
                {
                    CloseTextbox();
                }
                else
                {
                    OpenTextbox();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!playerKnows)
            {
                OpenTextbox();
            } else
            {
                textHelp.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CloseTextbox();
            textHelp.SetActive(false);
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
        playerKnows = true;
        isPrinting = false;
    }
}
