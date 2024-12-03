// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Drug : MonoBehaviour
// {
//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }

using UnityEngine;

public class Drug : MonoBehaviour
{
    public enum DrugCategory
    {
        Expired,     // Drugs that are expired
        Unused,      // Drugs that are unused
        WrongOrder   // Drugs that are wrongly ordered
    }

    public DrugCategory category; // The category of this drug
}