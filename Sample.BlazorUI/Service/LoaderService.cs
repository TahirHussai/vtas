namespace Sample.BlazorUI.Service
{
    public class LoaderService
    {
        public event Action<bool>? OnLoaderChanged;

        public void Show() => OnLoaderChanged?.Invoke(true);
        public void Hide() => OnLoaderChanged?.Invoke(false);
    }

}
