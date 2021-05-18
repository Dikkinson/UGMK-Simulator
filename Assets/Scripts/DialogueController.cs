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
        "Стропальщик стоит лицом к машинисту крана. Прерывистое движение согнутой в локте рукой <b>ВВЕРХ</b> на уровне пояса, ладонью вверх.",
        "Стропальщик стоит лицом к машинисту крана. Прерывистое движение согнутой в локте рукой <b>ВНИЗ</b> на уровне пояса, ладонью вниз.",
        "Движение рукой, согнутой в локте, ладонью <b>В СТОРОНУ ТРЕБУЕМОГО ДВИЖЕНИЯ</b> стрелы.",
        "Движение <b>ВВЕРХ</b> вытянутой рукой из опущенного положения, ладонь раскрыта.",
        "Движение <b>ВНИЗ</b> вытянутой рукой из поднятого вертикального положения, ладонь раскрыта.",
        "Резкое движение рукой <b>ВПРАВО</b> и ВЛЕВО на уровне пояса, ладонь вниз.",
        "Кисти рук обращены ладонями одна к другой на небольшом расстоянии, руки при этом подняты вверх на уровне лица.",
        "Движение вытянутой рукой, ладонью <b>В СТОРОНУ ТРЕБУЕМОГО ДВИЖЕНИЯ</b> крана или моста. Стропальщик должен стоять лицом к машинисту крана. Если нужно передвинуть кран в другую сторону, то меняется рука, т.к. направление движения должно выходить из ладони",
        "Стропальщик стоит боком к машинисту крана. Движение рукой, согнутой в локте, ладонью <b>В СТОРОНУ ТРЕБУЕМОГО ДВИЖЕНИЯ</b> тележки. Если нужно передвинуть тележку в другую сторону, то меняется рука, т.к. направление движения должно выходить из ладони.",
    };
    
    public TextMeshProUGUI text;
    public List<TimelineAsset> timelines;
    private int counter = 0;
    public PlayableDirector director;
    
    public void StartLesson()
    {
        NextClip();
    }

    public void NextClip()
    {
        if (counter < dialogueText.Count && counter < timelines.Count)
        {
            text.text = dialogueText[counter];
            var selectedAsset = timelines[counter];
            director.Play(selectedAsset);
            counter++;
        }
    }
}
