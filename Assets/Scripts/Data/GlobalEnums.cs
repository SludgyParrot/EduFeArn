/// <summary>
/// A static class that holds globally used enums for the project.
/// This class centralizes all enums for easy access and management throughout the project.
/// </summary>
public static class GlobalEnums
{
    /// <summary>
    /// Enum representing different colors for items in the game.
    /// This can be used for categorizing, styling, or coloring items in a UI, inventory system, or game world.
    /// </summary>
    public enum ItemColor
    {
        Red,
        Green,
        Blue,
        Yellow,
        Orange,
        Purple,
        Cyan,
        Magenta,
        Gray,
        White,
        Black
    }

    /// <summary>
    /// Enum representing different delegate event types in the game.
    /// This can be used for categorizing events.
    /// </summary>
    public enum DelegateEventType
    {
        None,
        OnRoundStartedEvent,
        OnRoundCompletedEvent,
        OnDialogueChangeEvent,
        OnSubmittedResultsEvent
    }

    /// <summary>
    /// Enum representing different results types in the game.
    /// This can be used for state events.
    /// </summary>
    public enum ResultsType
    {
        Correct,
        Incorrect
    }
}
