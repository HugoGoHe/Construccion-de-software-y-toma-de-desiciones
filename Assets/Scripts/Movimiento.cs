// estamos usando .NET
// aqui importamos namespaces
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

//con esta directiva obligamos la presencia de un componente en el gameobject 

[RequireComponent(typeof(Transform))]

public class Movimiento : MonoBehaviour
{


    private Transform _transform;
    [SerializeField]
    private  float _speed = 10;

    [SerializeField]
    private Proyectil _disparoOriginal;

    //ciclo de vida / lifecycle
    // existen metodos que se invocan en momentos especificos de la vida del script
    void Awake()
    {
       // print("AWAKE");
    }

    // Start is called before the first frame update
    void Start()
    {
       // Debug.Log("AWAKE");

        //como obtener referencia a otro componente
        //NOTAS
        //GetComponent es lento, hazlo lo menos posible
        //puede regresar nulo
        _transform = GetComponent<Transform>();
        Assert.IsNotNull(_transform, "ES NECESARIO PARA MOVIMIENTO TENER UN TRANSFORM");
        Assert.IsNotNull(_disparoOriginal, "DISPARO NO PUEDE SER NULO");
        Assert.AreNotEqual(0, _speed, "VELOCIDAD DEBE SER MAYOR A 0");
    }

    // Update is called once per frame  
    void Update()
    {
       // Debug.LogWarning("UPDATE");

        //SIEMPRE vamos a tratar que este sea lo mas magro posible
        //2 cosas
        //1.Entrada de usuario
        //2.Movimiento   

        //cuando estaba libre en el anterior y se presiona en el actual
        if(Input.GetKeyDown(KeyCode.A))
        {
            print("KEY DOWN: A");
        }
        //Cuando en el cuadro anterior estaba presionada y en el actual sigue presionada
        if(Input.GetKey(KeyCode.A))
        {
            print("KEY: A");

        }
        //estaba presionada, ya esta libre
        if(Input.GetKeyUp(KeyCode.A))
        {
            print("KEY UP: A");

        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

       // print(horizontal + " " + vertical);

    

        //como mover objetos
        //4 opciones
        //1 transform
        //2 character controller
        //3 motor de fisica
        //4 navmesh (AI)

        _transform.Translate(
            horizontal * _speed * Time.deltaTime,
            vertical * _speed * Time.deltaTime,
            0,
            Space.World);

        if(Input.GetButtonDown("Jump")){
            print("JUMP");

            //se pueden hacer gameobjects vacios
            //Gameobject objeto = new GameObject();

            //si queremos un gameo predefinido para clonar
            //usamos instantiate
            Instantiate(
                _disparoOriginal,
                transform.position,
                transform.rotation);
        }

    }

    //Update que corre en intervalo fijado en la config del proyecto
    //No puede correr mas frecuentemente que update
    void FixedUpdate(){
      //  Debug.LogError("FIXED UPDATE");
    }

    void LateUpdate(){}
}
