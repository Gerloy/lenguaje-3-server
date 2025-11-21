using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Change_scn : MonoBehaviour
{
    [SerializeField] private String to_scn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activar()
    {
        SceneManager.LoadSceneAsync(to_scn);
    }
}
