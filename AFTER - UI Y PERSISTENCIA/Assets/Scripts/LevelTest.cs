using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ESTOY EN EL TEST "+ProfileManager.Instance.GetAvatar());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
