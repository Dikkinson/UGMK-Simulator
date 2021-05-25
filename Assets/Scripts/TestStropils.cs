﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MiscUtil;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;


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
    public List<GameObject> GameObjectsStropils;
    
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
    
    private int counter = 0;
    private Random rnd = new Random();
    
    public void GenerateQuestion()
    {
        //задаем вариаты ответов
        /*dropdownTypeStrapovki.options = textTypeStrapovki.Select(s => new Dropdown.OptionData(s)).ToList();
        dropdownTypeSgp.options = textTypeSGP.Select(s => new Dropdown.OptionData(s)).ToList();
        dropdownStrop.options = textStrop.Select(s => new Dropdown.OptionData(s)).ToList();*/
        
        dropdownTypeStrapovki.options  = textTypeStrapovki.OrderBy(a => rnd.Next()).Select(s => new Dropdown.OptionData(s)).ToList();
        dropdownTypeSgp.options = textTypeSGP.OrderBy(a => rnd.Next()).Select(s => new Dropdown.OptionData(s)).ToList();
        dropdownStrop.options = textStrop.OrderBy(a => rnd.Next()).Select(s => new Dropdown.OptionData(s)).ToList();
        //прибавляем счетчик
        counter++;

        Vector3 posObject = GameObjectsStropils[counter].transform.position;
        Vector3 cameraPos =  Camera.main.transform.position;
        cameraPos.x = posObject.x;
        Camera.main.transform.position = cameraPos;
    }

    public void CheckAnswers()
    {
        //получаем ответы
        string selectType = dropdownTypeStrapovki.options[dropdownTypeStrapovki.value].text;
        string selectTypeSgp = dropdownTypeSgp.options[dropdownTypeSgp.value].text;
        string selectStrop = dropdownStrop.options[dropdownStrop.value].text;
        
        //создаем переменную для проверки правильных ответов
        bool isCorrect = true;
        
        
        //получаем ответы на текущий вопрос
        var curreentListAnswers = questionsIntToList[counter];
        
        //проверяем все ответы на корректность
        if (selectType != textTypeStrapovki[curreentListAnswers[0]])
        {
            isCorrect = false;
        } 
        if (selectTypeSgp != textTypeSGP[curreentListAnswers[1]])
        {
            isCorrect = false;
        }    
        if (selectStrop != textStrop[curreentListAnswers[2]])
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
