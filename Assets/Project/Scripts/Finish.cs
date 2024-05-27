using UnityEngine;
using UnityEngine.Playables;

public class Finish : MonoBehaviour
{
    public PlayableDirector director;
    public GameObject HUD;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HUD.SetActive(false);
            director.Play();
        }
    }
}
