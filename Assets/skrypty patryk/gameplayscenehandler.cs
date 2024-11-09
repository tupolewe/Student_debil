using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameplayscenehandler: MonoBehaviour
{
    // Reference to the GameObject you want to activate
    public GameObject objectToActivate;

    // References to the GameObjects you want to deactivate
    public GameObject objectToDeactivate1;
    public GameObject objectToDeactivate2;

    // Function to manage the GameObject states
    public void ManageGameObjectStates()
    {
        // Activate the primary GameObject
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }

        // Deactivate the other GameObjects
        if (objectToDeactivate1 != null)
        {
            objectToDeactivate1.SetActive(false);
        }
        if (objectToDeactivate2 != null)
        {
            objectToDeactivate2.SetActive(false);
        }
    }
}



