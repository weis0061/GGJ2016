using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WordDetector : MonoBehaviour {
    List<GameObject> CurrentPastaList;
    List<GameObject> ChainedPastaList;
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
	// Use this for initialization
	void Start ()
    {
        CurrentPastaList = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update ()
    {
       // rcurf(CurrentPastaList[0],"");
	}

    void AddPastas(int count)
    {
        for (int i = 0; i < count; i++)
        {
            //CurrentPastaList.Add();
            //GameObject go = GameObject.Instantiate(AlphaghettiDatabase[0]);
        }
    }

    void rcurf(GameObject go,string s)
    {
        if (!ChainedPastaList.Contains(go))
        {
            s = s + go.GetComponent<Alphaghetti>().MyChar;
            RaycastHit[] rhits = Physics.SphereCastAll(go.transform.position, DistancePerPasta, go.transform.right, DistancePerPasta, LayerMask.NameToLayer("noodles"));
            for (int i = 0; i < rhits.Length; i++)
            {
                if(Vector3.Angle(go.transform.right,rhits[i].transform.position-go.transform.position)<=AnglePerPasta)
                rcurf(rhits[i].collider.gameObject, s);
            }
            if (rhits.Length == 0)
            {
                CheckDictionary(s);
            }
        }
    }

    void CheckDictionary(string s)
    {
        for (int i = 0; i < wordlist.Length; ++i)
        {
            if (wordlist[i].value.Contains(s))
            {
                Debug.Log("Word!");
            }
        }
    }
}
