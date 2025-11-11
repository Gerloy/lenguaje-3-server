using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectar : MonoBehaviour
{
    [SerializeField] OSC osc;
    Vector3 pos;
    OscMessage mensaje;
    KinectManager kmanager;

    //Variables decisiones
    KeyCode decision1 = KeyCode.Alpha1;
    KeyCode decision2 = KeyCode.Alpha2;
    KeyCode decision3 = KeyCode.Alpha3;


    //Variables piedra
    //bool presionada = false;
    KeyCode piedra = KeyCode.UpArrow;

    // Start is called before the first frame update
    void Start()
    {
        kmanager = KinectManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(kmanager == null)
		{
			kmanager = KinectManager.Instance;
            //Debug.Log("Pinga");
		}
        else{
            
            //Mensajes de posicion
            pos = kmanager.GetUserPosition(kmanager.GetPlayer1ID());
            Debug.Log(pos);
            mensaje = new OscMessage();
            mensaje.address = "/posx";
            //mensaje.values.Add(pos.x * 100 + 39.5);
            mensaje.values.Add((pos.x*35)-39);
            osc.Send(mensaje);
            //mensaje.values.Add(pos.y);
            mensaje = new OscMessage();
            mensaje.address = "/posz";
            mensaje.values.Add(pos.z*35 - 80);
            osc.Send(mensaje);

            //Mensajes de inputs de decisiones
            mensaje = new OscMessage();
            mensaje.address = "/decision";
            if (Input.GetKeyDown(decision1)){
                mensaje.values.Add(1);
            }else if (Input.GetKeyDown(decision2)){
                mensaje.values.Add(2);
            }else if (Input.GetKeyDown(decision3)){
                mensaje.values.Add(3);
            }else {
                mensaje.values.Add(0);
            }
            osc.Send(mensaje);

            //Mensaje de la piedra como bool
            mensaje = new OscMessage();
            mensaje.address = "/piedra";
            mensaje.values.Add(Input.GetKeyDown(piedra));
            osc.Send(mensaje);
        }
    }
}
