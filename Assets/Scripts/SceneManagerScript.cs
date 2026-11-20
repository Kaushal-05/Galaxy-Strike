using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    [SerializeField] private int ResetTime = 3;

    public void ResetScene()
    {
       StartCoroutine(ResetAfterSec());
    }

    IEnumerator ResetAfterSec()
    {
        yield return new WaitForSeconds(ResetTime);
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }
}
