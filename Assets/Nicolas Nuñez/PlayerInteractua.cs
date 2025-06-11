using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEditor;

public class PlayerInteractua : MonoBehaviour
{
    //Distancia en el que el jugador puede interactuar con objetos//
    public float alcanceJugador = 15f;
    //Se asigna una variable interactor(del script interactor) para llamar funciones de el script//
    Interactor actualInteractuable;

    public bool tieneLlaves = false;
    void Update()
    {

        CheckInteraccion();
        //Se realiza un input con la tecla f y la condicion actualInteractuable la cual tiene que tener informacion, de lo contrario el if no se ejecuta//

        if (Input.GetKeyDown(KeyCode.F) && actualInteractuable != null)
        {
            
            //se llama la funcion Interactuar() del script Interactor//
            actualInteractuable.Interactuar();
        }
        

    }

    void CheckInteraccion()
    {
        //Crea un raycast y una variable de la colision del raycast//
        RaycastHit Raypega;
        //De donde se crea el ray y hacia donde va(camera, alfrente)//
        Ray rayo = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        //si el raycast pego dentro de el alcance de el jugador//
        if (Physics.Raycast(rayo, out Raypega, alcanceJugador))
        {

            //si el collider del raycast es igual al tag interactuable//
            if (Raypega.collider.tag == "Interactuable" || Raypega.collider.tag == "Llaves")
            {

                Interactor nuevoInteractuable = Raypega.collider.GetComponent<Interactor>();
                //si hay un actualinteractuable y no es el nuevointeractuable se desactiva el outline de el actualinteractuable//
                if (actualInteractuable && nuevoInteractuable != actualInteractuable)
                {
                    actualInteractuable.DesabilitarOutline();
                }
                if (nuevoInteractuable.enabled)
                {
                    HacerNuevoActualInteractuable(nuevoInteractuable);
                }
                else // si el nuevointeractuable no esta habilitado//
                {
                    DesabilitarActualInteractuable();
                    
                }

            }
        }
        //si el ray no pego en un objeto que no es interactuable lo desabilita//
        else
        {
            DesabilitarActualInteractuable();
        }
        if (Physics.Raycast (rayo, out Raypega, alcanceJugador)) {
            if (Raypega.transform.GetComponent<DoorScript.Door>())

            {

                if (Input.GetKeyDown(KeyCode.F) && tieneLlaves == true)
                    Raypega.transform.GetComponent<DoorScript.Door>().OpenDoor();
                    UIInteraccionScript.uiInteraccionScript.HabilitarTextoInteraccion(actualInteractuable.mensaje);
                    
			}
			
		}
            
    }
    //nuevo interactuable tiene que tener una variable de entrada referenciando al script interactor, cambia el actual interactuable al nuevo interactuable y habilita el outline de el nuevointeractuable//
    void HacerNuevoActualInteractuable(Interactor nuevoInteractuable)
    {
        actualInteractuable = nuevoInteractuable;
        nuevoInteractuable.HabilitarOutline();
        //Se hace referencia al script UiInteraccion con un string que es el mensaje que se puede editar en el inspector//
        UIInteraccionScript.uiInteraccionScript.HabilitarTextoInteraccion(actualInteractuable.mensaje);

    }
    //funcion desabilita el outline de el actualinteractuable y la informacion guardada la hace nula//
    void DesabilitarActualInteractuable()
    {
        UIInteraccionScript.uiInteraccionScript.DeshabilitarTextoInteraccion();
        
        


        //Se hace referencia al script UiInteraccion//
        if (actualInteractuable != null && actualInteractuable.CompareTag("Llaves"))
        {
            tieneLlaves = true;
            actualInteractuable.DesabilitarOutline();
            actualInteractuable = null;


        }
        else
        {
            actualInteractuable.DesabilitarOutline();
            actualInteractuable = null;
            
        }


        
        
    }
}
 