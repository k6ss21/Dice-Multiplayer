using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
   
   [SerializeField] GameObject skillPage;

    private void Start() {
        skillPage.SetActive(false);
    }

    public void SkillsButton(bool b)
    {
        skillPage.SetActive(b);
    }
}
