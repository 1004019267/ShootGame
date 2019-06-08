using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//1 定义委托
public delegate void IntDelegate(int val);
public class EventManager {

    //2.声明委托
    public static IntDelegate ScoreAdd;
}
