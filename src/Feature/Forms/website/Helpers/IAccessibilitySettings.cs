namespace A11Y.Feature.Forms.Helpers
{
    public interface IAccessibilitySettings
    {
        string AutocompleteItemId { get; set; }
        string AutocompleteItemValue { get; set; }
        string AutocompleteCombinedItemId { get; set; }
        string AutocompleteCombinedItemValue { get; set; }
        bool HasAutocomplete { get; set; }
        string AutocompleteValue { get; set; }
    }
}