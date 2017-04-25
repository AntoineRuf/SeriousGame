﻿using UnityEngine;
using UnityEngine.AI;

public class ChatState : IState

{
    private readonly StatePattern fm;
    public bool arrived = false;

    public ChatState(StatePattern statePatternGuy)
    {
        fm = statePatternGuy;
    }

    public void UpdateState()
    {
        fm.Uptime();
        fm.ItsTime();
        if (arrived)
        {
            Chat();
        }
        else
        {
            GoChat();
        }
    }


    //State - Functions

    public void GoChat()
    {
        if (Vector3.Distance(fm.guyToTalkTo.transform.position, fm.transform.position) < 2)
        {
            fm.GetComponent<NavMeshAgent>().Stop();
            fm.curTime = fm.time;
            arrived = true;
        }
        else
        {
            fm.GetComponent<NavMeshAgent>().destination = fm.guyToTalkTo.transform.position;
            fm.GetComponent<NavMeshAgent>().Resume();
        }
    }


    public void Chat()
    {
        if (Vector3.Distance(fm.guyToTalkTo.transform.position, fm.transform.position) > 2)
        {
            fm.currentState = fm.wanderState;
        }
        if (fm.time >= fm.curTime + fm.chatTime)
        {
            fm.currentState = fm.wanderState;
        }
    }



}