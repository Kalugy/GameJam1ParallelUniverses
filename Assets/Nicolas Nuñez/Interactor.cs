using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using CameraDoorScript;
using DoorScript;

public class Interactor : MonoBehaviour
{
    //Crea una variable outline llamada outline//

    Outline outline;
    //Se asigna un mensaje para mostrar cuando se interactua//
    public string mensaje;
    //Crea un evento usando unityengine.events (un evento funciona similar a cuando uno toca un boton)//
    public UnityEvent enInteraccion;
    private Door doorScript ;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //la variable outline obtiene el componente outline de el objeto//
        outline = GetComponent<Outline>();
        DesabilitarOutline();
    }
    public void Interactuar()
    {
        //llama a el evento eninteraccion//
        enInteraccion.Invoke();
    }
    public void HabilitarOutline()
    {
        //Habilita el outline de el objeto//
        outline.enabled = true;
    }
    public void DesabilitarOutline()
    {
        
        //DesabilitaOutline de el objeto//
        outline.enabled = false;
    }
    
    // Update is called once per frame

}
