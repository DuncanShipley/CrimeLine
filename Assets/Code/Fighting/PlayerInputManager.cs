using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.Code.Fighting.EnemyManagers;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    ActionManager act;
    
    

    private void Start()
    {
        act = GetComponent<ActionManager>();

    }

    private void Update()
    {
        KeysPressed keys = 
            new KeysPressed(
                Input.GetKey(KeyCode.Z), 
                Input.GetKey(KeyCode.X), 
                Input.GetKey(KeyCode.C), 
                Input.GetKey(KeyCode.V), 
                Input.GetKey(KeyCode.RightArrow), 
                Input.GetKey(KeyCode.LeftArrow), 
                Input.GetKey(KeyCode.UpArrow), 
                Input.GetKey(KeyCode.DownArrow));
        CompileActions(keys);
    }

    private Action[] CompileActions(KeysPressed keys)
    {
        Action[] actions = new Action[];
        bool[] actKeys = new bool[] {keys.Z, keys.X, keys.C, keys.V};
        NegateKey(ref keys.LA, ref keys.RA);//make the bool logic here correct
        NegateKey(ref keys.UA, ref keys.DA);
        actKeys = NegateKeys(actKeys);
        bool[] moveKeys = new bool[] {keys.RA, keys.LA, keys.DA, keys.UA};
        actions.Append(ConvertToActions(actKeys));//
        actions.Append(ConvertToActions(moveKeys));//do something like this that works
        return
            actions;
    }
    
    private Action[] ConvertToActions(bool [] InpArray)
    {
        Action[] actions = new Action[];
        foreach (var item in InpArray.Select((value, index) => (index, value)))
        {
            bool key = item.value;
            int i = item.index;
            if (key)
            {
                switch (i)
                {
                    case 1:
                        actions.Append();
                        break;
                    case 2:
                        actions.Append();
                        break;
                    case 3:
                        actions.Append();
                        break;
                    case 4:
                        actions.Append();
                        break;
                }
            }

        }
        return actions;
    }

    private void NegateKey(ref bool keyOne, ref bool keyTwo)
    {
        keyOne = keyOne && !keyTwo;
        keyTwo = !keyOne && keyTwo;
    }

    static bool[] NegateKeys(params bool[] boolValues)
    {
        int firstTrue = Array.FindIndex(boolValues, x => x);

        bool[] mutatedValues = boolValues
            .Select((b, i) => (value: i == firstTrue, index: i))
            .Select(x => x.value)
            .ToArray();
        return mutatedValues;
    }
}

record KeysPressed
{
    public bool Z;
    public bool X;
    public bool C;
    public bool V;
    public bool RA;
    public bool LA;
    public bool UA;
    public bool DA;
    //just make this method right?
    public KeysPressed(bool Z, bool X, bool C, bool V, bool RA, bool LA, bool UA, bool DA)
    {
        this.Z = Z;
        this.X = X;
        this.C = C;
        this.V = V;
        this.RA = RA;
        this.LA = LA;
        this.UA = UA;
        this.DA = DA;
    }
}




