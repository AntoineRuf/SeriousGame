﻿using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;
using System.Collections.Generic;

public class UseState : IState

{
    private readonly StatePattern guy;

    public UseState(StatePattern statePatternGuy)
    {
        guy = statePatternGuy;
    }

    public void UpdateState()
    {
        guy.ItsTime();
        Use();
    }

    //Change state functions

    public void ToGoUseState()
    { }

    public void ToUseState()
    { }

    public void ToWanderState()
    {
        guy.currentState = guy.wanderState;
    }

    //State - Functions

    public void Use()
    {
        if (Time.time >= guy.curTime + guy.activityToMake.timeOfExec)
        {
            guy.Clear();
            ToWanderState();
        }
    }
}