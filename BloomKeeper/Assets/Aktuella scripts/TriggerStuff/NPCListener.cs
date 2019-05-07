using UnityEngine;

public class NPCListener : MonoBehaviour
{
    public GameObject textBox;
    public AudioClip interactionAudio;


    public void Update()
    {
        textBox.transform.LookAt(new Vector3(Camera.main.transform.position.x, 0, Camera.main.transform.position.z));
    }

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
