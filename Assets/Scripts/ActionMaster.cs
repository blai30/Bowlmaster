using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster {

    public enum Action {Tidy, Reset, EndTurn, EndGame}

    public Action Bowl(int pins) {
        return Action.Tidy;
    }

}
