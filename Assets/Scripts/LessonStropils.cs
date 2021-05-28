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
    
    private List<string> textsStropils = new List<string>()
    {
        "Строповку изделий, а также других грузов, имеющих петли, цапфы, производить за все предусмотренные для подъема в соответствующем положении петли, цапфы",
        "Двойной обхват и мертвой петлей",
        "Двойной обхват",
        "Удавка, мертвая петля.",
        "1",
        "2",
        "3",
        "4",
    };
    
    
    

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
        
        Vector3 posItem = stropili[currentItem].transform.position;
        Vector3 camPos = Camera.main.transform.position;
        camPos.x = posItem.x;
        Camera.main.transform.position = camPos;
        text.text = textsStropils[currentItem];
    }

    public void StartTest()
    {
        gameObject.SetActive(false);
        pnlTest.SetActive(true);
    }
    
}
