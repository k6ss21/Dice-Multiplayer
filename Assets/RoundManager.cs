using System;
using System.Collections;
using UnityEngine;

public class RoundManager : MonoBehaviour
{


    int currentRound;
    [SerializeField] int totalRound = 6;

    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject enemyPrefab;

    [SerializeField] Transform playerSpawnPos;
    [SerializeField] Transform enemySpawnPos;

    public static event Action OnRoundStart;
    void OnEnable()
    {
        PlayerHealth.OnPlayerDead += NextRound;
    }
    private void OnDisable()
    {
        PlayerHealth.OnPlayerDead -= NextRound;
    }
    private void Start()
    {
        StartRound();
        currentRound = 1;
    }

    public void NextRound()
    {
        currentRound += 1;
        StartCoroutine(NextRoundIntializeRoutine())
;
    }

    IEnumerator NextRoundIntializeRoutine()
    {
        yield return new WaitForSeconds(4f);
        RoundEnd();
        yield return new WaitForSeconds(4f);
        Time.timeScale = 1;
        StartRound();


    }

    void RoundEnd()
    {
        EnemyAI enemy = FindObjectOfType<EnemyAI>();
        Player player = FindObjectOfType<Player>();
        if (enemy != null)
        {
            Destroy(enemy.gameObject);
        }
        else
        {
            Destroy(player);
        }
    }

    void StartRound()
    {
        Instantiate(playerPrefab, playerSpawnPos.position, Quaternion.identity);
        Instantiate(enemyPrefab, enemySpawnPos.position, Quaternion.identity);
        OnRoundStart?.Invoke();
    }


}
