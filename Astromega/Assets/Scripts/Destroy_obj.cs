using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_obj : MonoBehaviour
{
    public string targetTag0 = "astn0";
    public string targetTag1 = "astn1";
    public string targetTag2 = "astn2";
    public string targetTag3 = "astn3";
    public string targetTag4 = "astn4";
    public string targetTag5 = "astn5";
    public string targetTag6 = "astn6";
    public string targetTag7 = "astn7";
    public string targetTag8 = "astn8";
    public string targetTag9 = "astn9";
    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag(targetTag0))
        {
            Destroy(other.gameObject); // destruye el objetivo
            Destroy(gameObject);       //destruye la bala
        }
        if (other.CompareTag(targetTag1))
        {
            Destroy(other.gameObject); // destruye el objetivo
            Destroy(gameObject);       //destruye la bala
        }
        if (other.CompareTag(targetTag2))
        {
            Destroy(other.gameObject); // destruye el objetivo
            Destroy(gameObject);       //destruye la bala
        }
        if (other.CompareTag(targetTag3))
        {
            Destroy(other.gameObject); // destruye el objetivo
            Destroy(gameObject);       //destruye la bala
        }
        if (other.CompareTag(targetTag4))
        {
            Destroy(other.gameObject); // destruye el objetivo
            Destroy(gameObject);       //destruye la bala
        }
        if (other.CompareTag(targetTag5))
        {
            Destroy(other.gameObject); // destruye el objetivo
            Destroy(gameObject);       //destruye la bala
        }
        if (other.CompareTag(targetTag6))
        {
            Destroy(other.gameObject); // destruye el objetivo
            Destroy(gameObject);       //destruye la bala
        }
        if (other.CompareTag(targetTag7))
        {
            Destroy(other.gameObject); // destruye el objetivo
            Destroy(gameObject);       //destruye la bala
        }
        if (other.CompareTag(targetTag8))
        {
            Destroy(other.gameObject); // destruye el objetivo
            Destroy(gameObject);       //destruye la bala
        }
        if (other.CompareTag(targetTag9))
        {
            Destroy(other.gameObject); // destruye el objetivo
            Destroy(gameObject);       //destruye la bala
        }

    }
}
