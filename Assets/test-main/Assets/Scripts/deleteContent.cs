using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class deleteContent : MonoBehaviour
{
    public void RemoveObject()
    {
        Destroy(gameObject);
    }
}
