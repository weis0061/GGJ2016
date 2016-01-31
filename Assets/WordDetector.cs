using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WordDetector : MonoBehaviour {
    List<GameObject> CurrentPastaList;
    [System.Serializable]
    public struct Word
    {
        public string value;
        public delegate void code();
    }
    public Word[] wordlist;  
    public GameObject[] AlphaghettiDatabase;
    public float AnglePerPasta;
    public float DistancePerPasta;
    public Transform PutPastaPosition;
    public float PutPastaRadius;
    int WStart, WEnd;
    Camera cam;
	// Use this for initialization
	void Start ()
    {
        CurrentPastaList = new List<GameObject>();
        cam = GetComponent<Camera>();
        WStart = 0; 
        WEnd = 0;
        AddPastas(20);
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log("New Frame");
        WStart = 0;
        WEnd = 0;
        for (int i = 0; i < CurrentPastaList.Count; i++)
        {
            rcurf(CurrentPastaList[i], "", new List<GameObject>());
        }
    }

    void AddPastas(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject go = GameObject.Instantiate(AlphaghettiDatabase[0]);
            go.transform.position = PutPastaPosition.position + Random.onUnitSphere * PutPastaRadius;
            CurrentPastaList.Add(go);
        }
    }

    void rcurf(GameObject go,string s,List<GameObject> Chain)
    {
        if (!Chain.Contains(go))
        {
            Chain.Add(go);
            int stringpos = s.Length;

            s = s + go.GetComponent<Alphaghetti>().MyChar;
            int mask = 1 << (int)LayerMask.NameToLayer("noodles");
            RaycastHit[] rhits = Physics.RaycastAll(go.transform.position, cam.transform.right, DistancePerPasta,mask);
            for (int i = 0; i < rhits.Length; i++)
            {
                Vector2 objPos= cam.WorldToScreenPoint(go.transform.position);
                Vector2 newpos = cam.WorldToScreenPoint(rhits[i].transform.position);
                float trigRatio = (newpos.x - objPos.x) / (newpos.y / objPos.y);
                //if (Mathf.Tan(45) > trigRatio||Mathf.Tan(-45)<trigRatio)
                {
                    rcurf(rhits[i].collider.gameObject, s, Chain);
                }
            }
            if (rhits.Length == 0)
            {
                CheckDictionary(s, out WStart, out WEnd);
            }
            if (WEnd != 0)
            {
                if (stringpos >= WStart && stringpos <= WEnd)
                {
                    go.GetComponent<Alphaghetti>().RemoveFromBowl();
                    CurrentPastaList.Remove(go);
                    AddPastas(1);
                }
                return;
            }
        }
    }

    void CheckDictionary(string s,out int WordStart, out int WordEnd)
    {
        WordStart = 0; 
        WordEnd = 0;
        for (int i = 0; i < wordlist.Length; ++i)
        {
            if (s.Contains(wordlist[i].value))
            {
                WordStart = s.IndexOf(wordlist[i].value);
                WordEnd = WordStart + s.Length;
                Debug.Log("Word: " + wordlist[i].value);
                return;
            }
        }
    }
}
