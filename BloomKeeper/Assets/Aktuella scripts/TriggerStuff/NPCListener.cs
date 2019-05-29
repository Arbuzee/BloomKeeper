using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NPCListener : MonoBehaviour
{
    public GameObject textBox, background, textHelp;
    public AudioClip interactionAudio;
    [SerializeField] private GameObject portal;
    [SerializeField] private GameObject exclamationPoint;
    [TextArea]
    [SerializeField] private string NPCGreeting;


    private bool playerListening, playerKnows, isPrinting, openPortal, inRange;
   

    private void Update()
    {

        if (inRange && Input.GetKeyDown(KeyCode.F))
        {
            playerKnows = true;

            if (textBox.activeSelf)
            {
                CloseTextbox();
            }
            else
            {
                OpenTextbox();
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            portal.SetActive(true);
        }

     
    }

    #region Triggers
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;

            if (!playerKnows)
            {
                OpenTextbox();

            }
            else
                textHelp.SetActive(true);

        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
            CloseTextbox();
            textHelp.SetActive(false);
        }
    }
    #endregion



    private void OpenTextbox()
    {
        StopAllCoroutines();
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
