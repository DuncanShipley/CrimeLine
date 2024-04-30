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
        List<MovementAction> moveActions = new List<MovementAction>();
        foreach (var Item in action)
        {
            switch (Item)
            {
                case PlayerAction.Jump:
                    moveActions.Add(MovementAction.Jump);
                    UnityEngine.Debug.Log("pluh");
                    break;
                case PlayerAction.MoveLeft:
                    moveActions.Add(MovementAction.Left);
                    UnityEngine.Debug.Log("pluh");
                    break;
                case PlayerAction.MoveRight:
                    moveActions.Add(MovementAction.Right);
                    UnityEngine.Debug.Log("pluh");
                    break;
                case PlayerAction.MoveUp:
                    moveActions.Add(MovementAction.Up);
                    break;
                case PlayerAction.MoveDown:
                    moveActions.Add(MovementAction.Down);
                    break;
                
            }
        }
        return moveActions.ToArray();
    }
    private PlayerAction[] CompileActions(KeysPressed keys)
    {
        List<PlayerAction> actions = new List<PlayerAction>();
        bool[] actKeys = new bool[] {keys.Z, keys.X, keys.C, keys.V};
        NegateKey(ref keys.LA, ref keys.RA);
        NegateKey(ref keys.UA, ref keys.DA);
        actKeys = NegateKeys(actKeys);
        bool[] arrowKeys = new bool[] {keys.LA, keys.RA, keys.UA, keys.DA};
        bool[] InpArray =   actKeys.Concat(arrowKeys).ToArray();

        foreach (var item in InpArray.Select((value, index) => (index, value)))
        {
            bool key = item.value;
            int i = item.index;

            if (key)
            {
                switch (i)
                {
                    case 0:
                        actions.Add(PlayerAction.Jump);
                        break;
                    case 1:
                        actions.Add(PlayerAction.Block);
                        break;
                    case 2:
                        actions.Add(PlayerAction.MeleeAttack);
                        break;
                    case 3:
                        actions.Add(PlayerAction.RangeAttack);
                        break;
                    case 4:
                        actions.Add(PlayerAction.MoveLeft);
                        break;
                    case 5:
                        actions.Add(PlayerAction.MoveRight);
                        break;
                    case 6:
                        actions.Add(PlayerAction.MoveUp);
                        break;
                    case 7:
                        actions.Add(PlayerAction.MoveDown);
                        break;
                    default:
                        break;
                }
            }

        }
        return actions.ToArray();
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




