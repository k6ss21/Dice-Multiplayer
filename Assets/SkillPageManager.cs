using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class SkillPageManager : MonoBehaviour
{
    [SerializeField] RectTransform page1;
    [SerializeField] RectTransform page2;
    [SerializeField] RectTransform page3;


    private void Start()
    {
        page1.gameObject.SetActive(true);
        page2.gameObject.SetActive(false);
        page3.gameObject.SetActive(false);
    }


    public void ShowPage1()
    {
        page1.gameObject.SetActive(true);
        page2.gameObject.SetActive(false);
        page3.gameObject.SetActive(false);
    }

    public void ShowPage2()
    {
        page1.gameObject.SetActive(false);
        page2.gameObject.SetActive(true);
        page3.gameObject.SetActive(false);
    }

    public void ShowPage3()
    {
        page1.gameObject.SetActive(false);
        page2.gameObject.SetActive(false);
        page3.gameObject.SetActive(true);
    }

    public void SaveButton()
    {
        page1.GetComponentInChildren<SkillAssign>().SaveSkills();
        page2.GetComponentInChildren<SkillAssign>().SaveSkills();
        page3.GetComponentInChildren<SkillAssign>().SaveSkills();
    }
    


}
