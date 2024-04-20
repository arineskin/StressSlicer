using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutter : MonoBehaviour
{
    Vector3 randomAngle;
    public GameObject Knife;
    private bool hasInteracted = false;
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Slice" && Knife.GetComponent<Knife>().IsCutting && !hasInteracted)
        {
            col.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            col.gameObject.GetComponent<Rigidbody>().AddTorque(-Vector3.up * 15000f, ForceMode.Impulse);
            randomAngle = new Vector3(Random.Range(-1.0f, -2.0f), Random.Range(0.6f, 1.2f), Random.Range(-2.0f, 2.0f));

            col.gameObject.GetComponent<Rigidbody>().AddForce(randomAngle * Random.Range(2000, 5000), ForceMode.Impulse);
            hasInteracted = true;
            Knife.GetComponent<Knife>().SetCuttingState(true);

            GameSystem.System.LEVEL.OnVegetableCut();
        }
    }

    void OnTriggerExit(Collider col)
    {
        hasInteracted = false;
    }
}