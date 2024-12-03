// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class DropZone : MonoBehaviour
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

public class DropZone : MonoBehaviour
{
    public Drug.DrugCategory acceptedCategory; // The accepted drug type for this bin.

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the bin has the Drug script.
        Drug drug = other.GetComponent<Drug>();
        if (drug != null)
        {
            // Compare the drug's category with the accepted category for the bin.
            if (drug.category == acceptedCategory)
            {
                Debug.Log("Correct drug placed in the bin!");
                // Add points or trigger any success logic here.
                Destroy(other.gameObject); // Optional: Remove the drug from the scene.
            }
            else
            {
                Debug.Log("Incorrect drug placed in the bin!");
                // Optional: Deduct points or trigger failure logic here.
            }
        }
    }
}
