using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TestStropils : MonoBehaviour
{
    List<string> textTypeStrapovki = new List<string>()
    {
        "В обхват",
        "В двойной обхват",
        "Зацеп за петли",
        "Удавка мертвая петля",
        "В обхват с проставками"
    };
    List<string> textTypeSGP = new List<string>()
    {
        "Автоматический захват",
        "Грейфер",
        "Канатный строп",
        "Цепной строп",
    };
    List<string> textStrop = new List<string>()
    {
        "Четырех ветвевой канатный",
        "Один кольцевой строп",
        "Два двухпетлевых",
        "Двухветвевой двухпетлевой канатный",
        "Один двухпетлевой канатный",
        "Два кольцевых"
    };

    public Dropdown dropdownTypeStrapovki;
    public Dropdown dropdownTypeSgp;
    public Dropdown dropdownStrop;

    public List<int> questions = Enumerable.Range(1,8).ToList();

    public Dictionary<int, List<int>> questionsIntToList = new Dictionary<int, List<int>>()
    {
        {0, new List<int>() {2, 2, 0}},
        {1, new List<int>() {2, 2, 3}},
        {2, new List<int>() {2, 2, 4}},
        {3, new List<int>() {0, 2, 2}},
        {4, new List<int>() {0, 2, 5}},
        {5, new List<int>() {1, 2, 5}},
        {6, new List<int>() {1, 2, 1}},
        {7, new List<int>() {4, 2, 2}},//4,2,1
    };

    private void Start()
    {
        //задаем вариаты ответов
        dropdownTypeStrapovki.options = textTypeStrapovki.Select(s => new Dropdown.OptionData(s)).ToList();
        dropdownTypeSgp.options = textTypeSGP.Select(s => new Dropdown.OptionData(s)).ToList();
        dropdownStrop.options = textStrop.Select(s => new Dropdown.OptionData(s)).ToList();
    }

    private int counter = 0;
    private int currentNumberQustion = -1;

    public void GenerateQuestion()
    {
        //прибавляем счетчик
        counter++;
        //берем рандомный вопрос
        currentNumberQustion = Random.Range(0, questions.Count);
        //убираем его из списка вопросов
        questions.Remove(currentNumberQustion);
    }

    public void CheckAnswers()
    {
        //получаем ответы
        int selectType = dropdownTypeStrapovki.value;
        int selectTypeSgp = dropdownTypeSgp.value;
        int selectStrop = dropdownStrop.value;
        
        //создаем переменную для проверки правильных ответов
        bool isCorrect = true;


        //получаем ответы на текущий вопрос
        var curreentListAnswers = questionsIntToList[currentNumberQustion];

        //проверяем все ответы на корректность
        if (selectType != curreentListAnswers[0])
        {
            isCorrect = false;
        } 
        if (selectTypeSgp != curreentListAnswers[1])
        {
            isCorrect = false;
        }    
        if (selectStrop != curreentListAnswers[2])
        {
            isCorrect = false;
        }
            
        //если правильно след вопрос
        if (isCorrect && counter < questionsIntToList.Count)
        {
            GenerateQuestion();
        }
        else
        {
            Debug.Log("dont correct answer");
        }
    }
}
