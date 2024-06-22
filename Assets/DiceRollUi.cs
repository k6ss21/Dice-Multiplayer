using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DiceRollUi : MonoBehaviour
{
    public Image[] images;
    List<SkillDetails> skillDetails;
    

    ManageSkills skillsManager;

    [SerializeField] GameObject resultUI;
    [SerializeField] Image resultImage;
    [SerializeField] RollDice rollDice;
    [SerializeField] FaceChecker faceChecker;

    private void OnEnable()
    {
        FaceChecker.OnRollDiceEnd += AfterRoll;
    }

    private void OnDisable()
    {
        FaceChecker.OnRollDiceEnd -= AfterRoll;
    }


    private void Start()
    {
        resultUI.SetActive(false);
        skillsManager = FindObjectOfType<ManageSkills>();
        UpdateSkillsUI();
    }

    private void UpdateSkillsUI()
    {
        AssignRollList();
        for (int i = 0; i < images.Length; i++)
        {
            images[i].sprite = skillDetails[i].skillCardImage;
        }

    }
    void AssignRollList()
    {
        switch (rollDice.rollCount)
        {
            case 0:
                skillDetails = skillsManager.skillsDetails_ATT;
                break;
            case 1:
                skillDetails = skillsManager.skillsDetails_DEF;
                break;
            case 2:
                skillDetails = skillsManager.skillsDetails_UP;
                break;
            default:
                break;
        }

    }

    void AfterRoll(int value)
    {
        switch (rollDice.rollCount)
        {
            case 1:
                skillsManager.attSkill = skillDetails[value - 1];
                break;
            case 2:
                skillsManager.defSkill = skillDetails[value - 1];
                break;
            case 3:
                skillsManager.upSkill = skillDetails[value - 1];
                break;
            default:
                break;
        }

        StartCoroutine(ShowResultUI(value - 1));

    }

    IEnumerator ShowResultUI(int value)
    {

        resultUI.SetActive(true);
        resultImage.sprite = skillDetails[value].skillCardImage;
        yield return new WaitForSeconds(3f);
       
        if (rollDice.rollCount == 3)
        {
            rollDice.enable = false;
            Debug.Log("ROLL COMLETE");
            FindObjectOfType<LevelManager>().LoadNextLevel();
        }
        else
        {  
            resultUI.SetActive(false);
            UpdateSkillsUI();
            rollDice.ResetDice();
            rollDice.enable = true;
            faceChecker.stop = false;
        }

    }

}
