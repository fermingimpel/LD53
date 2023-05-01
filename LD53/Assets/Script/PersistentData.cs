using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{

    public int timePlayed;
    public int packages;

    static PersistentData data;

    private void Start()
    {
        if(data != null)
        {
            Destroy(this.gameObject);
            return;
        }

        data = this;
        DontDestroyOnLoad(this.gameObject);
    }

}
