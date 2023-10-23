using CommunityToolkit.Mvvm.ComponentModel;

namespace Browser3.Types
{
    /// <summary>
    ///     Why not KeyValuePair int, string ?
    ///     I need Proper Names for XAML Binding ?
    /// </summary>
    public partial class CommonIdValueObject : ObservableValidator
    {
        [ObservableProperty]
        int iD;

        [ObservableProperty]
        string name = string.Empty;
    }
}
