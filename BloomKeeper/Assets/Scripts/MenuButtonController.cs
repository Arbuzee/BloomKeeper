using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonController : MonoBehaviour
{
    public int index;
    [SerializeField] bool keyDown;
    [SerializeField] int maxIndex;
    public AudioSource audioSource;

    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject optionsMenu;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startMenu.activeSelf)
        {
            if (Input.GetAxis("Vertical") != 0)
            {
                if (!keyDown)
                {
                    if (Input.GetAxis("Vertical") < 0)
                    {
                        if (index < maxIndex)
                        {
                            index++;
                        }
                        else
                        {
                            index = 0;
                        }
                    }
                    else if (Input.GetAxis("Vertical") > 0)
                    {
                        if (index > 0)
                        {
                            index--;
                        }
                        else
                        {
                            index = maxIndex;
                        }
                    }
                    keyDown = true;
                }
            }
            else
            {
                keyDown = false;
            }
        }

        if (Input.GetAxis("Submit") == 1)
        {
            if (!keyDown)
            {
                switch (index)
                {
                    case 0:
                        StartGame();
                        break;
                    case 1:
                        Options();
                        break;
                    case 2:
                        QuitGame();
                        break;
                    default:
                        break;
                }
            } 
            keyDown = true;
        }

        if (optionsMenu.activeSelf)
        {
            if (Input.GetAxis("Cancel") == 1)
            {
                Options();
            }
        }
    }

    private void StartGame()
    {
        SceneManager.LoadScene(1); // LoadSceneMode.Single is the Default
    }

    private void Options()
    {
        if (startMenu.activeSelf)
        {
            startMenu.SetActive(false);
            optionsMenu.SetActive(true);
        }
        else
        {
            startMenu.SetActive(true);
            optionsMenu.SetActive(false);
        }
            
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
