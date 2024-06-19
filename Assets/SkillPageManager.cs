using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class SkillPageManager : MonoBehaviour
{
    [SerializeField] RectTransform page1;
    [SerializeField] RectTransform page2;
    [SerializeField] RectTransform page3;


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




}
