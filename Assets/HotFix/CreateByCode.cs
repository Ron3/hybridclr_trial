using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HCLRGame;

public class CreateByCode : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        int result = Ob_TestCode.Func_Add(1, 2);
        Debug.Log($"这个脚本是通过代码AddComponent直接创建的 {result}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
