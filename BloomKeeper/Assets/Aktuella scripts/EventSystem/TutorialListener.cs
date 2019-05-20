using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCallbacks
{
    public class TutorialListener : MonoBehaviour
    {
        GameObject tutorialTextMovement;
        GameObject tutorialTextDecoy;


        void Start()
        {
            TutorialMovementEvent.RegisterListener(OnTutorialMovement);
            TutorialMovementEvent.RegisterListener(OnTutorialDecoy);
        }

        void OnDestroy()
        {
            TutorialMovementEvent.UnregisterListener(OnTutorialMovement);
            TutorialMovementEvent.UnregisterListener(OnTutorialDecoy);
        }

        // game calls this method if seconds after the game starts, teaching WASD + Space + mouse moves camera
        void OnTutorialMovement(TutorialMovementEvent OnTutorialMovement)
        {
            tutorialTextMovement.SetActive(true);
        }

        // NPC calls this method when the player first enters the trigger, teaching Q (Decoy)
        void OnTutorialDecoy(TutorialMovementEvent OnTutorialDecoy)
        {
            tutorialTextDecoy.SetActive(true);
        }
    }
}
