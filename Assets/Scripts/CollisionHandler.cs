using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
   [SerializeField] private GameObject PlayerExplosionVFX;
    private SceneManagerScript sceneManagerScript;
    private void Start()
    {
        sceneManagerScript = FindFirstObjectByType<SceneManagerScript>(); 
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Collision detected with {other.gameObject.name}");
        Instantiate(PlayerExplosionVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        sceneManagerScript.ResetScene();
    }
}
