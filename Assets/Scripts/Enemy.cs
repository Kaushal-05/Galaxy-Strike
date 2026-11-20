using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject explosionVFX;
    [SerializeField] private int hitPoints = 10;
    [SerializeField] private int ShipDestroyedScore = 100;
    [SerializeField] private int HitPointsScore = 10;
    [SerializeField] private Scoreboard scoreboard; 

    void Start()
    {
        scoreboard = FindFirstObjectByType<Scoreboard>();
    }
    private void OnParticleCollision(GameObject other)
    {
        hitPoints--;
        DestroyEnemy();
        scoreboard.AddScore(HitPointsScore);
    }

    private void DestroyEnemy()
    {
        if (hitPoints <= 0)
        {
            Instantiate(explosionVFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            scoreboard.AddScore(ShipDestroyedScore);
        }
    }
}
