/*
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
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.CompareTag(targetTag1))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.CompareTag(targetTag2))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.CompareTag(targetTag3))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.CompareTag(targetTag4))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.CompareTag(targetTag5))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.CompareTag(targetTag6))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.CompareTag(targetTag7))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.CompareTag(targetTag8))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.CompareTag(targetTag9))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

    }
}
using UnityEngine;

public class Destroy_obj : MonoBehaviour
{
    public LayerMask asteroidLayer;

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & asteroidLayer) == 0)
            return;

        if (!other.tag.StartsWith("astn"))
            return;

        if (int.TryParse(other.tag.Substring(4), out int tagNumber))
        {
            Debug.Log("Destroyed asteroid type: " + tagNumber);
        }

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}

using UnityEngine;

public class Destroy_obj : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Asteroid") == false && other.tag.StartsWith("astn"))
            return;
        // Extract number from tag
        string tag = other.tag;          // "astn3"
        string numberPart = tag.Substring(4); // "3"
        int tagNumber = int.Parse(numberPart);

        Debug.Log("Destroyed object with tag number: " + tagNumber);

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_obj : MonoBehaviour
{
    public LayerMask asteroidLayer;

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & asteroidLayer) != 0)
        {
            string tag = other.tag;
            Debug.Log(tag);
            
            //string numberPart = tag.Substring(4);
            //int tagNumber = int.Parse(numberPart);
            
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
*/

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
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.CompareTag(targetTag1))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.CompareTag(targetTag2))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.CompareTag(targetTag3))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.CompareTag(targetTag4))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.CompareTag(targetTag5))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.CompareTag(targetTag6))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.CompareTag(targetTag7))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.CompareTag(targetTag8))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.CompareTag(targetTag9))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

    }
}