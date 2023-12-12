using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TowerController : MonoBehaviour
{
    public float ReloadTime;
    public GameObject Bullet;
    public float ShootSpeed = 0.5f;
    // Start is called before the first frame update

    public IEnumerator ShootCoroutine(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds (time);
            CreateBullet();

        }
    }

    private void CreateBullet()
    {
        GameObject newBullet = Instantiate(Bullet, transform.position + (transform.right * 0.6f), Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().AddForce(transform.right * ShootSpeed, ForceMode.Impulse);
    }

  
    void Start()
    {StartCoroutine(ShootCoroutine(ReloadTime));


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
