using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class detectar : MonoBehaviour
{
    [SerializeField] ScriptableIP IP;
    [SerializeField] OSC osc;
    Vector3 pos;
    OscMessage mensaje;
    KinectManager kmanager;

    //Variables decisiones
    KeyCode decision1 = KeyCode.Alpha3;
    bool decision1_press = false;
    KeyCode decision2 = KeyCode.Alpha4;
    bool decision2_press = false;
    KeyCode decision3 = KeyCode.Alpha8;
    bool decision3_press = false;



    //Variables piedra
    //bool presionada = false;
    KeyCode piedra = KeyCode.Alpha2;

    // Start is called before the first frame update
    void Start()
    {
        kmanager = KinectManager.Instance;
        //osc.outIP = IP.get_ip();
    }

    // Update is called once per frame
    void Update()
    {
        if (kmanager == null)
        {
            kmanager = KinectManager.Instance;
            //Debug.Log("Pinga");
        }
        else{
        //Mensajes de posicion
        pos = kmanager.GetUserPosition(kmanager.GetPlayer1ID());
        //Debug.Log(pos);
        mensaje = new OscMessage();
        mensaje.address = "/posx";
        //mensaje.values.Add(pos.x * 100 + 39.5);
        mensaje.values.Add(pos.x*35 - 50);
        osc.Send(mensaje);
        //mensaje.values.Add(pos.y);
        mensaje = new OscMessage();
        mensaje.address = "/posz";
        mensaje.values.Add(pos.z*35 - 20);//- 80);
        osc.Send(mensaje);
        }

        //Mensajes de inputs de decisiones
        mensaje = new OscMessage();
        mensaje.address = "/decision";

        //Get de los press de las keys
        if (Input.GetKey(decision1))
        {
            if (!decision1_press)
            {
                mensaje.values.Add(1);
                //Debug.Log("Se mando decision");
                osc.Send(mensaje);
                decision1_press = true;
            } else
            {
                mensaje.values.Add(0);
                //Debug.Log("Se mando decision");
                osc.Send(mensaje);
            }
        }
        if (Input.GetKey(decision2))
        {
            if (!decision2_press)
            {
                mensaje.values.Add(2);
                //Debug.Log("Se mando decision");
                osc.Send(mensaje);
                decision2_press = true;
            }{
                mensaje.values.Add(0);
                //Debug.Log("Se mando decision");
                osc.Send(mensaje);
            }
        }
        if (Input.GetKey(decision3))
        {
            if (!decision3_press)
            {
                mensaje.values.Add(3);
                //Debug.Log("Se mando decision");
                osc.Send(mensaje);
                decision3_press = true;
            }{
                mensaje.values.Add(0);
                //Debug.Log("Se mando decision");
                osc.Send(mensaje);
            }
        }else{
                mensaje.values.Add(0);
                //Debug.Log("Se mando decision");
                osc.Send(mensaje);
            }

        //Get de los releases de las keys
        if (Input.GetKeyUp(decision1))
        {
            decision1_press = false;
        }
        if (Input.GetKeyUp(decision2))
        {
            decision2_press = false;
        }
        if (Input.GetKeyUp(decision3))
        {
            decision3_press = false;
        }
        
        //Mensaje de la piedra como bool
        mensaje = new OscMessage();
        mensaje.address = "/piedra";
        if (Input.GetKey(piedra))
        {
            mensaje.values.Add(1);
        }
        else { mensaje.values.Add(0);}
        osc.Send(mensaje);
    }
    
}
