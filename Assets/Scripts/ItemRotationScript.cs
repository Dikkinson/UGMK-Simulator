using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemRotationScript : MonoBehaviour
{  
    public float rotSpeed = 10f;
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
    
    
    void OnMouseDrag(){
        float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;
    
        stropili[currentItem].transform.RotateAround(Vector3.up, -rotX);
        stropili[currentItem].transform.RotateAround(Vector3.right, rotY);
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
