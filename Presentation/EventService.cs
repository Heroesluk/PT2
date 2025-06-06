namespace Presentation;

internal static class EventService
{
    public static event EventHandler<EventArgs> CatalogChanged;

    public static void OnCatalogChanged()
    {
        CatalogChanged?.Invoke(null, EventArgs.Empty);
    }
}