using UnityEngine;

[CreateAssetMenu(menuName = "Player/Abilities/Decoy")]
public class Ability : ScriptableObject
{

    public GameObject attack;
    private GameObject instance;
    public float maxThrowForce;

    public void Execute(Transform dropPoint, float multiplier) {

        float throwForce = maxThrowForce * multiplier;
        

        instance = Instantiate(attack, dropPoint.position, Quaternion.identity);
        instance.GetComponent<Rigidbody>().AddForce(dropPoint.transform.TransformDirection(new Vector3(0, maxThrowForce, maxThrowForce) * multiplier));

        
    }

    public void Execute(Vector3 dropPoint)
    {
        instance = Instantiate(attack, dropPoint, Quaternion.identity);
    }



    public GameObject GetInstance() {

        return instance;
    }

}
