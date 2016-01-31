using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WordDetector : MonoBehaviour
{
    List<GameObject> CurrentPastaList;
    [System.Serializable]
    public struct Word
    {
        public string value;
        public delegate void code();
    }
    public Word[] wordlist;
    [System.Serializable]
    public struct AlphaghettiWeight
    {
        public GameObject Object;
        public int weight;
    }
    public WordHandler WHandler;
    public AlphaghettiWeight[] AlphaghettiDatabase;
    public float AnglePerPasta;
    public float DistancePerPasta;
    public Transform PutPastaPosition;
    public float PutPastaRadius;
    int WStart, WEnd;
    public int InitialSpawnLetters;
    public float SpaghettiSpawnRate = 5f;
    float SpaghettiTimer = 5f;
    Camera cam;
    int TotalWeight;
    // Use this for initialization
    void Start()
    {
        CurrentPastaList = new List<GameObject>();
        cam = GetComponent<Camera>();


        if (!WHandler) WHandler = GetComponent<WordHandler>();
        WStart = 0;
        WEnd = 0;
        TotalWeight = 0;
        for (int i = 0; i < AlphaghettiDatabase.Length; i++)
        {
            TotalWeight += AlphaghettiDatabase[i].weight;
        }


        AddPastas(InitialSpawnLetters);
    }
    public static int WordsMade = 0;
    public static int LettersUsed = 0;
    public float TimeLeft = 300;

    // Update is called once per frame
    void Update()
    {
        SpaghettiTimer -= Time.deltaTime;
        if (SpaghettiTimer <= 0)
        {
            SpaghettiTimer = SpaghettiSpawnRate;
            AddPastas(1);
        }
        for (int i = 0; i < CurrentPastaList.Count; i++)
        {
            WStart = 0;
            WEnd = 0;
            rcurf(CurrentPastaList[i], "", new List<GameObject>());
        }
        TimeLeft -= Time.deltaTime;
        if (TimeLeft <= 0)
        {

        }

    }

    public void AddPastas(int count)
    {
        for (int i = 0; i < count; i++)
        {
            int TempWeight = TotalWeight;
            int rand = Random.Range((int)0, (int)TotalWeight);
            for (int j = 0; j < AlphaghettiDatabase.Length; j++)
            {
                TempWeight -= AlphaghettiDatabase[j].weight;
                if (TempWeight < rand)
                {
                    GameObject go = GameObject.Instantiate(AlphaghettiDatabase[j].Object);
                    go.transform.position = PutPastaPosition.position + Random.onUnitSphere * PutPastaRadius;
                    CurrentPastaList.Add(go);
                    j = AlphaghettiDatabase.Length;
                }
            }
        }
    }

    void rcurf(GameObject go, string s, List<GameObject> Chain)
    {
        if (!Chain.Contains(go))
        {
            Chain.Add(go);
            Alphaghetti ag = go.GetComponentInParent<Alphaghetti>();
            if (ag != null)
            {
                if (!ag.IsRemoved)
                {
                    int stringpos = s.Length;

                    s = s + ag.MyChar;
                    int mask = 1 << (int)LayerMask.NameToLayer("noodles");
                    RaycastHit[] rhits = Physics.RaycastAll(go.transform.position, cam.transform.right, DistancePerPasta, mask);
                    Debug.DrawLine(go.transform.position, cam.transform.right * DistancePerPasta + go.transform.position);
                    for (int i = 0; i < rhits.Length; i++)
                    {
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
                            ag.RemoveFromBowl();
                            CurrentPastaList.Remove(ag.gameObject);
                            LettersUsed++;
                        }
                        return;
                    }
                }
            }
        }
    }

    void CheckDictionary(string s, out int WordStart, out int WordEnd)
    {
        WordStart = 0;
        WordEnd = 0;
        for (int i = 0; i < wordlist.Length; ++i)
        {
            if (s.Contains(wordlist[i].value))
            {
                WordStart = s.IndexOf(wordlist[i].value);
                WordEnd = WordStart + wordlist[i].value.Length - 1;
                WHandler.HandleWord(wordlist[i].value);
                WordsMade++;
                return;
            }
        }
    }
}
