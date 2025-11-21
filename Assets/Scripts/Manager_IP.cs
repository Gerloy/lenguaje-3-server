using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Manager_IP : MonoBehaviour
{
    [SerializeField] ScriptableIP IP;
    [SerializeField] TextMeshProUGUI texto;
    // Start is called before the first frame update
    void Start()
    {
        //texto.text = "127.168.0.1";
        //IP.set_ip(texto.text);
    }

    // Update is called once per frame
    void Update()
    {
        //IP.set_ip(texto.text);
        Globales.ip = texto.text;
    }
}
