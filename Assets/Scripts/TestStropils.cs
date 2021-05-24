using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TestStropils : MonoBehaviour
{
    List<string> textTypeStrapovki = new List<string>()
    {
        "В обхват",
        "В двойной обхват",
        "Зацеп за петли",
        "Удавка мертвая петля"
    };
    List<string> textTypeSGP = new List<string>()
    {
        "Автоматический захват",
        "Грейфер",
        "Канатный строп",
    };
    List<string> textStrop = new List<string>()
    {
        "Четырех ветвевой канатный",
        "Один кольцевой строп",
        "Два двухпетлевых",
    };

    public Dropdown dropdownTypeStrapovki;
    public Dropdown dropdownTypeSGP;
    public Dropdown dropdownStrop;

    public List<int> question = new List<int>() {0, 1, 2, 3, 4, 5, 6, 7};
    
    
    public void GenerateQuestion()
    {
        dropdownTypeStrapovki.options = textTypeStrapovki.Select(s => new Dropdown.OptionData(s)).ToList();
        dropdownTypeSGP.options = textTypeSGP.Select(s => new Dropdown.OptionData(s)).ToList();
        dropdownStrop.options = textStrop.Select(s => new Dropdown.OptionData(s)).ToList();

        int numberIdQuestion = Random.Range(0, question.Count);
        question.Remove(numberIdQuestion);
        


    }
    
}
