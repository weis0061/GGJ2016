using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
[RequireComponent(typeof(buoyant))]
public class Alphaghetti : MonoBehaviour
{

    public char MyChar;
	buoyant b;
    [HideInInspector]
    public bool IsRemoved;
    // Use this for initialization
    void Start()
    {
        IsRemoved = false;
		b=GetComponent<buoyant>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsRemoved)
        {
            if (transform.position.y > 50) 
                Destroy(this.gameObject);
            return;
        }
    }


    public void RemoveFromBowl()
	{
		b=GetComponent<buoyant>();
		b.WaterHeight=60;
        gameObject.layer = 0;
        IsRemoved = true;
    }
}
