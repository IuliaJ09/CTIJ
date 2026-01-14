using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collider detectat: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player a intrat pe Finish!");
            if (Timer.instance != null)
                Timer.instance.FinishRace();
        }
    }

}
