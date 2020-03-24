using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Moviment : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    public Vector3 direcaoDoPulo = new Vector3(0, 1, 0);
    [Range(1, 20)]
    public float forcaDoPulo = 5.0f;
    [Range(0.5f, 10.0f)]
    public float DistanciaDoChao = 1;
    [Range(0.5f, 5.0f)]
    public float TempoPorPulo = 1.5f;
    public LayerMask LayersNaoIgnoradas = -1;
    private bool estaNoChao, contar = false;
    private float cronometro = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // public float speed = 10.0f;
    // public float rotationSpeed = 100.0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        // moveHorizontal *= Time.deltaTime;
        // moveVertical *= Time.deltaTime;
        // transform.Translate(0, 0, moveVertical);
        // transform.Rotate(0, moveHorizontal, 0);
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    void Update()
    {

        estaNoChao = Physics.Linecast(transform.position, transform.position - Vector3.up * DistanciaDoChao, LayersNaoIgnoradas);

        if (Input.GetKeyDown(KeyCode.Space) && estaNoChao == true && contar == false)
        {
            rb.AddForce(direcaoDoPulo * forcaDoPulo, ForceMode.Impulse);
            estaNoChao = false;
            contar = true;
        }

        if (contar == true)
        {
            cronometro += Time.deltaTime;
        }
        if (cronometro >= TempoPorPulo)
        {
            contar = false;
            cronometro = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ObjetoColetavel"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
