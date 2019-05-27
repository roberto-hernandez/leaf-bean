using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundSystem : MonoBehaviour {
    private Text textGO;
    private Phase phase;

    // Use this for initialization
	void Start () {
        textGO = GameObject.Find("CountdownText").GetComponent<Text>();

        // Open Menu
        var canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        canvas.enabled = true;
        phase = new PreparePhase();
        phase.Start();
	}
	
	// Update is called once per frame
	void Update () {
        if(phase.HasEnded())
        {
            phase = phase.Next();
            phase.Start();
        }

        textGO.text = phase.TimeRemaining().ToString();
	}
}

abstract class Phase
{
    protected Alarm alarm;
    protected float duration;

    public void Start()
    {
        alarm = new Alarm();
        alarm.SetDuration(duration);
        alarm.Start();
    }

    public int TimeRemaining()
    {
        return (int)alarm.TimeRemaining();
    }

    public bool HasEnded()
    {
        return alarm.IsRinging();
    }

    public abstract Phase Next();
}

class BattlePhase : Phase
{
    public BattlePhase() : base()
    {
        duration = 7;
    }

    public override Phase Next()
    {
        // Open Menu
        var canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        canvas.enabled = true;

        
        return new PreparePhase();
    }
}

class PreparePhase : Phase
{
    public PreparePhase() : base()
    {
        duration = 5;
    }

    public override Phase Next()
    {
        // Close menu
        var canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        canvas.enabled = false;

        // todo: close prefab instance

        return new BattlePhase();
    }
}

class Alarm
{
    private float timeStarted;
    private float duration;

    public void SetDuration(float duration)
    {
        this.duration = duration;
    }

    public void Start()
    {
        timeStarted = Time.time;
    }

    public bool IsRinging()
    {
        return Time.time - timeStarted > duration;
    }

    public float TimeRemaining()
    {
        var timeRemaining =  duration - (Time.time - timeStarted);
        return timeRemaining > 0 ? timeRemaining : 0;
    }
}
