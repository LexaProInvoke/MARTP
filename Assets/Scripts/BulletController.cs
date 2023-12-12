using System.Collections;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float lifetime = 10f;
    private bool collided = false;

    void Start()
    {
        StartCoroutine(DestroyAfterTime());
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().GotHit();
        }

        collided = true;
        Destroy(gameObject);
    }

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(lifetime);
        if (!collided)
        {
            Destroy(gameObject);
        }
    }
}
