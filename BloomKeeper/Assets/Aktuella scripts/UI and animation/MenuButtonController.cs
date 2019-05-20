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
    [SerializeField] private GameObject continueButton;

    private Animator menuAnim;

    private bool gameStartAnimationFinished = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        menuAnim = GetComponent<Animator>();

        // Check if game has a saved state, if so create the continue button
        if (PlayerPrefs.GetInt("GameSaved", 0) > 0)
        {
            maxIndex += 1;
        } else
        {
            continueButton.SetActive(false);
        }

        StartCoroutine("UnlockMenuAfterTime");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStartAnimationFinished)
        {
            if (Input.GetAxis("Vertical") != 0)
            {
                if (!keyDown)
                {
                    if (startMenu.activeSelf)
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

                    }
                }
                keyDown = true;
            }
            else
            {
                keyDown = false;
            }

            if (Input.GetAxis("Submit") == 1)
            {
                if (!keyDown)
                {
                    switch (index)
                    {
                        case 0:
                            menuAnim.SetTrigger("startGame");
                            break;
                        case 1:
                            menuAnim.SetBool("optionsOpen", true);
                            break;
                        case 2:
                            QuitGame();
                            break;
                        case 3:
                            ContinueGame();
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
                    menuAnim.SetBool("optionsOpen", false);
                }
            }
        }
    }

    private void SetGameStartAnimationFinished()
    {
        gameStartAnimationFinished = true;
    }


    private void StartGame()
    {
        SceneManager.LoadScene(1); // LoadSceneMode.Single is the Default
    }

    private void ContinueGame()
    {
        SceneManager.LoadScene(1); // LoadSceneMode.Single is the Default
        //
        // Make sure it loads Player prefs and works with the checkpoint system
    }

    /*
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
            
    }*/

    private void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator UnlockMenuAfterTime()
    {
        yield return new WaitForSeconds(4);
    }
}


