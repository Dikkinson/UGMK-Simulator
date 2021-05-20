using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HandsTestScript : MonoBehaviour
{
    public List<Button> choiseButtons;
    public Animator characterAnimator;

    private List<string> questions = new List<string>()
    {
        "Поднять груз",
        "Опустить груз",
        "Повернуть стрелу",
        "Поднять стрелу",
        "Опустить стрелу",
        "Стоп",
        "Осторожно",
        "Передвинуть мост",
        "Передвинуть тележку"
    };

    private Dictionary<int, string> questionIntString = new Dictionary<int, string>()
    {
        {0, "Осторожно"},
        {1, "Опустить груз"},
        {2, "Поднять груз"},
        {3, "Передвинуть мост"},
        {4, "Повернуть стрелу"},
        {5, "Стоп"},
        {6, "Поднять стрелу"},
        {7, "Опустить стрелу"},
        {8, "Передвинуть тележку"},
    };


    public void StartTest()
    {
        /*int questionId = questionsId[Random.Range(0, questionsId.Count)];
        characterAnimator.SetInteger("State", questionId);
        questionsId.Remove(questionId);*/
    }

    public void BtnAnswer(bool isCorrect)
    {
        if (isCorrect)
        {
            Debug.Log("correct");
        }
        else
        {
            Debug.Log("wrong");
        }
    }

    public void GenerateQuestrin()
    {
        foreach (var button in choiseButtons)
        {
            button.onClick.RemoveAllListeners();
        }
        List<int> questionsIdList = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

        int questionId = questionsIdList[Random.Range(0, questionsIdList.Count)];
        
        questionsIdList.Remove(questionId);
        
        List<int> buttonId = new List<int>() {0, 1, 2, 3};

        int correctButton = Random.Range(0, buttonId.Count);

        choiseButtons[correctButton].GetComponentInChildren<TextMeshProUGUI>().text =
            questionIntString[questionId];

        buttonId.Remove(correctButton);

        choiseButtons[correctButton].onClick.AddListener(() => BtnAnswer(true));

        for (int i = 0; i < buttonId.Count; i++)
        {
            int falseQuestionId = questionsIdList[Random.Range(0, questionsIdList.Count)];
            questionsIdList.Remove(falseQuestionId);
            choiseButtons[buttonId[i]].GetComponentInChildren<TextMeshProUGUI>().text =
                questionIntString[falseQuestionId];
            choiseButtons[buttonId[i]].onClick.AddListener(() => BtnAnswer(false));
        }
        characterAnimator.SetInteger("State", questionId);
    }

    public void RightAnswer()
    {
    }

    public void WrongAnswer()
    {
    }
}