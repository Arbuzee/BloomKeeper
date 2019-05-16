using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    private int pickupAmount = 0;
    [SerializeField] private Text pickupCounter;
    public static CanvasController Instance;

    private void Awake()
    {
        pickupAmount = 0;
        pickupCounter.text = "0";
        Instance = this;
    }

    public void addPickup()
    {
        pickupAmount++;
        pickupCounter.text = pickupAmount.ToString();
    }
}
