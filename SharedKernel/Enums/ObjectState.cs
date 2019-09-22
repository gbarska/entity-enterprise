namespace SharedKernel.Enums
{
  /// <summary>
  /// we use this property to make sure that each object keeps his own state
  /// so that we could manage to set the correct state to EF for context's untracked objects 
  /// </summary>
  public enum ObjectState
  {
    Unchanged = 0,
    Added = 1,
    Modified = 2,
    Deleted = 3
  }
}