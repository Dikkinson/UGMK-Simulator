using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public List<string> dialogueText = new List<string>()
    {
        "Стропальщик стоит лицом к машинисту крана. Прерывистое движение согнутой в локте рукой ВВЕРХ на уровне пояса, ладонью вверх.",
        "Стропальщик стоит лицом к машинисту крана. Прерывистое движение согнутой в локте рукой ВНИЗ на уровне пояса, ладонью вниз.",
        "Движение рукой, согнутой в локте, ладонью В СТОРОНУ ТРЕБУЕМОГО ДВИЖЕНИЯ стрелы.",
        "Движение <b>ВВЕРХ</b> вытянутой рукой из опущенного положения, ладонь раскрыта.",
        "Движение ВНИЗ вытянутой рукой из поднятого вертикального положения, ладонь раскрыта.",
        "Резкое движение рукой <b>ВПРАВО</b> и ВЛЕВО на уровне пояса, ладонь вниз.",
        "Кисти рук обращены ладонями одна к другой на небольшом расстоянии, руки при этом подняты вверх на уровне лица.",
        "Движение вытянутой рукой, ладонью В СТОРОНУ ТРЕБУЕМОГО ДВИЖЕНИЯ крана или моста. Стропальщик должен стоять лицом к машинисту крана. Если нужно передвинуть кран в другую сторону, то меняется рука, т.к. направление движения должно выходить из ладони",
        "Стропальщик стоит боком к машинисту крана. Движение рукой, согнутой в локте, ладонью В СТОРОНУ ТРЕБУЕМОГО ДВИЖЕНИЯ тележки. Если нужно передвинуть тележку в другую сторону, то меняется рука, т.к. направление движения должно выходить из ладони.",
    };
    
    public TextMeshProUGUI text;
    public List<TimelineAsset> timelines;
    private int counter = 0;
    public PlayableDirector director;
    
    public void StartLesson()
    {
        text.text = dialogueText[counter];
    }

    public void NextClip()
    {
        if (counter < dialogueText.Count)
        {
            counter++;
            text.text = dialogueText[counter];
            var selectedAsset = timelines[counter];
            director.Play(selectedAsset);
        }
    }
}
