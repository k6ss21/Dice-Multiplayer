using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    EnemyReferences enemyReferences;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform shootPosition;
    [SerializeField] float shootInterval = 3f;

    private void Start()
    {
        enemyReferences = GetComponent<EnemyReferences>();
        StartCoroutine(ShootAtInterval());

    }

    private void Shoot()
    {
     //   Debug.Log("Shooting");
        GameObject obj = Instantiate(projectilePrefab, shootPosition.position, Quaternion.identity);
        if (enemyReferences.player != null)
        {

            obj.GetComponent<Bullet>().SetTarget(enemyReferences.player.gameObject);

           // obj.GetComponent<Bullet>().SetDirection(transform.forward);

        }
        StartCoroutine(ShootAtInterval());
    }

    IEnumerator ShootAtInterval()
    {
        yield return new WaitForSeconds(shootInterval);
        Shoot();
    }
}
