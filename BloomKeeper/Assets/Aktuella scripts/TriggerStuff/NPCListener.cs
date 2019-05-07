using UnityEngine;

public class NPCListener : MonoBehaviour
{
    public GameObject textBox;
    public AudioClip interactionAudio;


    private void OnTriggerStay(Collider other)
    {        
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F)){
            SoundManager.instance.PlaySound(interactionAudio);
            textBox.SetActive(true);
        }     
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && textBox.activeSelf == true)
        {
            textBox.SetActive(false);
        }
    }
}
