using UnityEngine;

public class OffTrackDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("OffTrack"))
        {
            if (Timer.instance != null)
                Timer.instance.GameOver();
        }
    }
}
