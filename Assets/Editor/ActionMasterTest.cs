﻿using System;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

[TestFixture]
public class ActionMasterTest {

    private ActionMaster actionMaster;
    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    private ActionMaster.Action reset = ActionMaster.Action.Reset;

    [SetUp]
    public void Setup() {
        actionMaster = new ActionMaster();
    }

	[Test]
	public void T00PassingTest() {
		Assert.AreEqual(1, 1);
	}

    [Test]
    public void T01OneStrikeReturnsEndTurn() {
        Assert.AreEqual(endTurn, actionMaster.Bowl(10));
    }

    [Test]
    public void T02Bowl8ReturnsTidy() {
        Assert.AreEqual(tidy, actionMaster.Bowl(8));
    }

    [Test]
    public void T03Bowl28ReturnsEndTurn() {
        actionMaster.Bowl(8);
        Assert.AreEqual(endTurn, actionMaster.Bowl(2));
    }

    [Test]
    public void T04CheckResetAtStrikeInLastFrame() {
        //             1  2  3  4  5  6  7  8  9 10 11 12 13 14 15 16 17 18
        int[] rolls = {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1};
        foreach (int roll in rolls) {
            actionMaster.Bowl(roll);
        }
        Assert.AreEqual(reset, actionMaster.Bowl(10));
    }

}
