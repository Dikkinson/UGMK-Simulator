using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HandsTestScript : MonoBehaviour
{
    public List<Button> choiseButtons;
    public Animator characterAnimator;
    public TextMeshProUGUI failsCountText;
    private int failsCount = 0;
    public AudioSource audio;
    public AudioClip correctAudio;
    public AudioClip failAudio;
    public GameObject endPanel;
    public TextMeshProUGUI failsCountResultText;
    public TextMeshProUGUI questionNumber;

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

    private int counter = 1;

    public void StartTest()
    {
        GenerateQuestion();
    }

    public void BtnAnswer(bool isCorrect)
    {
        if (isCorrect)
        {
            
            if (counter == questionIntString.Count)
            {
                failsCountResultText.text = $"Количество ошибок: {failsCount}";
                endPanel.SetActive(true);
                gameObject.SetActive(false);
            }
            else
            {
                StartCoroutine(CorrectAnswerCo());
                counter++;
            }
        }
        else
        {
            failsCount++;
            failsCountText.text = $"Ошибок: {failsCount}";
            failsCountText.GetComponent<Animation>().Play();
            EventSystem.current.currentSelectedGameObject.GetComponent<Animation>().Play("AnswerFailBtnAnim");
            
            audio.PlayOneShot(failAudio);
        }
    }
    List<int> questionsUserList = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7};
    private GameObject correctButtonGO;
    public void GenerateQuestion()
    {
        questionNumber.text = $"Какой жест показывает стропальщик? ({counter}/{questionIntString.Count})";
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
        correctButtonGO = choiseButtons[correctButton].gameObject;
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

    IEnumerator CorrectAnswerCo()
    {
        correctButtonGO.GetComponent<Animation>().Play("CorrectAnswerBtnAnim");
        audio.PlayOneShot(correctAudio);
        yield return new WaitForSeconds(0.75f);
        GenerateQuestion();
    }
}