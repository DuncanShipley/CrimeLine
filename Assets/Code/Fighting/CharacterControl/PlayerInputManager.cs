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
    PlayerAction[] playActions = null;
    [SerializeField] PlayerActionManager actionManager;
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
        playActions = CompileActions(keys);
        actionManager.TryMoveAction(ReadyForMoveManager(playActions));
        actionManager.TryAction(playActions);
    }
    private MovementAction[] ReadyForMoveManager(PlayerAction[] action)
    {
        MovementAction[] moveActions = new MovementAction[0];
        foreach (var Item in action)
        {
            switch (Item)
            {
                case PlayerAction.Jump:
                    moveActions.Append(MovementAction.Jump);
                    UnityEngine.Debug.Log("pluh");
                    break;
                case PlayerAction.MoveLeft:
                    moveActions.Append(MovementAction.Left);
                    UnityEngine.Debug.Log("pluh");
                    break;
                case PlayerAction.MoveRight:
                    moveActions.Append(MovementAction.Right);
                    UnityEngine.Debug.Log("pluh");
                    break;
                case PlayerAction.MoveUp:
                    moveActions.Append(MovementAction.Up);
                    break;
                case PlayerAction.MoveDown:
                    moveActions.Append(MovementAction.Down);
                    break;
                
            }
        }
        return moveActions;
    }
    private PlayerAction[] CompileActions(KeysPressed keys)
    {
        PlayerAction[] actions = new PlayerAction[0];
        bool[] actKeys = new bool[] {keys.Z, keys.X, keys.C, keys.V};
        NegateKey(ref keys.LA, ref keys.RA);//make the bool logic here correct
        NegateKey(ref keys.UA, ref keys.DA);
        actKeys = NegateKeys(actKeys);
        bool[] arrowKeys = new bool[] {keys.LA, keys.RA, keys.UA, keys.DA};
        bool[] InpArray =   actKeys.Concat(arrowKeys).ToArray();

        foreach (var item in InpArray.Select((value, index) => (index, value)))//prob is from the select
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
                        UnityEngine.Debug.Log("pluh");
                        break;
                    case 3:
                        actions.Append(PlayerAction.MeleeAttack);
                        break;
                    case 4:
                        actions.Append(PlayerAction.RangeAttack);
                        break;
                    case 5:
                        actions.Append(PlayerAction.MoveRight);
                        UnityEngine.Debug.Log("pluh");
                        break;
                    case 6:
                        actions.Append(PlayerAction.MoveLeft);
                        UnityEngine.Debug.Log("pluh");
                        break;
                    case 7:
                        actions.Append(PlayerAction.MoveDown);
                        UnityEngine.Debug.Log("pluh");
                        break;
                    case 8:
                        actions.Append(PlayerAction.MoveUp);
                        UnityEngine.Debug.Log("pluh");
                        break;
                    default:
                        break;
                }
            }

        }
        return actions;
    }

    private void NegateKey(ref bool keyOne, ref bool keyTwo)
    {
        
        (bool, bool) dawg = (keyOne, keyTwo) = ((keyOne && !keyTwo), (keyTwo && !keyOne));
        keyOne = dawg.Item1;
        keyTwo = dawg.Item2;
    }

    static bool[] NegateKeys(params bool[] boolValues)//this has an error and is making things null 
    {
        int firstTrue = Array.FindIndex(boolValues, x => x);
        bool[] mutatedValues = new bool[boolValues.Length];
        if (firstTrue != -1)
            mutatedValues[firstTrue] = true;
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




