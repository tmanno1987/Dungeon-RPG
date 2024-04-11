using Godot;
using System;
using System.Linq;
using System.Collections.Generic;

public partial class UIController : Control
{
    private Dictionary<CT, UIContainer> containers;
    private bool canPause = false;

    public override void _Ready()
    {
        containers = GetChildren().Where((element) => element is UIContainer).Cast<UIContainer>().ToDictionary((element) => element.container);

        containers[CT.Start].Visible = true;
        containers[CT.Defeat].Visible = false;

        containers[CT.Start].ButtonNode.Pressed += HandleStartPressed;
        containers[CT.Pause].ButtonNode.Pressed += HandlePausePressed;
        
        GameEvents.OnEndGame += HandleEndGame;
        GameEvents.OnVictory += HandleVictory;
    }

    public override void _Input(InputEvent @event)
    {
        // Escape Clauses
        if (!canPause) { return; }
        if (!Input.IsActionJustPressed(GC.INPUT_PAUSE)) { return; }

        containers[CT.Stats].Visible = GetTree().Paused;
        GetTree().Paused = !GetTree().Paused;
        containers[CT.Pause].Visible = GetTree().Paused;
    }

    private void HandlePausePressed()
    {
        GetTree().Paused = false;

        containers[CT.Pause].Visible = false;
        containers[CT.Stats].Visible = true;
    }

    private void HandleVictory()
    {
        canPause = false;
        containers[CT.Stats].Visible = false;
        containers[CT.Victory].Visible = true;

        GetTree().Paused = true;
    }

    private void HandleEndGame()
    {
        canPause = false;
        containers[CT.Stats].Visible = false;
        containers[CT.Defeat].Visible = true;
    }

    private void HandleStartPressed()
    {
        canPause = true;
        GetTree().Paused = false;
        containers[CT.Start].Visible = false;
        containers[CT.Stats].Visible = true;
        GameEvents.RaiseStartGame();
    }
}
