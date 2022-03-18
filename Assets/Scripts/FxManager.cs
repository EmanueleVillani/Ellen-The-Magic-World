using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxManager : MonoBehaviour
{
    public static FxManager obj;
    public GameObject pop;

     void Awake()
    {
        obj = this; 
    }

    public void ShowPop(Vector3 pos)
    {
        pop.gameObject.GetComponent<Pop>().Show(pos);
    }

    private void OnDestroy()
    {
        obj = null;
    }
}
