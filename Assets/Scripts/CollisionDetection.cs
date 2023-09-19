using UnityEngine;

public class MeteorCollision : MonoBehaviour
{
    // This script should be attached to the meteor GameObject.
    public GameObject ExplosionPrefab;
    private bool hasExploded = false; // Flag to track if the explosion has occurred.

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasExploded && collision.gameObject.CompareTag("Spacecraft"))
        {
            // Check if the collision is with a spacecraft (adjust the tag as needed).
            Destroy(gameObject); // Destroy the meteor on collision with the spacecraft.
            CreateExplosionEffect(collision.contacts[0].point);

            // Set the flag to true to prevent further explosions.
            hasExploded = true;
        }
    }

    private void CreateExplosionEffect(Vector2 position)
    {
        if (ExplosionPrefab != null)
        {
            Instantiate(ExplosionPrefab, position, Quaternion.identity);
            float explosionDuration = ExplosionPrefab.GetComponent<ParticleSystem>().main.duration;
            Destroy(ExplosionPrefab, explosionDuration);
        }
    }
}
