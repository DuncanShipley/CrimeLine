using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.Code.Fighting.CharacterControl;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
  
    
    

    private void Start()
    {
        bool[] array = new bool[0];
        array.Append(true);
        array.Append(false);
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

    private PlayerAction[] CompileActions(KeysPressed keys)
    {
        PlayerAction[] actions = new PlayerAction[0];
        bool[] actKeys = new bool[] {keys.Z, keys.X, keys.C, keys.V};
        NegateKey(ref keys.LA, ref keys.RA);//make the bool logic here correct
        NegateKey(ref keys.UA, ref keys.DA);
        actKeys = NegateKeys(actKeys);

        bool[] InpArray = new bool[] 
        {}.Concat<bool>(actKeys.Concat<bool>(
            new bool[] { keys.RA, keys.LA, keys.DA, keys.UA}
            )) as bool[];

        foreach (var item in InpArray.Select((value, index) => (value, index)))
        {
            bool key = item.value;
            int i = item.index;
            if (key)
            {
                switch (i)
                {
                    case 1:
                        actions.Append(PlayerAction.Block);
                        break;
                    case 2:
                        actions.Append(PlayerAction.Jump);
                        break;
                    case 3:
                        actions.Append(PlayerAction.MeleeAttack);
                        break;
                    case 4:
                        actions.Append(PlayerAction.RangeAttack);
                        break;
                    case 5:
                        actions.Append(PlayerAction.MoveRight);
                        break;
                    case 6:
                        actions.Append(PlayerAction.MoveLeft);
                        break;
                    case 7:
                        actions.Append(PlayerAction.MoveDown);
                        break;
                    case 8:
                        actions.Append(PlayerAction.MoveUp);
                        break;
                }
            }

        }
        return actions;
    }

    private void NegateKey(ref bool keyOne, ref bool keyTwo)
    {
        keyOne = keyOne && !keyTwo;///////////Ben help needed
        keyTwo = keyOne && keyTwo;
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


    private KeysPressed KeysPressedfromBoolArray(bool[] bools)
    {
        return new KeysPressed
        (
            bools[0],
            bools[1],
            bools[2],
            bools[3],
            bools[4],
            bools[5],
            bools[6],
            bools[7]
        );
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




