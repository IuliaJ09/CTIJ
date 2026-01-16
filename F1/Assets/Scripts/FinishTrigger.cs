using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player a ajuns la finish Finish!");
            if (Timer.instance != null)
                Timer.instance.FinishRace();
        }
    }

}
