using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer{

    private float lengthInSeconds;
    private float timer;

    private bool isDone = true;
    private bool started = false;


    public bool IsDone()
    {
        return isDone;
    }
     
    public void StartTimer()
    {
        isDone = false;
        started = true;
    }

	public Timer(float lengthInSeconds, bool startNow = false)
    {
        this.lengthInSeconds = lengthInSeconds;
        this.timer = lengthInSeconds;
        started = startNow;
        isDone = !startNow;
    }

    public void Restart()
    {
        timer = lengthInSeconds;
        started = true;
        isDone = false;
    }

    public void TickTimer(float deltatime)
    {

        if (started)
        {

            timer -= deltatime;
            if (timer <= 0)
            {
                isDone = true;
                started = false;
            }
        }
    }

}
