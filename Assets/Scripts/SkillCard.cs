using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class SkillCard : MonoBehaviour, IPointerClickHandler
{

    private int tmpNumber = 1;

    public bool disable = false;

    SkillAssign skillAssign;

    Image image;

    private void Start()
    {
        skillAssign = FindObjectOfType<SkillAssign>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(disable) return;
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
