using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class SkillCard : MonoBehaviour, IPointerClickHandler
{

    private int tmpNumber = 1;

    public bool disable = false;

    SkillAssign skillAssign;

    Image image;

    [SerializeField] public SkillDetails skillDetails;

    private void Start()
    {
        image = GetComponent<Image>();
        skillAssign = FindObjectOfType<SkillAssign>();
        if (skillDetails != null)
        {
            image.sprite = skillDetails.skillCardImage;
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (disable) return;
        skillAssign.AssignSkillToSlot(this);
        Debug.Log("Pointer Click");
    }

    public void Disable(bool b)
    {
        disable = b;
        image = GetComponent<Image>();
        var tempColor = image.color;
        if (b)
        {
            tempColor.a = .5f;
            image.color = tempColor;
        }
        else
        {
            tempColor.a = 1f;
            image.color = tempColor;
        }
    }

}
