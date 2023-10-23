using CommunityToolkit.Mvvm.ComponentModel;

namespace Browser3.Types
{
    public partial class IdValueCommon : ObservableValidator
    {
        [ObservableProperty]
        int? iD;

        [ObservableProperty]
        string resultValue = string.Empty;
    }
}
