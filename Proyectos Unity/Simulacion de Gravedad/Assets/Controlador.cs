using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador : MonoBehaviour
{
    public GameObject uwu;
    public Rigidbody rb;
    const float G = 667.4f;
    public static List<Controlador> controllers;
    private void FixedUpdate()
    {
        foreach (Controlador item in controllers)
        {
            if (item != this)
                Gravedad(item);
        }
    }
    void Update()
    {
        if (uwu.transform.position.x > 4500 || uwu.transform.position.x < -4500 || uwu.transform.position.y > 2600 || uwu.transform.position.y < -2600)
        {
            Destroy(uwu);
        }
    }
    void OnEnable()
    {
        if (controllers == null) controllers = new List<Controlador>();
        controllers.Add(this);
    }
    void OnDisable()
    {
        controllers.Remove(this);
    }

    void Gravedad(Controlador other)
    {
        Rigidbody rbother = other.rb;
        Vector3 dir = rb.position - rbother.position;
        float dis = dir.magnitude;
        if (dis == 0f) return;
        float mg = G * (rb.mass * rbother.mass) / Mathf.Pow(dis, 2);
        Vector3 fuerza = dir.normalized * mg;
        rbother.AddForce(fuerza);
    }
}
