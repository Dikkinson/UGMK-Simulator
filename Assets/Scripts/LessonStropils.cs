using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LessonStropils : MonoBehaviour
{  
    
    public List<GameObject> stropili;
    public int currentItem = 0;
    public TextMeshProUGUI text;
    public GameObject pnlTest;
    public List<AudioClip> clips;
    public AudioSource source;
    public GameObject PanelEndLesson;
    
    private List<string> textsStropils = new List<string>()
    {
        "Зацеп за петли. При строповке крюки стропов должны быть направлены от центра груза. Крюки должны иметь предохранительные замки. Данный вид строповки используется для строповки грузов, имеющих петли, цапфы, проушины и.т.д. Производить строповку для подъема следует за все предусмотренные положением петли, цапфы и проушины.",
        "Строповка резервуаров циеллиндрических изделий осуществляется двумя двухкпетлевыми стропами. Подводить строп под груз следует так, чтобы исключить возможность его выскальзывания во время подъема груза.",
        "Строповку груза в обхват (на «удавку») при длине груза менее 2 м допускается производить в одном месте (кроме металлопроката).",
        "Строповка длинномерных грузов (столбов, бревен, труб) должна производиться не менее чем в двух местах. При строповке длинномерных грузов методом обвязки ветви стропов располагать на расстоянии равном ¼ длины элемента от его концов .",
        "При строповке конструкций с острыми ребрами методом обвязки необходимо между ребрами элементов и канатом установить прокладки, предохраняющие канат от перетирания. Прокладки должны быть прикреплены к грузу или в качестве инвентарных постоянно закреплены на стропе."
    };


    private void Start()
    { 
        Edit();
    }

    public void Click(bool isNext)
    {
        if(currentItem < stropili.Count && isNext)
        {
            currentItem++;
        }
        else if (!isNext && currentItem > 0)
        {
            currentItem--;
        }
        Edit();

        if (currentItem == stropili.Count)
        {
            gameObject.SetActive(false);
            PanelEndLesson.SetActive(true);
        }
    }

    public void Edit()
    {
        Vector3 posItem = stropili[currentItem].transform.position;
        Vector3 camPos = Camera.main.transform.position;
        camPos.x = posItem.x;
        Camera.main.transform.position = camPos;
        text.text = textsStropils[currentItem];
        
        var clip = clips[currentItem];
        source.Stop();
        source.PlayOneShot(clip);
    }
    
    
    
    
    public void StartTest()
    {
        PanelEndLesson.SetActive(false);
        pnlTest.SetActive(true);
    }
    
}
