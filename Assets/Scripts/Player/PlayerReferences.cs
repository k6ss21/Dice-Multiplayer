using UnityEngine;
using UnityEngine.UI;
public class PlayerReferences : MonoBehaviour
{
    public CharacterController cc;
    public Animator animator;

    public LineOfSight los;
    public EnemyAI enemyPlayer;

    public Image fillImage;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        los = GetComponentInChildren<LineOfSight>();
        enemyPlayer = FindObjectOfType<EnemyAI>();
        fillImage  = GameObject.FindGameObjectWithTag("Player Health Bar").GetComponent<Image>();
    }
}
