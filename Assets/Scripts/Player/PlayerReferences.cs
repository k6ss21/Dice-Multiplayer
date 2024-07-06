using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class PlayerReferences : MonoBehaviour
{
    public CharacterController cc;
    public Animator animator;

    public LineOfSight los;
    public EnemyAI enemyPlayer;

    public Image fillImage;

    private void Start()
    {
        
       Invoke("Initialize", 5.0f);
    }
    void Initialize()
    {
        Debug.Log("Initialize");
        cc = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        los = GetComponentInChildren<LineOfSight>();
        enemyPlayer = FindObjectOfType<EnemyAI>();
        fillImage = GameObject.FindGameObjectWithTag("Player Health Bar").GetComponent<Image>();
    }


}
