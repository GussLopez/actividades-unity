using Unity.GraphToolkit.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2 : MonoBehaviour
{
    public float velocidad = 5f;

    private Rigidbody2D rigidbody2D;
    private Vector2 direccion;
    // Start is called once before the first execution of Update after the MonoBehaviour is 
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        direccion = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            direccion = Vector2.up; Girar(90);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            direccion = Vector2.down; Girar(270);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            direccion = Vector2.left; Girar(180);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            direccion = Vector2.right; Girar(0);
        }
    }
    void Girar(float angulo)
    {
        transform.rotation = Quaternion.Euler(0, 0, angulo);
    }

    void FixedUpdate()
    {
        rigidbody2D.linearVelocity = direccion * velocidad;
    }

    private void OnCollisionEnter2D(Collision2D choque)
    {
        Debug.Log("Player2 chocó con: " + choque.gameObject.name);
    }
}
