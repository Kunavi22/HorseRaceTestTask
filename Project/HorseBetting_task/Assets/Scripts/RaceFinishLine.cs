using UnityEngine;

public class RaceFinishLine : MonoBehaviour
{
    [SerializeField]
    RaceManager raceManager;

    private void OnTriggerEnter(Collider other)
    {
        raceManager.RegisterHorseFinished(other.transform.parent.GetComponent<HorseController>());
    }
}
