using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Proyectil : MonoBehaviour
{

    [SerializeField]

    private float _speed = 5;
    
    [SerializeField]

    private float _tiempoDeAutodestruccion = 3;

    private GUIManager _gui;

    void Start(){
        // NOTA IMPORTANTE
        // si voy a crear objetos dinamicamente es importante que 
        // por lo menos tenga 1 estrategia de destruccion

        // destroy - destruye game ob completos o componentes

        Destroy(gameObject, _tiempoDeAutodestruccion);

        //Nota: esto va a cambiar
        GameObject guiGO = GameObject.Find("GUIManager");
        Assert.IsNotNull(guiGO, "no hay GUIManager");

        _gui = guiGO.GetComponent<GUIManager>();
        Assert.IsNotNull(_gui, "GUIManager no tiene componente");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(
            0,
            _speed * Time.deltaTime,
            0
        );
    }

    // COLISIONES
    //1. todos los objetos involucrados necesitan collider
    //2. necesitamos que al menos 1 tenga rigidbody
    //3. el rigidbody debe estar en un objeto que se mueva

    void OnCollisionEnter(Collision c) 
    {
        //objeto collision que recibimos
        //contiene info de la colision

        //como saber que hacer
        //1. filtrar por tag
        //2. filtrar por layer
        print("enter" + c.transform.name);
    }
    
    void OnCollisionStay(Collision c) 
    {
        print("stay");

    }

    void OnCollisionExit(Collision c) 
    {
        print("exit");

    }

    void OnTriggerEnter(Collider c)
    {
        print("trigger enter");
    }

    void OnTriggerStay(Collider c)
    {
        print("trigger stay");

    }

    void OnTriggerExit(Collider c)
    {
        print("trigger exit");
        _gui._texto.text = "SALI " + transform.name;

    }

}
