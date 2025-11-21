using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IP", menuName = "ScriptableObjects/IP", order = 1)]
public class ScriptableIP : ScriptableObject
{
    [SerializeField] private String IP = "127.168.0.1";

    public void set_ip(String _ip){IP = _ip;}
    public String get_ip(){return IP;}

}
