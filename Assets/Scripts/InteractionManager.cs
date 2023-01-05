using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public AudioSource[] audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("InteractableObject"))
        {
            if(other.gameObject.name == "Tired Ghosts")
            {
                Debug.Log("Tired Ghosts");
                audioSource[3].Play();
            }
            if (other.gameObject.name == "The Last Piano")
            {
                Debug.Log("The Last Piano");
                audioSource[2].Play();
            }
            if (other.gameObject.name == "Jazz Loop")
            {
                audioSource[0].Play();
            }
            if (other.gameObject.name == "Summer Night")
            {
                Debug.Log("Summer Night");
                audioSource[1].Play();

            }
        }
    }
}
