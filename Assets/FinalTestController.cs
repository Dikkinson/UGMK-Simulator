using System.Collections;
using System.Collections.Generic;
using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;


[System.Serializable]
public class TimelinesDictionary : SerializableDictionaryBase<string, TimelineAsset> { }

public class FinalTestController : MonoBehaviour
{
    public GameObject panel;
    public GameObject firstBtn;
    public GameObject secondBtn;
    private int state = 0;
    public TimelinesDictionary timelines;
    public PlayableDirector director;
    
    public void BackCharacter()
    {
        if (state == 0)
        {
            state++;
            var selectedAsset = timelines["MoveBackTimeline"];
            director.Stop();
            director.Play(selectedAsset);
            firstBtn.SetActive(false);
        }
    }
    
    public void CheckQuality()
    {
        if (state == 1)
        {
            state++;
            var selectedAsset = timelines["RiseBoxTimeline"];
            director.Stop();
            director.Play(selectedAsset);
            secondBtn.SetActive(false);
        }
        else
        {
            var selectedAsset = timelines["BoxFallTimeline"];
            director.Stop();
            director.Play(selectedAsset);
            //restart
        }
    }
    
    public void StartMoveing()
    {
        if (state == 2)
        {
            state++;
            var selectedAsset = timelines["MoveBoxTimeline"];
            director.Stop();
            director.Play(selectedAsset);
            panel.SetActive(false);
            //end
        }
        else
        {
            var selectedAsset = timelines["BoxFallTimeline"];
            director.Stop();
            director.Play(selectedAsset);
            //restart
        }
    }
}
