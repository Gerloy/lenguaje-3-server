using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectar : MonoBehaviour
{
    [SerializeField] OSC osc;
    Vector3 pos;
    OscMessage mensaje;
    KinectManager kmanager;
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
            //Debug.Log("Sdwadwa");
            pos = kmanager.GetUserPosition(kmanager.GetPlayer1ID());
            Debug.Log(pos);
            mensaje = new OscMessage();
            mensaje.address = "/posx";
            //mensaje.values.Add(pos.x * 100 + 39.5);
            mensaje.values.Add((pos.x*100)-39);
            osc.Send(mensaje);
            //mensaje.values.Add(pos.y);
            mensaje = new OscMessage();
            mensaje.address = "/posz";
            mensaje.values.Add(pos.z*100 - 80);
            osc.Send(mensaje);
            //mensaje = new OscMessage();
            //mensaje.address = "/nada";
            //mensaje.values.Add("Pinga");
            //osc.Send(mensaje);

        }
    }
}
