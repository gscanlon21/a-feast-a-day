﻿namespace Web.ViewModels.User;

/// <summary>
/// A plain & simple message renderer.
/// </summary>
public class StatusMessageViewModel(string message)
{
    public string Message { get; private init; } = message;

    /// <summary>
    /// Will attempt to go back, or close the tab after X seconds.
    /// 
    /// Leave null to disable auto-close. 
    /// </summary>
    public int? AutoCloseInXSeconds { get; init; } = 9;

    /// <summary>
    /// Should hide certain content from the landing page demo?
    /// </summary>
    public bool? Demo { get; init; }
}
