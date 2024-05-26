using UnityEngine;
using UnityEngine.Playables;

public class Finish : MonoBehaviour
{
    public PlayableDirector director;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            director.Play();
        }
    }
}
