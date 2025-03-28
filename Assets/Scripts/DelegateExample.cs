using System;
using UnityEngine;

public class DelegateExample : MonoBehaviour
{
    // public delegate void Math(int a, int b);
    // Math math;

    public Action<int, int> math;
    public Func<int, int, int> mathWithReturn;

    public void Start()
    {
        math += Add;
        math += Substract;
        math += Multiply;
        math(2 ,3);
        math -= Multiply;
        math(4, 5);
        mathWithReturn = AddR;
        print(mathWithReturn(3, 4));
    }

    void Add(int a, int b){
        print(a + b);
    }

    void Substract(int a, int b){
        print(a - b);
    }

    void Multiply(int a, int b){
        print(a * b);
    }

    int AddR(int a, int b){
        return a + b;
    }
}
