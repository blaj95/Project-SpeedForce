using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Practice : MonoBehaviour
{
    private int testInt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Ternery operator 
        //If statement true, left expression, if false right expression
        int test = testInt > 5 ? 1 : 0;
    }
    
    //OVERLOADING
    //Using the same name of a method but with a different signiture
    public int Add(int one, int two)
    {
        return one + two;
    }

    public string Add(string one, string two)
    {
        return one + two;
    }
}
