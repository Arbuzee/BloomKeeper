using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/Abilities/Decoy")]
public class Ability : ScriptableObject
{

    public GameObject attack;
    private GameObject instance;

    public void Execute(Transform dropPoint) {

        instance = Instantiate(attack, dropPoint.position, Quaternion.identity);

    }

    public GameObject GetInstance() {

        return instance;
    }

}
