namespace Shared;

[Serializable]
public abstract class CustomException(string message) : Exception(message);