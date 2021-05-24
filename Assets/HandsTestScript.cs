using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HandsTestScript : MonoBehaviour
{
    public List<Button> choiseButtons;
    public Animator characterAnimator;
    public TextMeshProUGUI failsCountText;
    private int failsCount = 0;

    private Dictionary<int, string> questionIntString = new Dictionary<int, string>()
    {
        {0, "Осторожно"},
        {1, "Опустить груз"},
        {2, "Поднять груз"},
        {3, "Передвинуть мост"},
        {4, "Повернуть стрелу/Передвинуть тележку"},
        {5, "Стоп"},
        {6, "Поднять стрелу"},
        {7, "Опустить стрелу"},
    };

    private int counter;

    public void StartTest()
    {
        counter = questionIntString.Count;
        GenerateQuestion();
    }

    public void BtnAnswer(bool isCorrect)
    {
        if (isCorrect)
        {
            counter--;
            if (counter == 0)
            {
                Debug.Log("CONEC");
            }
            else
            {
                GenerateQuestion();
            }
        }
        else
        {
            failsCount++;
            failsCountText.text = $"Ошибок: {failsCount}";
        }
    }
    List<int> questionsUserList = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7};
    public void GenerateQuestion()
    {
        foreach (var button in choiseButtons)
        {
            button.onClick.RemoveAllListeners();
        }//ОЧИСТКА ВСЕХ ЛИСЕНЕРОВ КНОПОК ОТВЕТОВ

        List<int> questionsIdList = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7};//МАКСКА ВОПРОСОВ
        
        int questionId = questionsUserList[Random.Range(0, questionsUserList.Count)];//Получаем случайный вопрос
        
        questionsUserList.Remove(questionId);//Убираем его из маски
        questionsIdList.Remove(questionId);
        
        List<int> buttonId = new List<int>() {0, 1, 2, 3};//Маска кнопок

        int correctButton = Random.Range(0, buttonId.Count);//Случайная правильная кнопка

        choiseButtons[correctButton].GetComponentInChildren<TextMeshProUGUI>().text =
            questionIntString[questionId]; // Задали правильный ответ правильной кнопке

        buttonId.Remove(correctButton);//Убрали из маски правильную кнопку

        choiseButtons[correctButton].onClick.AddListener(() => BtnAnswer(true));//Добавили правильной кнопке он клик правильный

        for (int i = 0; i < buttonId.Count; i++)//В оставшиеся кнопки
        {
            int falseQuestionId = questionsIdList[Random.Range(0, questionsIdList.Count)];//Из макси вопросов выбрали рандомные ответы
            questionsIdList.Remove(falseQuestionId);//Убрали из маски
            choiseButtons[buttonId[i]].GetComponentInChildren<TextMeshProUGUI>().text =
                questionIntString[falseQuestionId];//Задали текст
            choiseButtons[buttonId[i]].onClick.AddListener(() => BtnAnswer(false));//Задали он клик
        }
        characterAnimator.SetInteger("State", questionId);//Включили анимашку
    }
}